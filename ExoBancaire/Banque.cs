using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoBancaire
{
    class Banque
    {
        public string Name { get; set; }

        private Dictionary<string, Courant> _comptes = new Dictionary<String, Courant>();

        // this représente instance de la classe Banque: ici c'est l'indexer de notre classe banque
        public Courant this[string numero]
        {
            get
            {
                Courant c = null;
                _comptes.TryGetValue(numero, out c);
                return c; 
            }
        }

        // plus facile que de mettre des méthodes que de mettre en place un set dans l'indexer
        public void Ajouter(Courant compte)
        {
            // ou utiliser TryAdd
            if (compte != null && !_comptes.ContainsKey(compte.Numero))
            {
                _comptes.Add(compte.Numero, compte);
            }   
        }
        // si je laisse mon dictionaire en public n'importe quel developpeur peut utiliser les méthodes de Dictionary (TryGetValue, Add, Remove) et notre Dico pourrait donc etre null au final, il faut donc l'encapsuler en private
        public void Supprimer(String numero)
        {
            if (numero != null && _comptes.ContainsKey(numero))
            {
                _comptes.Remove(numero);
            }
        }
    }
}
