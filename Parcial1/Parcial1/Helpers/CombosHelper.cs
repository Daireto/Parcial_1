using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parcial1.Data;

namespace Parcial1.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboEntrancesAsync()
        {
            List<SelectListItem> list = await _context.Entrances
                .Select(e => new SelectListItem
                {
                    Text = e.Description,
                    Value = $"{e.Id}"
                })
                .OrderBy(e => e.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "Selecciona una entrada",
                Value = "0"
            });

            return list;
        }
    }
}
