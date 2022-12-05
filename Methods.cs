using System;

namespace PMU
{
    abstract class Methods
    {

        // créer une méthode qui récupere la touche appuyée par l'utilisateur
        public static ConsoleKeyInfo GetKey()
        {
            ConsoleKeyInfo touche;
            touche = Console.ReadKey();
            return touche;
        }

        // créer une méthode qui affiche le menu et qui récupere la touche appuyée par l'utilisateur
        public static int Menu(string[] options)
        {
            int i = 0;
            int choix = 0;
            while (i < options.Length)
            {
                Console.WriteLine(options[i]);
                i++;
            }
            ConsoleKeyInfo touche;
            touche = Console.ReadKey();
            if (touche.Key == ConsoleKey.UpArrow)
            {
                choix = 1;
            }
            else if (touche.Key == ConsoleKey.DownArrow)
            {
                choix = 2;
            }
            else if (touche.Key == ConsoleKey.Enter)
            {
                choix = 3;
            }
            return choix;
        }

        
    }
}
