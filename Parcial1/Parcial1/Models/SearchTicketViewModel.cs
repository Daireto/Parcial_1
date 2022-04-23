using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Parcial1.Models
{
    public class SearchTicketViewModel
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int Id { get; set; }
    }
}
