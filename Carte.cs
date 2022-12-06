using System;

namespace PMU
{
    // ! La classe carte contient les infos pour une carte en particulier
    public class Carte
    {
        public ConsoleColor Couleur { get; set;} // rouge ou blanc
        public string Famille { get; set; } // coeur,carreau,pique,trefle
        public int Valeur { get; set; }

        public string[] Lines {get; set; }

        public Carte (string famille, int valeur)
         {
            // si la famille est coeur ou carreau, on met la couleur en rouge, sinon on met la couleur en blanc (car le fond est déjà noir).
            this.Couleur = (famille == "coeur" || famille == "carreau") ? ConsoleColor.Red : ConsoleColor.White;
            this.Famille = famille;
            this.Valeur = valeur;

            string chemin = "assets/" + famille + valeur + ".txt";

            // les cartes sont stockées au format vertical, on les veut au format horizontal ici.
            this.Lines = File.ReadAllLines(chemin);
         }

        // on affiche une ligne de la carte
        // on affiche la ligne en blanc si la couleur est rouge, sinon on affiche la ligne en rouge.
        // on ne retourne pas à la ligne car on veut pouvoir afficher quelque chose après la carte sur la ligne.
        public void AfficherLigne(int ligne)
        {
            Console.ForegroundColor = Couleur;
            Console.Write(Lines[ligne]);
            Console.ResetColor();
        }

        public static Carte[] GenererPioche() {
            Carte[] pioche = new Carte[52];
            int i = 0;
            foreach (string famille in new string[] { "coeur", "carreau", "pique", "trefle" })
            {
                for (int valeur = 1; valeur <= 13; valeur++)
                {
                    pioche[i] = new Carte(famille, valeur);
                    i++;
                }
            }

            // on mélange la pioche
            Random random = new Random();
            for (int j = 0; j < pioche.Length; j++)
            {
                int k = random.Next(pioche.Length);
                Carte temp = pioche[j];
                pioche[j] = pioche[k];
                pioche[k] = temp;
            }

            return pioche;
        }
    }
}
