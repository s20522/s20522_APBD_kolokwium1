namespace s20522_SejmAPI.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Polityk")]
public class Polityk
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Imie { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string Nazwisko { get; set; } = null!;

    [MaxLength(200)]
    public string? Powiedzenie { get; set; }

    public virtual ICollection<Przynaleznosc> Przynaleznosci { get; set; } = new List<Przynaleznosc>();
}