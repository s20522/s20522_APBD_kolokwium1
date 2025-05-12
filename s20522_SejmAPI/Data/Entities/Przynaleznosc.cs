namespace s20522_SejmAPI.Data.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Przynaleznosc")]
public class Przynaleznosc
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int PartiaId { get; set; }

    [Required]
    public int PolitykId { get; set; }

    [Required]
    public DateTime Od { get; set; }

    public DateTime? Do { get; set; }
    
    [ForeignKey(nameof(PartiaId))]
    public virtual Partia Partia { get; set; } = null!;

    [ForeignKey(nameof(PolitykId))]
    public virtual Polityk Polityk { get; set; } = null!;
}