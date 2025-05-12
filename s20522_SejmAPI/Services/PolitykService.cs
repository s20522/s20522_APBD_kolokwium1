namespace s20522_SejmAPI.Services;

using System.Data;
using Microsoft.Data.SqlClient;
using s20522_SejmAPI.DTOs;
using s20522_SejmAPI.Exceptions;

public class PolitykService : IPolitykService
{
    private readonly IConfiguration _configuration;
    private IPolitykService _politykServiceImplementation;

    public PolitykService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    private async Task<SqlConnection> GetConnectionAsync()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        var connection = new SqlConnection(connectionString);
        if (connection.State != ConnectionState.Open)
        {
            await connection.OpenAsync();
        }
        return connection;
    }

    public async Task<IEnumerable<PolitykGetDto>> GetAllPolitycyAsync()
    {
        var politycyDict = new Dictionary<int, PolitykGetDto>();
        await using var connection = await GetConnectionAsync();
        var sql = """
                  SELECT
                      pol.Id AS PolitykId, pol.Imie, pol.Nazwisko, pol.Powiedzenie,
                      par.Nazwa AS PartiaNazwa, par.Skrot AS PartiaSkrot, par.DataZalozenia,
                      prz.Od AS PrzynaleznoscOd, prz.Do AS PrzynaleznoscDo,
                      par.Id AS PartiaId
                  FROM Polityk pol
                  LEFT JOIN Przynaleznosc prz ON pol.Id = prz.Polityk_Id
                  LEFT JOIN Partia par ON prz.Partia_Id = par.Id
                  """;

        await using var command = new SqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var politykId = reader.GetInt32(reader.GetOrdinal("PolitykId"));

            if (!politycyDict.TryGetValue(politykId, out var politykDetails))
            {
                politykDetails = new PolitykGetDto
                {
                    Id = politykId,
                    Imie = reader.GetString(reader.GetOrdinal("Imie")),
                    Nazwisko = reader.GetString(reader.GetOrdinal("Nazwisko")),
                    Powiedzenie = await reader.IsDBNullAsync(reader.GetOrdinal("Powiedzenie"))
                                    ? null
                                    : reader.GetString(reader.GetOrdinal("Powiedzenie")),
                    Przynaleznosc = new List<PolitykPartiaDto>()
                };
                politycyDict.Add(politykId, politykDetails);
            }

            if (!await reader.IsDBNullAsync(reader.GetOrdinal("PartiaId")))
            {
                politykDetails.Przynaleznosc.Add(new PolitykPartiaDto
                {
                    Nazwa = reader.GetString(reader.GetOrdinal("PartiaNazwa")),
                    Skrot = await reader.IsDBNullAsync(reader.GetOrdinal("PartiaSkrot"))
                              ? null
                              : reader.GetString(reader.GetOrdinal("PartiaSkrot")),
                    DataZalozenia = reader.GetDateTime(reader.GetOrdinal("DataZalozenia")),
                    Od = reader.GetDateTime(reader.GetOrdinal("PrzynaleznoscOd")),
                    Do = await reader.IsDBNullAsync(reader.GetOrdinal("PrzynaleznoscDo"))
                           ? null
                           : reader.GetDateTime(reader.GetOrdinal("PrzynaleznoscDo"))
                });
            }
        }

        return politycyDict.Values;
    }
    
}