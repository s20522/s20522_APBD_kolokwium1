namespace s20522_SejmAPI.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Partia")]
public class Partia
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(300)]
    public string Nazwa { get; set; } = null!;

    [MaxLength(10)]
    public string? Skrot { get; set; } // Nullable

    [Required]
    public DateTime DataZalozenia { get; set; }
    public virtual ICollection<Przynaleznosc> Przynaleznosci { get; set; } = new List<Przynaleznosc>();
}