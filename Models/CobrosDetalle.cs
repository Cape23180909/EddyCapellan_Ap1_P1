using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EddyCapellan_Ap1_P1.Models;

public class CobrosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "Favor seleccionar un cobro.")]
    public int CobroId { get; set; }

    [ForeignKey("CobroId")]
    public Cobros Cobro { get; set; }

    [Required(ErrorMessage = "Favor seleccionar un préstamo.")]
    public int PrestamoId { get; set; }

    [ForeignKey("PrestamoId")]
    public Prestamos Prestamo { get; set; }

    [Required(ErrorMessage = "Favor colocar el valor cobrado.")]
    public decimal ValorCobrado { get; set; }

}