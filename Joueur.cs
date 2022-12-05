using System;

namespace PMU
{
    // ! cette classe permet de gerer les joueurs 
    // ! elle permet de saisir le nom du joueur, le numero du cheval et le montant du pari
    // ! ci le joueur existe deja on recupere c'est donnes (du nombre de partie joué et du nombre de partie gagné ainsi que le cheval ) 
    // ! sinon on crée un nouveau joueur
    public class Joueur
    {

        #region Getters and Setters
        public string Nom { get; set; }
        public int NumCheval { get; set; }
        public int paris { get; set; }
        public bool Gagnant { get; set; }
        public int nombrepartie { get; set; }
        public int nombrevictoire { get; set; }

        #endregion

        #region Constructeurs
        public Joueur () /// Constructeur débug
            {
                this.Nom = "test";
                this.NumCheval = 2;
                this.paris = 3;
                this.Gagnant = false;
                this.nombrepartie = 3;
                this.nombrevictoire = 0;
            }

        public Joueur (string nom) // Constructeur nouveau joueur
            {
                this.Nom = nom;
                this.nombrepartie = 0;
                this.nombrevictoire = 0;
            }

        public Joueur (string nom, int numCheval, int paris, bool gagnant, int nombrepartie, int nombrevictoire) // Constructeur joueur existant
            {
                this.Nom = nom;
                this.NumCheval = numCheval;
                this.paris = paris;
                this.Gagnant = gagnant;
                this.nombrepartie = nombrepartie;
                this.nombrevictoire = nombrevictoire;
            }

        #endregion
        
    }
}
