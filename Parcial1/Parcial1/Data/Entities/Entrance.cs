using System.ComponentModel.DataAnnotations;

namespace Parcial1.Data.Entities
{
    public class Entrance
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        [Display(Name = "Entrada")]
        public string Description { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
