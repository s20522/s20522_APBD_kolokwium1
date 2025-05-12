namespace s20522_SejmAPI.DTOs;

using System.ComponentModel.DataAnnotations;

public class PolitykCreateDto
{
    [Required(ErrorMessage = "Imię polityka jest wymagane.")]
    [MaxLength(50)]
    public string Imie { get; set; } = null!;

    [Required(ErrorMessage = "Nazwisko polityka jest wymagane.")]
    [MaxLength(100)]
    public string Nazwisko { get; set; } = null!;

    [MaxLength(200)]
    public string? Powiedzenie { get; set; }

    public List<int>? Przynaleznosc { get; set; }
}