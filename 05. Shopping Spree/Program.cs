using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();

            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in peopleInput)
            {
                string[] parts = entry.Split('=');
                string name = parts[0];
                decimal money = decimal.Parse(parts[1]);

                people[name] = new Person(name, money);
            }

            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var entry in productInput)
            {
                string[] parts = entry.Split('=');
                string name = parts[0];
                decimal cost = decimal.Parse(parts[1]);

                products[name] = new Product(name, cost);
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = tokens[0];
                string productName = tokens[1];

                Person person = people[personName];
                Product product = products[productName];

                if (person.CanAfford(product))
                {
                    person.BuyProduct(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }

            foreach (var person in people.Values)
            {
                if (person.Products.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(p => p.Name))}");
                }
            }
        }
    }

    class Person
    {
        public string Name { get; }
        public decimal Money { get; private set; }
        public List<Product> Products { get; }

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public bool CanAfford(Product product)
        {
            return Money >= product.Cost;
        }

        public void BuyProduct(Product product)
        {
            Money -= product.Cost;
            Products.Add(product);
        }
    }

    class Product
    {
        public string Name { get; }
        public decimal Cost { get; }

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}