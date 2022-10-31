using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMU
{
    class Program
    {
        // créer une methode verifiant qu'un entier est positif et le revoie 
        static int SaisieEntierPositif()
        {
            int entier;
            do
            {
                entier = int.Parse(Console.ReadLine()+"");
            } while (entier < 0);
            return entier;
        }
        // créer une methode qui permet de saisir le nombre de joueur prenant en entrée la methode SaisiEntierPositif et le revoie
        static int SaisieNombreJoueur()
        {
            int nombreJoueur;
            Console.WriteLine("donnez le nombre joueur entre 2 et 10");
            do
            {
                nombreJoueur = SaisieEntierPositif();
                if( nombreJoueur < 2 || nombreJoueur > 10)
                {
                    Console.WriteLine("le nombre de joueur doit etre compris entre 2 et 10");
                }
            } while (nombreJoueur < 2 || nombreJoueur > 10);
            return nombreJoueur;
        }
        // créer une methode qui permet de saisir le nombre de chevaux entre 2 inclu et 4 inclu prenant en entrée la methode SaisiEntierPositif et le revoie 
        static int SaisieNombreChevaux()
        {
            int nombreChevaux;
            Console.WriteLine("donnez le nombre de chevaux entre 2 et 4");
            do
            {
                nombreChevaux = SaisieEntierPositif();
                if (nombreChevaux < 2 || nombreChevaux > 4)
                {
                    Console.WriteLine("le nombre de chevaux doit etre compris entre 2 et 4");
                }
            } while (nombreChevaux < 2 || nombreChevaux > 4);
            return nombreChevaux;
        }
        // créer une methode qui crée un tableau de joueur prenant en entrée le nombre de joueur et le revoie
        static Joueur[] CreationTableauJoueur(int nombreJoueur, string SaisieNomJoueur, int SaisieNumCheval, int SaisieMontantPari)
        {
            Joueur[] tableauJoueur = new Joueur[nombreJoueur];
            for (int i = 0; i < nombreJoueur; i++)
            {
               string nom = SaisieNomJoueur;
               int numCheval = SaisieNumCheval;
               int paris = SaisieMontantPari;
               bool gagnant = false;
               tableauJoueur[i] = new Joueur(nom, numCheval, paris, gagnant);           
            }
            return tableauJoueur;
        }
        // créer une methode qui permet de saisir le nom d'un jouer et le renvoie
        static string SaisieNomJoueur()
        {
            string nomJoueur;
            Console.WriteLine("donnez le nom du joueur");
            nomJoueur = "" + Console.ReadLine();
            return nomJoueur;
        }
        // créer une methode qui permet de saisir le numero du cheval et le renvoie
        static int SaisieNumCheval(int nombreChevaux) // j'appel le nombreChevaux defini avant pour éviter le probleme de saisie 
        {
            int a = nombreChevaux;
            int numCheval;
                if(a == 2)
                {
                    Console.WriteLine("donnez le numero du cheval entre 1 == carreau // 2 == coeur");
                }
                else if(a == 3)
                {
                    Console.WriteLine("donnez le numero du cheval entre 1 == carreau // 2 == coeur // 3 == pique");
                }
                else if(a == 4)
                {
                    Console.WriteLine("donnez le numero du cheval entre 1 == carreau // 2 == coeur // 3 == pique // 4 == trefle");
                }
                    do
                    {   
                    numCheval = SaisieEntierPositif();
                        if (numCheval < 1 || numCheval > a)
                        {
                            Console.WriteLine("le numero du cheval doit etre compris entre 1 et " + a);
                        }
                    } while (numCheval < 1 || numCheval > a);
            return numCheval;
        }
        // créer une methode qui permet de saisir le montant du pari et le renvoie
        static int SaisieMontantPari()
        {
            int montantPari;
            Console.WriteLine("donnez le montant du pari");
            montantPari = SaisieEntierPositif();
            return montantPari;
        }
        static void Main(string[] args)
        {   
          int nombreJoueur = SaisieNombreJoueur();
          int nombreChevaux = SaisieNombreChevaux(); 
          CreationTableauJoueur(nombreJoueur, SaisieNomJoueur(), SaisieNumCheval(), SaisieMontantPari());
        }
    }
}
