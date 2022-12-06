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
        public string famille_pari { get; set; }
        public int montant_pari { get; set; }
        #endregion

        #region Constructeurs
        public Joueur (string nom) // Constructeur nouveau joueur
            {
                this.Nom = nom;
            }
        #endregion
        

        public void DemanderInfos() {
            Console.Clear();
            Console.WriteLine(this.Nom);
            DemanderFamille();
            DemanderMontant();
        }
        
        // demande une famille de carte
        public void DemanderFamille() {
            Console.WriteLine("Quelle famille de carte voulez-vous parier ? (coeur, carreau, pique, trefle)");
            string famille = Console.ReadLine();
            if (famille == "coeur" || famille == "carreau" || famille == "pique" || famille == "trefle")
            {
                this.famille_pari = famille;
            } else
            {
                Console.WriteLine("Famille invalide.");
                DemanderFamille();
            }
        }

        // demande un montant de pari
        public void DemanderMontant() {
            Console.WriteLine("Combien de pompes voulez-vous parier ?");
            int montant = 0;
            int.TryParse(Console.ReadLine(), out montant);
            // comme montant est 0 en cas d'erreur et 0 n'est pas un montant valide, on peut tester montant directement
            if (montant > 0 && montant < 100)
            {
                this.montant_pari = montant;
            } else 
            {
                Console.WriteLine("Montant invalide.");
                DemanderMontant();
            }
        }

        public string Afficher() {
            string famille = Plateau.EmojiFamille(this.famille_pari);
            return this.Nom + " ( " + this.montant_pari + " : " + famille + " )";
        }
        
    }
}
