using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    internal class Epargne : Compte
    {
        #region Champs
        #endregion

        #region Propriétes
        public DateTime DateDernierRetrait { get; set; }
        #endregion

        #region Méthodes
        public override void Retrait(double montant)
        {
            double oldSolde = Solde;
            base.Retrait(montant);
            if (oldSolde < Solde)
                DateDernierRetrait = DateTime.Now;
        }

        protected override double CalculInteret()
        {
            //4.5 %
            return Solde * 0.045;
        }
        #endregion
    }
}
