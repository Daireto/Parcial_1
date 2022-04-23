using Microsoft.AspNetCore.Mvc.Rendering;

namespace Parcial1.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync();
    }
}
