using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Veuillez entrer votre nom :");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"Bonjour {name}, nous sommes le {date:d} et il est {date:t}");
            Console.WriteLine("Appuyez sur une touche pour fermer l'application");
            Console.ReadKey(true);
        }
    }
}
