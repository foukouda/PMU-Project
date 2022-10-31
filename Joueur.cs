using System;

namespace PMU
{
    public class Joueur
    {
        public string Nom { get; set; }
        public int NumCheval { get; set; }
        public int paris { get; set; }
        public bool Gagnant { get; set; }
        public Joueur (string nom, int numCheval, int paris, bool gagnant)
         {
            this.Nom = nom;
            this.NumCheval = numCheval;
            this.paris = paris;
            this.Gagnant = gagnant;
            Console.WriteLine("nouveaux joueur créer");
         }
    }
}
