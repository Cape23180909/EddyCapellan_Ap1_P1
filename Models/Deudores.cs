using System.ComponentModel.DataAnnotations;

namespace EddyCapellan_Ap1_P1.Models;

public class Deudores
{
    [Key]
    public int DeudorId { get; set; }
    [Required(ErrorMessage = "Favor colocar un nombre.")]
    public string Nombres { get; set; }
}