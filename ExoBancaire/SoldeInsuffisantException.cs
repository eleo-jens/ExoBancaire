using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    class SoldeInsuffisantException: ArgumentOutOfRangeException
    {
        // private set car on lit juste l'information via une exception
        public double SoldeActuel { get; private set; }
        public double MontantDemande { get; private set; }
        public double Limite { get; private set; }
        public SoldeInsuffisantException() : base("Votre solde est insuffisant") //message par défault si je ne met rien en parametre du throw
        {

        }
        public SoldeInsuffisantException(string message) : base(message)
        {

        }
        public SoldeInsuffisantException(double montant, double solde, double limite) : this()
        {
            SoldeActuel = solde;
            MontantDemande = montant;
            Limite = limite;
            // pour ensuite pouvoir par exemple calculer combien il manque au solde pour pouvoir faire le retrait
           
        }
    }
}
