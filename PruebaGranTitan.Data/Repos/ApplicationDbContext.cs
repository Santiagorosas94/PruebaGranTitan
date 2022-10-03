using Microsoft.EntityFrameworkCore;
using PruebaGranTitan.Domain;


namespace PruebaGranTitan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Roulette> Roulette { get; set; }        
        public DbSet<Bet> Bet { get; set; }
        public DbSet<Number> Number { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<ResultBet> ResultBet { get; set; }
    }
}
