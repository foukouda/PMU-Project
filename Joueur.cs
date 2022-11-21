using System;

namespace PMU
{
    // ! cette classe permet de gerer les joueurs 
    // ! elle permet de saisir le nom du joueur, le numero du cheval et le montant du pari
    // ! ci le joueur existe deja on recupere c'est donnes (du nombre de partie joué et du nombre de partie gagné ainsi que le cheval ) 
    // ! sinon on crée un nouveau joueur
    public class Joueur
    {
        public string Nom { get; set; }
        public int NumCheval { get; set; }
        public int paris { get; set; }
        public bool Gagnant { get; set; }
        public int nombrepartie { get; set; }
        public int nombrevictoire { get; set; }
        public Joueur (string nom, int numCheval, int paris, bool gagnant, int nombrepartie, int nombrevictoire)
         {
            this.Nom = nom;
            this.NumCheval = numCheval;
            this.paris = paris;
            this.Gagnant = gagnant;
            this.nombrepartie = nombrepartie;
            this.nombrevictoire = nombrevictoire;

         }

        // ! méthode qui créer le joueur et le compare avec les joueurs existant 
        // ! ci le joueur existe deja on demande ci on recupere c'est donnes (du nombre de partie joué et du nombre de partie gagné ainsi que le cheval )  
        public static Joueur CreationJoueur(string nom, int numCheval, int paris, bool gagnant, int nombrepartie, int nombrevictoire)
        {
            bool init_partie = false;
            string nomJoueur = SaisirNom();
            FileStream f = new FileStream("Joueur.txt", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(f);
            StreamWriter sw = new StreamWriter(f);
            string name = "";
            while ((line = sr.ReadLine()) != null) 
            {
                string[] items = line.Split(';');
                name = items[0];   
                if( name == nomJoueur)
                {
                    Console.WriteLine("Le joueur existe deja");
                    Console.WriteLine("Voulez vous recupere vos données ? (oui/non)");
                    string reponse = Console.ReadLine(); // ! a revoir 
                    if(reponse == "oui")
                    {
                      nomJoueur = name;
                      nombrepartie = items [1] + 1;
                      nombrevictoire = items [2];
                      console.WriteLine("les donnez du joueur on etait recupere");
                      console.WriteLine("le nom du joueur est : " + nomJoueur + "le nombre de partie joué est : " + nombrepartie + "le nombre de partie gagné est : " + nombrevictoire);
                      init_partie =  true;
                    }
                    if(reponse == "non"){
                        console.WriteLine("Veuillez choisir un autre nom:");
                        nomJoueur = SaisirNom(); // ! attention, si le nouveau nom choisi est pris, la redondance est possible. à revoir
                    }
                }
            }
            if (init_partie == false){
                nombrepartie = 1;
                nombrevictoire = 0;
                init_partie =  true;
            }
            nombrepartie = 1;
            nombrevictoire = 0;
            sw.WriteLine(nomJoueur + ";" + nombrepartie + ";" + nombrevictoire);            
            fichier.Close();
            
            Joueur joueur = new Joueur(nomJoueur, SaisirNumCheval(), paris, gagnant, nombrepartie, nombrevictoire);
            return joueur;
        }
        // ! méthode qui permet de saisir le nom du joueur et vérifier si il n'est pas vide

        
        public static string SaisirNom()
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
        public static int SaisirNumCheval()
        {
            int numCheval;
            Console.WriteLine("donnez le numéro du cheval");
            do
            {
                numCheval = int.Parse(Console.ReadLine());
                if (numCheval < 1 || numCheval > 4)
                {
                    Console.WriteLine("le numéro du cheval doit etre compris entre 1 et 4");
                }
            } while (numCheval < 1 || numCheval > 4);
            return numCheval;
        }
        // créer une méthode qui permet de saisir le montant du pari
        public static int SaisirParis()
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
       
    }
}
