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

            //Seed for Tickets
            for (int i = 0; i < 5000; i++)
            {
                await CheckTicketsAsync(i);
            }

            //Seed for Entrances
            await CheckEntrancesAsync("Norte");
            await CheckEntrancesAsync("Sur");
            await CheckEntrancesAsync("Oriental");
            await CheckEntrancesAsync("Occidental");
        }

        private async Task CheckEntrancesAsync(string description)
        {
            if (_context.Entrances.Any())
            {
                _context.Add(new Entrance { Description = description });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckTicketsAsync(int id)
        {
            if (_context.Tickets.Any())
            {
                _context.Add(new Ticket { Id = id });
            }
            await _context.SaveChangesAsync();
        }
    }
}
