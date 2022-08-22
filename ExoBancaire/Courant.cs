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
                Solde = Solde - montant;
        }

        public void Depot(double montant) 
        {
            if (montant > 0)
                Solde = Solde + montant;
        }

        public static double operator +(Courant compte1, Courant compte2)
        {
            double compte1_solde = 0, compte2_solde = 0;
            if (compte1 != null && compte1.Solde > 0)
                compte1_solde = compte1.Solde;
            if (compte2 != null && compte2.Solde > 0)
                compte2_solde = compte2.Solde;

            // Autre facon d'écrire: avec une ternaire: 
            //double compte1_solde = (compte1 != null && compte1.Solde > 0)? compte1.Solde : 0;
            //double compte2_solde = (compte2 != null && compte2.Solde > 0)? compte2.Solde : 0;
            return compte1_solde + compte2_solde;
        }

        public static double operator +(double left, Courant right)
        {
            double left_solde = 0, right_solde = 0;
            if (left > 0)
                left_solde = left;
            if (right != null && right.Solde > 0)
                right_solde = right.Solde;

            // Autre facon d'écrire: avec une ternaire: 
            //double left_solde = (left > 0)? left : 0;
            //double right_solde = (right != null && right.Solde > 0)? right.Solde : 0;
            return left_solde + right_solde;
        }
        #endregion
    }
}
