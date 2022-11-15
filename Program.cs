using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMU
{
    class Program
    {
        
        static void Main(string[] args)
        {   
        Cartes.MelangePileCartes(Cartes.CreationPileCartes());
        Cartes.AffichePileCartes(Cartes.MelangePileCartes(Cartes.CreationPileCartes()));
        }
    }
}

