using System;

namespace PMU
{
    public class cartes
    {
        public string Couleur { get; set; }
        public int Valeur { get; set; }
        public bool passage { get; set; }
        public cartes (string couleur, int valeur, bool passage)
         {
            this.Couleur = couleur;
            this.Valeur = valeur;
            this.passage = passage;
            Console.WriteLine("nouvelle carte créer");
         }

         // créer une methode qui permet de créer une pile de 52 cartes différentes de façon aléatoire
        public static cartes[] CreationPileCartes()
        {
            cartes[] pileCartes = new cartes[52];
            int i = 0;
            while (i < 52)
            {
                for(int j = 0; j < 4; j++)
                {
                    for(int k = 0; k < 13; k++)
                    {
                        pileCartes[i] = new cartes(CouleurCarte(j), ValeurCarte(k), false);
                        i++;
                    }
                }
            }
            return pileCartes;
        }
        // créer une methode qui recupere une carte aléatoire dans la pile de carte et la renvoie avec un bool passage = true pour ne pas la reutiliser ci la carte est deja true retirer la carte de la pile et tiré une autre carte
        public static cartes TirageCarte(cartes[] pileCartes)
        {
            Random random = new Random();
            int i = random.Next(0, 52);
            cartes carte = pileCartes[i];
            if (carte.passage == true)
            {
                pileCartes[i] = null;
                carte = TirageCarte(pileCartes);
            }
            else
            {
                carte.passage = true;
            }
            return carte;
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
// créer une methode qui permet de créer une valeur de carte 
        public static int ValeurCarte(int k)
        {
            int valeur = 0;
            switch (k)
            {
                case 0:
                    valeur = 1;
                    break;
                case 1:
                    valeur = 2;
                    break;
                case 2:
                    valeur = 3;
                    break;
                case 3:
                    valeur = 4;
                    break;
                case 4:
                    valeur = 5;
                    break;
                case 5:
                    valeur = 6;
                    break;
                case 6:
                    valeur = 7;
                    break;
                case 7:
                    valeur = 8;
                    break;
                case 8:
                    valeur = 9;
                    break;
                case 9:
                    valeur = 10;
                    break;
                case 10:
                    valeur = 11;
                    break;
                case 11:
                    valeur = 12;
                    break;
                case 12:
                    valeur = 13;
                    break;
            }
            return valeur;
        }
    }
}
