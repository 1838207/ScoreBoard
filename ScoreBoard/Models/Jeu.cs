using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Jeu
    {
        // Ajoute la liste de résultats de validation.
        List<ValidationResult> resultats = new List<ValidationResult>();

        private int _joueurId;

        [Required(ErrorMessage="Le champ Id est requis.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ Nom est requis.")]
        public string Nom { get; set; }

        [Display(Name="Date de sortie")]
        [DataType("Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "Le champ Date de sortie est requis.")]
        public DateTime DateSortie { get; set; }

        [Required(ErrorMessage = "Le champ Description est requis.")]
        public string Description { get; set; }

        [Display(Name ="Id du joueur")]
        [Required(ErrorMessage = "Le champ Id du joueur est requis.")]
        public int JoueurId 
        { 
            get
            {
                return _joueurId;        // TODO : Voir si c'est une bonne façon de faire.
            }
            set
            {
                if(value == Joueur.Id)
                {
                    _joueurId = Joueur.Id;
                }
                else
                {
                    resultats.Add(new ValidationResult(
                        "L'Id du joueur est invalide."
                        ));
                }
            }
        }

        [Required(ErrorMessage = "Le champ Joueur est requis.")]
        public Joueur Joueur { get; set; }

        [Display(Name ="Score du joueur")]
        [Required(ErrorMessage = "Le champ Score du joueur est requis.")]
        [Range(0, 100, ErrorMessage ="Le score doit être entre 0 et 100.")]
        public int ScoreJoueur { get; set; }

        [Display(Name ="Date d'enregistrement")]
        [DataType("Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Required(ErrorMessage = "Le champ Date d'enregistrement est requis.")]
        public DateTime DateEnregistrement { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateEnregistrement >= DateTime.Now)
            {
                resultats.Add(new ValidationResult("La date d'enregistrement doit être avant la date d'aujourd'hui.",
                        new[] { "DateEnregistrement" }
                        ));
            }
            if(DateSortie >= DateTime.Now)
            {
                resultats.Add(new ValidationResult("La date de sortie doit être avant la date d'aujourd'hui.",
                        new[] { "DateSortie" }
                        ));
            }
            return resultats;
        }
    }
}
