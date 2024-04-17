using System.ComponentModel.DataAnnotations;

namespace ScoreBoard.Models
{
    public class Joueur
    {
        // Ajoute la liste de résultats de validation.
        List<ValidationResult> resultats = new List<ValidationResult>();

        private string _courriel;

        [Required(ErrorMessage="Le champ Id est requis.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Le champ Nom est requis.")]
        [MinLength(2, ErrorMessage = "Le nom doit avoir minimalement 2 caractères.")]
        [MaxLength(20, ErrorMessage = "Le nom doit avoir au maximum 20 caractères.")]
        public string Nom { get; set; }

        [Display(Name="Prénom")]
        [Required(ErrorMessage = "Le champ Prénom est requis.")]
        [MinLength(2, ErrorMessage ="Le prénom doit avoir minimalement 2 caractères.")]
        [MaxLength(20, ErrorMessage = "Le prénom doit avoir au maximum 20 caractères.")]
        public string Prenom { get; set; }

        [Display(Name="Équipe")]
        [RegularExpression(@"^[A-Z]{2,4}$", ErrorMessage = "L'équipe doit avoir 2 à 4 lettres majuscules.")]
        public string? Equipe { get; set; }

        [Display(Name ="Téléphone")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Le champ Courriel est requis.")]
        [RegularExpression(@"^[0-9]*@[a-zA-Z]*\.ca$", ErrorMessage ="L'adresse courriel doit être composée de l'identifiant suivi de : @nomdelequipe.ca")]
        public string Courriel {
            get { return this._courriel; }
            set { 
                if(value.Contains(this.Nom.ToLower()))
                {
                    this._courriel = value;
                }
                else {
                    resultats.Add(new ValidationResult(
                        "L'adresse courriel doit être composée de l'identifiant suivi de: @nomdelequipe.ca" +
                        "\nExemple : 15@lions.ca",
                        new[] { "Courriel" }
                        ));
                }
            }
        }

        [Required(ErrorMessage = "Le champ Jeux est requis.")]
        public List<Jeu> Jeux { get; set; }
    }
}
