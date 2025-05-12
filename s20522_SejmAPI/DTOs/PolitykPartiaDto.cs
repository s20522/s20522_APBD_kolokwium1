namespace s20522_SejmAPI.DTOs;

public class PolitykPartiaDto
{
    public string Nazwa { get; set; } = null!;
    public string? Skrot { get; set; }
    public DateTime DataZalozenia { get; set; }
    public DateTime Od { get; set; }
    public DateTime? Do { get; set; }
}