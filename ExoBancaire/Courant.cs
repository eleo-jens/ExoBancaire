using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    class Courant
    {
        public string Numero { get; set; }

        private double _solde;
        public double Solde 
        {
            get 
            {
                return _solde;
            }

            private set 
            { 
                _solde = value; 
            }
        }

        private double _ligneDeCredit;
        public double LigneDeCredit
        {
            get 
            { 
                return _ligneDeCredit;  
            }

            set
            {
                if (value >= 0) _ligneDeCredit = value;
            }
        }

        public Personne Titulaire { get; set; }

        public void Retrait(double Montant)
        {
            if (Solde - Montant >= -LigneDeCredit)
            {
                Solde = Solde - Montant;
            }
        }

        public void Depot(double Montant) 
        {
            Solde = Solde + Montant;
        }
    }
}
