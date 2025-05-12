namespace s20522_SejmAPI.DTOs;

public class PolitykGetDto
{
    public int Id { get; set; }
    public string Imie { get; set; } = null!;
    public string Nazwisko { get; set; } = null!;
    public string? Powiedzenie { get; set; }
    public List<PolitykPartiaDto> Przynaleznosc { get; set; } = new List<PolitykPartiaDto>();
}