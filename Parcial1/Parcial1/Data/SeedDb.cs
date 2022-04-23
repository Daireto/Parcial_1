using Parcial1.Data.Entities;

namespace Parcial1.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTicketsAsync();
            await CheckEntrancesAsync();
        }

        private async Task CheckEntrancesAsync()
        {
            if (!_context.Entrances.Any())
            {
                _context.Add(new Entrance { Description = "Norte" });
                _context.Add(new Entrance { Description = "Sur" });
                _context.Add(new Entrance { Description = "Oriental" });
                _context.Add(new Entrance { Description = "Occidental" });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckTicketsAsync()
        {
            if (!_context.Tickets.Any())
            {
                for (int i = 0; i < 5000; i++)
                {
                    _context.Add(new Ticket
                    {
                        WasUsed = false,
                        Document = "",
                        Name = "",
                        Date = null,
                        Entrance = null
                    });
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}
