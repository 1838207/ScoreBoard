using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Jeu> Jeux { get; set; }
        public DbSet<Joueur> Joueurs { get; set; }
    }
}
