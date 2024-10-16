using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EddyCapellan_Ap1_P1.Models;
public class Cobros
{
    [Key]
    public int CobroId { get; set; }
    [Required(ErrorMessage ="Favor colocar una fecha.")]
    public DateTime? Fecha { get; set; }
    [Required(ErrorMessage = "Favor seleccionar un deudor.")]
    [Range(1, int.MaxValue, ErrorMessage = "Favor seleccionar un deudor válido.")]
    public int DeudorId { get; set; }
    [ForeignKey("DeudorId")]
    public Deudores Deudor { get; set; }

    [Required(ErrorMessage = "Favor colocar el monto del cobro.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
    public decimal Monto { get; set; }

    public List<CobrosDetalle> CobroDetalles { get; set; } = new List<CobrosDetalle>();
}