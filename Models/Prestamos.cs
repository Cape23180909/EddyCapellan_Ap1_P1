using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EddyCapellan_Ap1_P1.Models;

public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }

    [Required(ErrorMessage = "Favor seleccionar un deudor.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un deudor válido.")]
    public int DeudorId { get; set; }

    [ForeignKey("DeudorId")]
    public Deudores Deudor { get; set; }

    [Required(ErrorMessage = "Favor colocar el concepto.")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "Favor colocar el monto.")]
    public decimal? Monto { get; set; }

    [Required(ErrorMessage = "Favor colocar el balance.")]
    public decimal? Balance { get; set; }
}