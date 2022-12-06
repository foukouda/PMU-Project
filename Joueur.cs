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
        private int montant_gagne;
        private int montant_perdu;
        private int nombre_partie_joue;
        private int nombre_partie_gagne;
        #endregion

        #region Constructeurs
        public Joueur (string nom) // Constructeur nouveau joueur
            {
                this.Nom = nom;
            }
        #endregion

        public void FromCsv(string[] data)
        {
            this.nombre_partie_joue = int.Parse(data[1]);
            this.nombre_partie_gagne = int.Parse(data[2]);
            this.montant_gagne = int.Parse(data[3]);
            this.montant_perdu = int.Parse(data[4]);
        }
        
        public string ToCsv()
        {
            string[] data = new string[5];
            data[0] = this.Nom;
            data[1] = this.nombre_partie_joue.ToString();
            data[2] = this.nombre_partie_gagne.ToString();
            data[3] = this.montant_gagne.ToString();
            data[4] = this.montant_perdu.ToString();
            return string.Join(";", data);
        }

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
            return this.Nom + " ( " + this.montant_pari + " : " + famille + " )" + " a gagné " + this.montant_gagne + " pompes et perdu " + this.montant_perdu + " pompes en " + this.nombre_partie_joue + " parties ( " + this.nombre_partie_gagne + " gagnées )";
        }

        public void PartieTerminee(bool gagne) {
            this.nombre_partie_joue++;
            if (gagne)
            {
                this.nombre_partie_gagne++;
                this.montant_gagne += this.montant_pari;
            } else
            {
                this.montant_perdu += this.montant_pari;
            }
        }
        
    }
}
