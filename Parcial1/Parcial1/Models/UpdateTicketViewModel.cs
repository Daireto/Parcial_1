using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models
{
    public class UpdateTicketViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(20, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        [Display(Name = "Documento")]
        public string Document { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} no debe superar los {1} caracteres")]
        [Display(Name = "Nombre completo")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, 4, ErrorMessage = "Debes seleccionar una entrada")]
        [Display(Name = "Entrada")]
        public int EntranceId { get; set; }

        public IEnumerable<SelectListItem> Entrances { get; set; }
    }
}
