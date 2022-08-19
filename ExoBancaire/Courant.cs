using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    class Courant
    {
        #region Champs
        private double _solde;
        private double _ligneDeCredit;
        private Personne _titulaire;
        private string _numero;
        #endregion

        #region Propriétes
        public string Numero {
            get 
            { 
                return _numero; 
            }
            set 
            { 
                // couche de sécurité: vérifier si la chaine n'est pas vide et n'a pas de White Space
                if (!string.IsNullOrWhiteSpace(value)) _numero = value; 
            } 
        } 
        public double Solde 
        {
            get 
            {
                return _solde;
            }

            private set 
            {
                if (value >= -LigneDeCredit) _solde = value; 
            }
        }

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

        public Personne Titulaire {
            get { return _titulaire; }
            set
            {
                // on vérifie si le titulaire qu'on passe au compte existe, c'est-à-dire n'est pas null
                if (value != null) _titulaire = value;
            }
        }
        #endregion

        #region Méthodes
        public void Retrait(double montant)
        {
            if (montant > 0 && (Solde - montant >= -LigneDeCredit))
            {
                Solde = Solde - montant;
            }
        }

        public void Depot(double montant) 
        {
            if (montant > 0)
            {
                Solde = Solde + montant;
            }
        }
        #endregion
    }
}
