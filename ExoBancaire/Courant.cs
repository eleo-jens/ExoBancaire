using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    class Courant : Compte
    {
        #region Champs
        private double _ligneDeCredit;
        #endregion

        #region Propriétes
        public double LigneDeCredit
        {
            get 
            { 
                return _ligneDeCredit;  
            }

            private set
            {
                //if (value >= 0 && value >= -Solde)
                if (value < 0 && value < -Solde)
                    throw new InvalidOperationException($"La valeur de la ligne de crédit {value} est inférieure à 0.");
                _ligneDeCredit = value;
            }
        }
        #endregion

        #region Constructeur
        public Courant(string numero, Personne titulaire) : base (numero, titulaire) { }

        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit) : base (numero, titulaire, solde)
        {
            LigneDeCredit = ligneDeCredit;
        }
        #endregion

        #region Méthodes
        public override void Retrait(double montant)
        {
            double ancienSolde = Solde;
            base.Retrait(montant, LigneDeCredit);
            if (ancienSolde >= 0 && Solde < 0)
            {
                ActiverPassageEnNegatif(this);
            }

        }

        protected override double CalculInteret()
        {
            if (Solde >= 0) return Solde * 0.03;
            return Solde * 0.0975;
        }
        #endregion
    }
}
