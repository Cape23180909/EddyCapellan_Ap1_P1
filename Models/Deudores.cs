using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EddyCapellan_Ap1_P1.Models;

public class Deudores
{
    [Key]
    public int DeudorId { get; set; }
    [Required(ErrorMessage = "Favor colocar un nombre.")]
    public string Nombres { get; set; }

    [InverseProperty("Deudor")]
    public virtual ICollection<Prestamos> Prestamos { get; set; } = new List<Prestamos>();
}