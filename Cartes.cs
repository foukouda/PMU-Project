using System;

namespace PMU
{
    public class Cartes
    {
        public string Couleur { get; set; }
        public int Valeur { get; set; }
        public bool passage { get; set; }
        public Cartes (string couleur, int valeur, bool passage)
         {
            this.Couleur = couleur;
            this.Valeur = valeur;
            this.passage = passage;
         }

         // créer une methode qui permet de créer une pile de 52 cartes différentes de façon aléatoire
        public static Cartes[] CreationPileCartes()
        {
            Cartes[] pileCartes = new Cartes[52];
            int i = 0;
            while (i < 52)
            {
                for(int j = 0; j < 4; j++)
                {
                    for(int k = 0; k < 13; k++)
                    {
                        pileCartes[i] = new Cartes(CouleurCarte(j), k+1 , false);
                        i++;
                    }
                }
            }
            return pileCartes;
        }
        // créer une métodes qui récupere les cartes de créationpilecarte et les mélange et les mes dans une nouvelle liste de carte et la renvoie
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
// créer une methode qui lie la methode melangepilecarte et affiche toutes les cartes 
        public static void AffichePileCartes(Cartes[] pileCartes)
        {
            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(pileCartes[i].Couleur + " " + pileCartes[i].Valeur);
            }
        }
        // créer une methode qui permet de créer une couleur de carte 
        public static string CouleurCarte(int j)
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
            return couleur;
        }
    }
}
