using System;
using static System.Console;
using Ifinfo.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

class Program
{
    static void Main(string[] args)
    {
        //QueryingClasses();
        //QueryingEleves();
        /*if(AddEleve(1, "Jean", "Michel"))
        {
            WriteLine("Ajout d'un élève avec succès");
        }*/
        // if(UpdateNameEleve("ABSCHEN", "CHEFSAP"))
        // {
        //     WriteLine("Mise à jour du nom réalisée avec succès");
        // }
        int deleted = DeleteEleve("BOUDART");
        WriteLine($"{deleted} élève(s) ont été supprimés.");

        ListEleves();

    }

    static void QueryingClasses()
    {
        using (var db = new GestionClasses())
        {
            WriteLine("Classes et le nombre d'élèves qu'elles contiennent : ");

            IQueryable<Classes> classes = db.Classes.Include(c => c.Eleves);
            
            foreach(Classes c in classes)
            {
                WriteLine($"{c.NomClasse} has {c.Eleves.Count} élèves.");
            }
        }
    }   

    static void QueryingEleves()
    {
        using (var db = new GestionClasses())
            {
                WriteLine("Eleve(s) dont le prénom contient la saisie");
                string input;
                Write("Entrez un prenom : ");
                input = ReadLine();

                IQueryable<Eleves> eleves = db.Eleves
                .Where(eleves => eleves.PrenomEleve.Contains(input))
                .OrderByDescending(eleves => eleves.PrenomEleve);

                foreach (Eleves item in eleves)
                {  
                    
                    WriteLine($"{item.EleveID} : {item.NomEleve} {item.PrenomEleve}");
                }
            }

    }

    static bool AddEleve(int classeID, string nomEleve, string prenomEleve)
    {
         using (var db = new GestionClasses())
            {
                var newEleve = new Eleves{
                    ClasseID = classeID,
                    NomEleve = nomEleve,
                    PrenomEleve = prenomEleve
                };
                db.Eleves.Add(newEleve);
                int affected = db.SaveChanges();
                return (affected == 1);
            }

    }

    static void ListEleves()
    {
         using (var db = new GestionClasses())
            {
                WriteLine("{0,-3}{1,-35}{2,8}","ID", "Nom Eleves", "Prénom Elève");
                foreach(var item in db.Eleves.OrderByDescending(e => e.NomEleve))
                {
                    WriteLine("{0:000}{1,-35}{2,8}", item.EleveID, item.NomEleve, item.PrenomEleve);
                }
            }
    }

    static bool UpdateNameEleve(string name, string newName)
    {
         using (var db = new GestionClasses())
            {
                Eleves updateEleve = db.Eleves.First(e => e.NomEleve.StartsWith(name));
                updateEleve.NomEleve = newName;
                int affected = db.SaveChanges();
                return (affected == 1);
            }
    }

    static int DeleteEleve(string name)
    {
         using (var db = new GestionClasses())
            {
                IEnumerable<Eleves> eleves = db.Eleves.Where(e => e.NomEleve.StartsWith(name));
                db.Eleves.RemoveRange(eleves);
                int affected = db.SaveChanges();
                return affected;
            }
    }
}
