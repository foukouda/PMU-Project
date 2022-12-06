using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMU
{
    class Program
    {
        static Plateau ChargerSauvegarde() {
            Plateau plateau = Plateau.Charger();
            return plateau;
        }

        static Plateau CreerNouvellePartie() {
            // demande nombre joueurs
            // vérifie que le nombre est entre 2 et 4
            // demande nom de chaque joueur

            Console.WriteLine("Combien de joueurs ?");
            int nbJoueurs = int.Parse(Console.ReadLine());
            if (nbJoueurs < 2 || nbJoueurs > 4) {
                Console.WriteLine("Nombre de joueurs invalide");
                return CreerNouvellePartie();
            }
            Joueur[] joueurs = new Joueur[nbJoueurs];
            for (int i = 0; i < nbJoueurs; i++)
            {
                Console.WriteLine("Nom du joueur " + (i + 1) + " ?");
                string nom = Console.ReadLine();
                joueurs[i] = new Joueur(nom);
            }

            Plateau plateau = new Plateau(joueurs);
            plateau.Sauvegarder();
            return plateau;
        }
        static Plateau InitPartie()
        {
            if (!File.Exists("partie.csv"))
            {
                return CreerNouvellePartie();
            }
            Console.WriteLine("Une sauvegarde est disponible, voulez-vous la charger ? (o/n)");
            string reponse = Console.ReadLine();
            if (reponse == "o")
            {
                return ChargerSauvegarde();
            } else if (reponse == "n")
            {
                return CreerNouvellePartie();
            } else
            {
                Console.WriteLine("Réponse invalide.");
                return InitPartie();
            }
        }

        // Demande le nombre de joueurs
        // Puis un nom pour chaque joueur
        static Joueur[] DemanderJoueurs() {
            Console.WriteLine("Combien de joueurs ?");
            int nbJoueurs = int.Parse(Console.ReadLine());
            Joueur[] joueurs = new Joueur[nbJoueurs];
            for (int i = 0; i < nbJoueurs; i++)
            {
                Console.WriteLine("Nom du joueur " + (i + 1) + " ?");
                joueurs[i] = new Joueur(Console.ReadLine());
            }
            return joueurs;
        }
        static void Main(string[] args)
        {    
            Console.Clear();
            bool continuer = true;
            Plateau plateau = InitPartie();
            while (continuer)
            {
                plateau.JouerPartie();
                Console.WriteLine("Nouvelle partie ? (o/n)");
                string reponse = Console.ReadLine();
                if (reponse == "n")
                {
                    continuer = false;
                }
            }
        }
    }
}

