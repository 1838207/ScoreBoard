using Microsoft.AspNetCore.Mvc;
using ScoreBoard.Models;

namespace ScoreBoard.Controllers
{
    public class JoueurController : Controller
    {
        private IJoueurRepository _joueurRepository;
        /// <summary>
        /// Constructeur du controlleur.
        /// </summary>
        /// <param name="joueurRepository">L'implémentation de l'interface de joueurs.</param>
        public JoueurController(IJoueurRepository joueurRepository)
        {
           this._joueurRepository = joueurRepository;
        }

        public ActionResult Index()
        {
            return View(_joueurRepository.ListeJoueurs);
        }
    }
}
