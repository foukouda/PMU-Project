using System;

namespace PMU
{
    public class Plateau {
        public Carte[] pioche { get; set; }
        public Dictionary<string, int> progression { get; set; } // progression de chaque famille
        public Joueur[] joueurs { get; set; }
        public int tour { get; set; }
        private string winner = "";


        public Plateau(Joueur[] joueurs)
        {
            this.joueurs = joueurs;
            this.progression = new Dictionary<string, int>();
            
        }

        // charge une partie sauvegardée
        // dans partie.csv, on a le nombre de joueurs en première ligne puis le nom de chaque joueur sur une ligne différente
        public static Plateau Charger() {
            string[] lignes = File.ReadAllLines("partie.csv");
            int nbJoueurs = int.Parse(lignes[0]);
            Joueur[] joueurs = new Joueur[nbJoueurs];
            for (int i = 0; i < nbJoueurs; i++)
            {
                joueurs[i] = new Joueur(lignes[i + 1]);
            }
            
            Plateau plateau = new Plateau(joueurs);
            return plateau;
        }

        public void Sauvegarder() {
            string[] lignes = new string[this.joueurs.Length + 1];
            lignes[0] = this.joueurs.Length.ToString();
            for (int i = 0; i < this.joueurs.Length; i++)
            {
                lignes[i + 1] = this.joueurs[i].Nom;
            }
            File.WriteAllLines("partie.csv", lignes);
        }

        public void JouerPartie() {
            // pour chaque joueur, on lui demande de choisir famille et montant du pari
            this.tour = 0;
            this.winner = "";
            this.pioche = Carte.GenererPioche();
            this.progression = new Dictionary<string, int>();
            foreach (string famille in new string[] { "coeur", "carreau", "pique", "trefle" })
            {
                progression[famille] = 0;
            }

            foreach (Joueur joueur in this.joueurs)
            {
                joueur.DemanderInfos();
            }


            while (this.winner == "") {
                AfficherPlateau();
                Console.WriteLine("Appuyez sur une touche pour tirer une carte.");
                Console.ReadKey();

                JouerTour();
            }

            AfficherPlateau();
            Console.WriteLine("Le gagnant est " + this.winner + " !");
            Console.WriteLine("Appuyez sur une touche pour continuer.");
            Console.ReadKey();

            AfficherFinPartie();
        }


        public void AfficherFinPartie() {
            // pour chaque joueur, on affiche si il a gagné ou perdu
            // si il a gagné, il peut distribuer ses pompes
            // si il a perdu, il doit faire ses pompes
            

            foreach (Joueur joueur in this.joueurs)
            {
                Console.Clear();
                if (joueur.famille_pari == this.winner)
                {
                    Console.WriteLine(joueur.Nom + ", tu as a gagné !");
                    Console.WriteLine("Tu peux distribuer tes " + joueur.montant_pari + " pompes aux autres joueurs.");
                } else {
                    Console.WriteLine(joueur.Nom + ", tu as perdu !");
                    Console.WriteLine("Tu dois faire tes " + joueur.montant_pari + " pompes.");
                }

                Console.WriteLine("Appuyez sur une touche pour continuer.");
                Console.ReadKey();
            }

            Console.Clear();
        }

        public void JouerTour() {
            // on pioche une carte
            Carte carte = this.pioche[this.tour];

            Console.Clear();
            Console.WriteLine("Tour " + this.tour);
            Console.WriteLine("Carte piochée : ");
            // on affiche la carte
            for (int ligne = 0; ligne < carte.Lines.Length; ligne++)
            {
                carte.AfficherLigne(ligne);
                Console.WriteLine();
            }

            // on incrémente la progression de la famille de la carte
            this.progression[carte.Famille] += 1;

            if (this.progression[carte.Famille] == 7) {
                this.winner = carte.Famille;
            }
            
            // on incrémente le tour
            this.tour += 1;

            Console.WriteLine("\n\nAppuyez sur une touche pour continuer...");
            Console.ReadKey();            
        }

        public void AfficherPlateau() {
            Console.Clear();
            Console.WriteLine("Tour " + this.tour);
            foreach (Joueur joueur in this.joueurs)
            {
                Console.WriteLine(joueur.Afficher());
            }

            foreach (string famille in new string[] { "coeur", "carreau", "pique", "trefle" })
            {
                Separateur();
                int prog = this.progression[famille];
                for (int i = 0; i < prog; i++)
                {
                    Console.Write("|     ");
                }

                
                if (prog == 7) Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write("|  ");  
                Console.ForegroundColor = (famille == "coeur" || famille == "carreau") ? ConsoleColor.Red : ConsoleColor.White;
                Console.Write(EmojiFamille(famille));
                Console.Write("  ");
                Console.ForegroundColor = ConsoleColor.White;


                for (int i = prog + 1; i <= 7; i++)
                {
                    if (i == 7) Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Write("|     ");
                }

                Console.WriteLine("|");

                Console.ResetColor();
            }
            Separateur();
        }

        public void Separateur() {
            Console.Write("+-----+-----+-----+-----+-----+-----+-----");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("+-----+");
            Console.ResetColor();
        }

        public static string EmojiFamille(string famille) {
            switch (famille)
            {
                case "coeur":
                    return "♥";
                case "carreau":
                    return "♦";
                case "pique":
                    return "♠";
                case "trefle":
                    return "♣";
                default:
                    return " ";
            }
        }
    }
}