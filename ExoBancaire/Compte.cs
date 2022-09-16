using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    delegate void PassageEnNegatifDelegate(Compte compte);
    internal abstract class Compte : IBanker, ICustomer
    {
        public event PassageEnNegatifDelegate PassageEnNegatifEvent;
        #region Champs
        private Personne _titulaire;
        private string _numero;
        private double _solde;
        #endregion

        #region Propriétes
        public string Numero
        {
            get
            {
                return _numero;
            }
            private set
            {
                // couche de sécurité: vérifier si la chaine n'est pas vide et n'a pas de White Space
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"Le numéro ne peut contenir : {value}");
                _numero = value;
            }
        }
        public double Solde
        {
            get
            {
                return _solde;
            }
        }
        public Personne Titulaire
        {
            get { return _titulaire; }
            private set
            {
                // on vérifie si le titulaire qu'on passe au compte existe, c'est-à-dire n'est pas null
                if (value == null)
                    throw new ArgumentNullException($"Le titulaire ne peut être null!");
                _titulaire = value;

            }
        }
        #endregion

        #region Constructeur
        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        public Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            _solde = solde;
        }
        #endregion

        #region Méthodes et Opérateurs
        // protype de méthode: signature sans instruction
        protected abstract double CalculInteret();
        public void AppliquerInteret()
        {
            _solde += CalculInteret();
        }
        public void Depot(double montant)
        {
            if (montant <= 0)
                throw new ArgumentOutOfRangeException($"Le montant {montant} ne peut pas être déposé car inférieur ou égal à 0!");
            _solde += montant;
        }
        protected void Retrait(double montant, double limite)
        {
            if (montant <= 0)
                throw new ArgumentOutOfRangeException(); // pas besoin de mettre un message car contient déjà un msg par défaut avec le type d'erreur rencontrée
            if (montant > Solde + limite)
                //throw new SoldeInsuffisantException($"Ce montant {montant} ne peut pas etre retiré");
                throw new SoldeInsuffisantException(montant, Solde, limite);
            _solde -= montant;
        }

        public virtual void Retrait(double montant)
        {
            this.Retrait(montant, 0);
        }

        protected void ActiverPassageEnNegatif(Compte compte)
        {
            PassageEnNegatifEvent?.Invoke(compte);
        }

        //METTRE THROW
        public static double operator +(Compte compte1, Compte compte2)
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

        //METTRE THROW
        public static double operator +(double left, Compte right)
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
