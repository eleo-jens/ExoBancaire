using System;

namespace ExoBancaire
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne titulaire1 = new Personne();
            titulaire1.Nom = "Legrain";
            titulaire1.Prenom = "Samuel";
            titulaire1.DateNaissance = new DateTime(1987, 9, 27);

            Personne titulaire2 = new Personne();
            titulaire2.Nom = "   Willis     ";
            titulaire2.Prenom = "Bruce";
            titulaire2.DateNaissance = new DateTime(1987, 9, 27);

            Courant c1_sam = new Courant();
            c1_sam.Titulaire = titulaire1;
            c1_sam.Numero = "BE52 5647 8953 5642";
            c1_sam.LigneDeCredit = 200;

            Console.WriteLine($"Le compte bancaire de {c1_sam.Titulaire.Nom} {c1_sam.Titulaire.Prenom} né le {c1_sam.Titulaire.DateNaissance} ayant pour numéro de compte {c1_sam.Numero}, a pour le solde {c1_sam.Solde}. Il peut atteindre {c1_sam.LigneDeCredit} en dessous de 0.\n");

            c1_sam.Depot(1_000_000);

            Console.WriteLine($"Le compte bancaire de {c1_sam.Titulaire.Nom} {c1_sam.Titulaire.Prenom} né le {c1_sam.Titulaire.DateNaissance} ayant pour numéro de compte {c1_sam.Numero}, a pour le solde {c1_sam.Solde}. Il peut atteindre {c1_sam.LigneDeCredit} en dessous de 0.\n");

            c1_sam.Retrait(500_000);

            Console.WriteLine($"Le compte bancaire de {c1_sam.Titulaire.Nom} {c1_sam.Titulaire.Prenom} né le {c1_sam.Titulaire.DateNaissance} ayant pour numéro de compte {c1_sam.Numero}, a pour le solde {c1_sam.Solde}. Il peut atteindre {c1_sam.LigneDeCredit} en dessous de 0.\n");

            Courant c1_bruce = new Courant();
            c1_bruce.Titulaire = titulaire2;
            c1_bruce.Numero = "BE12 4568 7899 1023";

            Console.WriteLine($"Le compte bancaire de {c1_bruce.Titulaire.Nom} {c1_bruce.Titulaire.Prenom} né le {c1_bruce.Titulaire.DateNaissance} ayant pour numéro de compte {c1_bruce.Numero}, a pour le solde {c1_bruce.Solde}. Il peut atteindre {c1_bruce.LigneDeCredit} en dessous de 0.\n");

            c1_bruce.Retrait(1);

            Console.WriteLine($"Le compte bancaire de {c1_bruce.Titulaire.Nom} {c1_bruce.Titulaire.Prenom} né le {c1_bruce.Titulaire.DateNaissance} ayant pour numéro de compte {c1_bruce.Numero}, a pour le solde {c1_bruce.Solde}. Il peut atteindre {c1_bruce.LigneDeCredit} en dessous de 0.\n");

            c1_bruce.LigneDeCredit = 500;

            Console.WriteLine($"Le compte bancaire de {c1_bruce.Titulaire.Nom} {c1_bruce.Titulaire.Prenom} né le {c1_bruce.Titulaire.DateNaissance} ayant pour numéro de compte {c1_bruce.Numero}, a pour le solde {c1_bruce.Solde}. Il peut atteindre {c1_bruce.LigneDeCredit} en dessous de 0.\n");

            c1_bruce.Retrait(1);

            Console.WriteLine($"Le compte bancaire de {c1_bruce.Titulaire.Nom} {c1_bruce.Titulaire.Prenom} né le {c1_bruce.Titulaire.DateNaissance} ayant pour numéro de compte {c1_bruce.Numero}, a pour le solde {c1_bruce.Solde}. Il peut atteindre {c1_bruce.LigneDeCredit} en dessous de 0.\n");

            c1_bruce.LigneDeCredit = 1;

            Console.WriteLine($"Le compte bancaire de {c1_bruce.Titulaire.Nom} {c1_bruce.Titulaire.Prenom} né le {c1_bruce.Titulaire.DateNaissance} ayant pour numéro de compte {c1_bruce.Numero}, a pour le solde {c1_bruce.Solde}. Il peut atteindre {c1_bruce.LigneDeCredit} en dessous de 0.\n");

            Banque ING = new Banque();
            ING.Ajouter(c1_sam);
            ING.Ajouter(c1_bruce);
            ING.Supprimer(c1_sam.Numero);








        }
    }
}
