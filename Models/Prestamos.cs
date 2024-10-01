using System.ComponentModel.DataAnnotations;

namespace EddyCapellan_Ap1_P1.Models;

public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }
    [Required(ErrorMessage = "Favor colocar el nombre del deudor.")]
    public string? Deudor { get; set; }
    [Required(ErrorMessage = "Favor colocar el concepto.")]
    public string? Concepto { get; set; }
    [Required(ErrorMessage = "Favor colocar el monto.")]
    public decimal? Monto { get; set; }

}