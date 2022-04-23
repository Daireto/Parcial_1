using System.ComponentModel.DataAnnotations;

namespace Parcial1.Data.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        public bool WasUsed { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        [Display(Name = "Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        [Display(Name = "Nombre completo")]
        public string Name { get; set; }

        [Display(Name = "Fecha y hora de uso")]
        public DateTime? Date { get; set; }

        public Entrance? Entrance { get; set; }
    }
}
