﻿namespace ScoreBoard.Models
{
    public interface IJoueurRepository
    {
        public IEnumerable<Joueur> ListeJoueurs { get; }
        public Joueur? GetJoueur(int id);
        public void Modifier(Joueur joueur);
        public void Supprimer(int id);
    }
}
