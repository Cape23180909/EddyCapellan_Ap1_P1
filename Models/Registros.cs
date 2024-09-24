using System.ComponentModel.DataAnnotations;

namespace EddyCapellan_Ap1_P1.Models;

    public class Registros
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Favor colocar un nombre.")]
        public string? Nombre { get; set; }
    }

