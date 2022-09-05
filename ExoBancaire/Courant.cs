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

            set
            {
                if (value >= 0 && value >= -Solde) _ligneDeCredit = value;
            }
        }
        #endregion

        #region Méthodes
        public override void Retrait(double montant)
        {
            base.Retrait(montant, LigneDeCredit);
        }

        protected override double CalculInteret()
        {
            if (Solde >= 0) return Solde * 0.03;
            return Solde * 0.0975;
        }
        #endregion
    }
}
