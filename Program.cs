using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMU
{
    class Program
    {
               // ! cette methode permet de verifier si le joueur existe deja dans un fichier txt (si oui on recupere les donnes du joueur est les renvoie)
         // ! le fichier txt ce resume comme cela :
         // ! nom du joueur; nombre de partie joué; nombre de partie gagné
         // ! exemple : dimitry ; 5 ; 2

        public string joueurExisteFichier(string nom)
            {
                int nombrepartie = -1;
                int nombrevictoire = -1;
                FileStream fs = new FileStream("joueur.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs);
                string ligne = sr.ReadLine();
                while (ligne != null)
                {
                    string[] tab = ligne.Split(';');
                    if (tab[0] == nom)
                    {
                        nombrepartie = int.Parse(tab[1]);
                        nombrevictoire = int.Parse(tab[2]);
                    }
                    ligne = sr.ReadLine();
                }
                sr.Close();
                fs.Close();
                return (nombrepartie, nombrevictoire);
            }


        // ! méthode qui créer le joueur et qui l'ajoute dans le fichier txt 
        // ! si le joueur existe deja on ajoute 1 au nombre de partie joué 
        // ! si le joueur n'existe pas on l'ajoute dans le fichier txt avec 1 partie joué et 0 partie gagné
        // ! est utilise la methode joueurExisteFichier pour verifier si le joueur existe deja


        public Joueur CreationJoueur()
        {
            bool init_partie = false;
            int nombrepartie;
            int nombrevictoire;
            int numCheval;
            int paris;
            bool gagnant;
            
            string nomJoueur = SaisirNom();
            if(joueurExisteFichier(nomJoueur) != (-1,-1))
                {
                    do{
                        (int,int) donnéesJoueur = joueurExisteFichier(nomJoueur);
                        Console.WriteLine("Voulez vous récupérer vos données ? (oui/non)");
                        string reponse = Console.ReadLine();
                        if (reponse == "oui")
                        {
                            nombrepartie = donnéesJoueur[0];
                            nombrevictoire = donnéesJoueur[1];
                            init_partie = true;
                        }
                        if (reponse == "non")
                        {
                            nombrepartie = 0;
                            nombrevictoire = 0;
                            init_partie = true;
                        }
                        else 
                        {
                            Console.WriteLine("Veuillez saisir oui ou non");
                        }
                    }while(init_partie == false);
                }
                else
                {
                    nombrepartie = 0;
                    nombrevictoire = 0;
                    init_partie = true;
                }

            numCheval = SaisirNumCheval();
            paris = SaisirParis();
            gagnant = false;
            Joueur joueur = new Joueur(nomJoueur, numCheval, paris, gagnant , nombrepartie, nombrevictoire);
            return joueur;
        }
           
        // ! méthode qui permet de saisir le nom du joueur et vérifier si il n'est pas vide
        public string SaisirNom()
        {
            Console.WriteLine("Saisir le nom du joueur : ");
            string nom = "";
                do{
                    nom = Console.ReadLine();
                    if(nom == "")
                    {
                        Console.WriteLine("Le nom ne peut pas être vide");
                    }
                }while (nom == "");
            return nom;
        }
        // ! méthode qui permet de saisir le numéro du cheval
        public int SaisirNumCheval()
        {
            int numCheval;
            Console.WriteLine("donnez le numéro du cheval");
            do
            {
                numCheval = int.Parse(Console.ReadLine());
                if (numCheval < 1 || numCheval > 4)
                {
                    Console.WriteLine("le numéro du cheval doit etre compris entre 1 et 4. Veuillez recommencer");
                }
            } while (numCheval < 1 || numCheval > 4);
            return numCheval;
        }
        //! créer une méthode qui permet de saisir le montant du pari
        public int SaisirParis()
        {
            int paris;
            Console.WriteLine("donnez le montant du pari");
            do
            {
                paris = int.Parse(Console.ReadLine());
                if (paris < 1)
                {
                    Console.WriteLine("le montant du pari doit etre supérieur à 0");
                }
            } while (paris < 1);
            return paris;
        }
        
        static void Main(string[] args)
        {    
            Joueur test = new Joueur();
        }
    }
}

