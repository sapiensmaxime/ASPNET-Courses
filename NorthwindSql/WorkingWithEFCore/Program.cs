using static System.Console;
using Ifinfo.shared;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Ifinfo.shared
{
    class Program
    {
        static void Main(string[] args)
        {
            //QueryingCategories();
            //QueryingProducts();
            // if(AddProduct(6, "Bob's Burger", 500M))
            // {
            //     WriteLine("Ajout d'un produit avec succès");
            // }
            // if(IncreaseProductPrice("Bob", 20M))
            // {
            //     WriteLine("Mise à jour du prix produit avec succès");
            // }
            int deleted = DeleteProducts("Bob");
            WriteLine($"{deleted} produit(s) ont été supprimés.");
            ListProducts();
        }
        static void QueryingCategories()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have : ");

                //a query to get all categories and their related products
                //IQueryable<Category> cats = db.Categories.Include(c => c.Products);
                //IQueryable<Category> cats = db.Categories;
                IQueryable<Category> cats;
                db.ChangeTracker.LazyLoadingEnabled = false;

                Write("Activer le eager loading ? (Y/N) :");
                bool eagerloading = (ReadKey().Key==ConsoleKey.Y);
                bool explicitloading = false;
                WriteLine();

                if(eagerloading)
                {
                    cats = db.Categories.Include(c =>c.Products);
                }
                else
                {
                    cats = db.Categories;
                    Write("Activer le explicit loading ? (Y/N) :");
                    explicitloading = (ReadKey().Key==ConsoleKey.Y);
                    WriteLine();
                }

                foreach(Category c in cats)
                {
                    if(explicitloading)
                    {
                        Write($"Chargement Explicit des produits pour {c.CategoryName} ? (Y/N) : ");
                        ConsoleKeyInfo key = ReadKey();
                        WriteLine();
                        if(key.Key == ConsoleKey.Y)
                        {
                            var products = db.Entry(c).Collection(c2 => c2.Products);
                            if(!products.IsLoaded)products.Load();
                        }
                    }
                    WriteLine($"{c.CategoryName} har {c.Products.Count} products.");
                }
            }
        }

         static void QueryingProducts()
        {
            using (var db = new Northwind())
            {
                WriteLine("Categories and how many products they have : ");
                string input;
                decimal price;
                
                do{
                    Write("Enter a product price : ");
                    input = ReadLine();
                }while(!decimal.TryParse(input, out price));

                //a query to get all categories and their related products
                IQueryable<Product> prods = db.Products.Where(product =>product.Cost > price).OrderByDescending(Product => Product.Cost);

                foreach(Product item in prods)
                {
                    WriteLine($"{item.ProductID} : {item.ProductName} costs {item.Cost:$#,##0.00} and has {item.Stock} units in stocks.");
                }
            }
        }

        static bool AddProduct(int categoryID, string productName, decimal? price)
        {
            using (var db = new Northwind())
            {
                var newProduct = new Product{
                    CategoryID = categoryID,
                    ProductName = productName,
                    Cost = price
                };
                db.Products.Add(newProduct);
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }

        static void ListProducts()
        {
            using(var db = new Northwind())
            {
                WriteLine("{0,-3}{1,-35}{2,8}{3,5}{4}","ID", "Nom Produit", "Coût", "Stock", "Disc.");
                foreach(var item in db.Products.OrderByDescending(p => p.Cost))
                {
                    WriteLine("{0:000}{1,-35}{2,8:s$#,##0.00}{3,5}{4}", item.ProductID, item.ProductName, item.Cost, item.Stock, item.Discontinued);
                }
            }
        }

        static bool IncreaseProductPrice(string name, decimal amount)
        {
            using (var db = new Northwind())
            {
                Product updateProduct = db.Products.First(p => 
                p.ProductName.StartsWith(name));
                updateProduct.Cost += amount;
                int affected = db.SaveChanges();
                return(affected == 1);
            }
        }

        static int DeleteProducts(string name)
        {
            using(var db = new Northwind())
            {
                IEnumerable<Product> products = db.Products.Where(p => p.ProductName.StartsWith(name));
                db.Products.RemoveRange(products);
                int affected = db.SaveChanges();
                return affected;
            }
        }
    }
}