using Microsoft.EntityFrameworkCore;

namespace ScoreBoard.Models
{
    public class DbJoueurRep : IJoueurRepository
    {
        private readonly AppDbContext _AppDbContext;

        public DbJoueurRep(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }
        public IEnumerable<Joueur> ListeJoueurs => _AppDbContext.Joueurs.ToList();

        public Joueur GetJoueur(int id)
        {
           return _AppDbContext.Joueurs.Include(j => j.Jeux).FirstOrDefault(x => x.Id == id);
        }

        public void Modifier(Joueur joueur)
        {
            _AppDbContext.Joueurs.Update(joueur);
            _AppDbContext.SaveChanges();
        }

        public void Supprimer(int id)
        {
            _AppDbContext.Joueurs.Remove(GetJoueur(id));
            _AppDbContext.SaveChanges();
        }
    }
}
