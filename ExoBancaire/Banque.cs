using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    class Banque
    {
        #region Champs
        public string Name { get; set; }
        #endregion

        #region Propriétés
        private Dictionary<string, Compte> _comptes;

        // this représente instance de la classe Banque: ici c'est l'indexer de notre classe banque
        public Compte this[string numero]
        {
            get
            {
                Compte c = null;
                _comptes.TryGetValue(numero, out c);
                return c; 
            }
        }
        #endregion

        #region Constructeurs
        // si je n'ai pas de compte, crée un dictionnaire vide. Exemple, une banque qui n'a pas encore de compte
        public Banque(string nom)
        {
            this.Name = nom;
            _comptes = new Dictionary<String, Compte>();
        }

        // je demande qu'il excécute le premier constructeur, puis je lui dis pour chaque comptes qui se trouvent dans mon tableau de compte, ajoute les dans le dictionnaire: exemple une banque qui a déjà une liste de compte
        public Banque(string nom, Compte[] comptes) : this(nom)
        {
            foreach(Compte c in comptes)
            {
                this.Ajouter(c);
            }
        }
        #endregion


        //METTRE THROW
        // plus facile que de mettre des méthodes que de mettre en place un set dans l'indexer
        public void Ajouter(Compte compte)
        {
            // ou utiliser TryAdd
            if (compte != null && !_comptes.ContainsKey(compte.Numero))
            {
                _comptes.Add(compte.Numero, compte);
                compte.PassageEnNegatifEvent += PassageEnNegatifAction;
            }   
        }

        //METTRE THROW
        // si je laisse mon dictionaire en public n'importe quel developpeur peut utiliser les méthodes de Dictionary (TryGetValue, Add, Remove) et notre Dico pourrait donc etre null au final, il faut donc l'encapsuler en private
        public void Supprimer(String numero)
        {
            if (!string.IsNullOrWhiteSpace(numero) && _comptes.ContainsKey(numero))
            {
                _comptes[numero].PassageEnNegatifEvent -= PassageEnNegatifAction;
                _comptes.Remove(numero);
            }
        }

        public double AvoirsDesComptes(Personne titulaire)
        {
            double somme = 0;
            foreach (KeyValuePair<string, Compte> kvp in _comptes)
            {
                Compte compte = kvp.Value;
                if (titulaire == compte.Titulaire)
                {
                    somme += compte;
                }
            }
            return somme;

            // autre facon d'écrire moins précise, var à éviter
            //foreach (var compte in _comptes.Values)
            //{
            //    if (titulaire == compte.Titulaire)
            //    {
            //        somme += compte;
            //    }
            //}
        }

        public void PassageEnNegatifAction(Compte c)
        {
            Console.WriteLine($"Le compte {c.Numero} est passé en négatif!");
        }
    }
}
