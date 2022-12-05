using System;

namespace PMU
{
    // ! Cette classe est une classe qui contient le jeu de cartes (les 52 cartes sont crées procéduralement est stocker dans une pile ou il sont melanger et distribuer 
    // ! chaque carte on attribue un string pour pouvoir l'associer a une image .txt qui contient les donnez de limage en Hexadecimal qui sont lis par le programme 
    public class Cartes 
    {
        public string Couleur { get; set; } // TODO : Couleur de la carte
        public int Valeur { get; set; } // TODO : Valeur de la carte
        public bool passage { get; set; } // TODO : Permet de savoir si la carte a deja etait distribuer ou non
        public Cartes (string couleur, int valeur, bool passage)
         {
            this.Couleur = couleur;
            this.Valeur = valeur;
            this.passage = passage;
         }

         // ! méthode qui permet de créer les 52 cartes procéduralement et les stocke dans une pile 
        public static Cartes[] CreationPileCartes()
        {
            Cartes[] pileCartes = new Cartes[52];
            int i = 0;
            while (i < 52)
            {
                for(int j = 0; j < 4; j++) // *  if qui donne une couleurs a chaque cartes 
                {
                string couleur = "";
                    switch (j)
                    {
                    case 0:
                        couleur = "coeur";
                        break;
                    case 1:
                        couleur = "carreau";
                         break;
                    case 2:
                        couleur = "pique";
                        break;
                    case 3:
                        couleur = "trefle";
                        break;
                    }
                    for(int k = 0; k < 13; k++) // * if qui donne un chiffre a chaque carte est la créer (le 11, 12 sont des valet, dame et roi) les carte sont false 
                    {
                        pileCartes[i] = new Cartes(couleur, k+1 , false);
                        i++;
                    }
                }
            }
            return pileCartes;
        }

        // ! métthode qui récupère les Cartes de la méthode CreationPileCartes() et les mélange 
        public static Cartes[] MelangePileCartes(Cartes[] pileCartes)
        {
            Cartes[] pileCartesMelange = new Cartes[52];
            Random random = new Random();
            int i = 0;
            while (i < 52)
            {
                int index = random.Next(0, 52);
                if (pileCartes[index].passage == false)
                {
                    pileCartesMelange[i] = pileCartes[index];
                    pileCartes[index].passage = true;
                    i++;
                }
            }
            return pileCartesMelange;
        }
        public static void AfficherCarte(Cartes carte)
        {
            string chemin = @"C:\Users\Public\Documents\PMU\Dossiercarte\" + carte.Couleur + carte.Valeur + ".txt";
            string[] lignes = File.ReadAllLines(chemin);
            foreach (string ligne in lignes)
            {
                Console.WriteLine(ligne);
            }
        }

    }
}
