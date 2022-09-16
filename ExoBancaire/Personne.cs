using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    class Personne
    {
        #region Champs - Variables membres
        private string _nom;
        private string _prenom;
        #endregion


        #region Propriétés
        // AUTO-PROPRIETE: utile quand on ne doit pas y toucher, quand il n'y pas d'instructions de validation: c'est correct pour l'exercice car on ne nous demandait pas de restriction
        //public string Nom { get; set; }
        //public string Prenom { get; set; }

        public string Nom
        {
            get { return _nom; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"Le nom ne peut contenir des espaces blancs ou être null... : {value}");
                _nom = value.Trim(); //retirer les espaces blancs du début et de la fin
            }
        }


        public string Prenom
        {
            get { return _prenom; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"Le nom ne peut contenir des espaces blancs ou être null...: {value}");
                _prenom = value.Trim(); //retirer les espaces blancs du début et de la fin
            }
        }
        
        public DateTime DateNaissance { get; private set; }
        #endregion

        #region Constructeurs & destructeurs
        public Personne(string nom, string prenom, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }
        #endregion

        #region Méthodes & opérateurs

        #endregion
    }
}
