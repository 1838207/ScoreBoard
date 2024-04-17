namespace ScoreBoard.Models
{
    public class DbJeuRep : IJeuRepository
    {
        private readonly AppDbContext _context;

        public DbJeuRep(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Jeu> ListeJeux => _context.Jeux.ToList();

        public Jeu GetJeu(int id)
        {
            return _context.Jeux.FirstOrDefault(e => e.Id == id);
        }

        public void Modifier(Jeu jeu)
        {
            _context.Jeux.Update(jeu);
            _context.SaveChanges();
        }

        public void Supprimer(int id)
        {
            _context.Jeux.Remove(GetJeu(id));
            _context.SaveChanges();
        }
    }
}
