using System;

namespace PMU
{
    // ! La classe carte contient les infos pour une carte en particulier
    public class Carte
    {
        public ConsoleColor couleur { get;} // rouge ou blanc
        public string Famille { get; } // coeur,carreau,pique,trefle
        public int Valeur { get; }

        public string[] Lines {get; }

        public Carte (string famille, int valeur)
         {
            // si la famille est coeur ou carreau, on met la couleur en rouge, sinon on met la couleur en blanc (car le fond est déjà noir).
            this.couleur = (famille == "coeur" || famille == "carreau") ? ConsoleColor.Red : ConsoleColor.White;
            this.Famille = famille;
            this.Valeur = valeur;

            string chemin = "assets/" + famille + valeur + ".txt";

            // les cartes sont stockées au format vertical, on les veut au format horizontal ici.
            Lines = File.ReadAllLines(chemin);
         }

        // ! méthode qui permet de faire tourner la carte de 90°
        public void TournerCarte90()
        {
            string[] newLines = new string[Lines[0].Length];
            for (int i = 0; i < Lines[0].Length; i++)
            {
                string newLine = "";
                for (int j = 0; j < Lines.Length; j++)
                {
                    newLine += Lines[j][i];
                }
                newLines[i] = newLine;
            }
            Lines = newLines;
        }

        // on affiche une ligne de la carte
        // on affiche la ligne en blanc si la couleur est rouge, sinon on affiche la ligne en rouge.
        // on ne retourne pas à la ligne car on veut pouvoir afficher quelque chose après la carte sur la ligne.
        public void AfficherLigne(int ligne)
        {
            Console.ForegroundColor = couleur;
            Console.Write(lines[ligne]);
            Console.ResetColor();
        }

        public []Carte GenererPioche() {
            Carte[] pioche = new Carte[52];
            int i = 0;
            for (int couleur = 0; couleur < 4; couleur++)
            {
                for (int valeur = 1; valeur <= 13; valeur++)
                {
                    pioche[i] = new Carte(couleur % 2, valeur);
                    i++;
                }
            }
            return pioche;
        }
    }
}
