using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace task02_OnlineMarket
{
    class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(decimal price)
        {
            this.Price = price;

        }
        public Product(string name, decimal price)
            : this(price)
        {
            this.Name = name;
        }

        public int CompareTo(Product other)
        {
            var result = this.Price.CompareTo(other.Price);

            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price.ToString("G29"));
        }
    }

    class Program
    {
        static void Main()
        {
            var typesProducts = new Dictionary<string, OrderedBag<Product>>();
            var productsPrices = new OrderedSet<Product>();
            var productsNames = new HashSet<string>();

            var result = new StringBuilder();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split().ToArray();

                var command = tokens[0];
                string productName;
                decimal price;
                string productType;

                switch (command)
                {
                    case "add":
                        if (productsNames.Contains(tokens[1]))
                        {
                            result.AppendLine($"Error: Product {tokens[1]} already exists");
                        }
                        else
                        {
                            productName = tokens[1];
                            price = decimal.Parse(tokens[2]);
                            productType = tokens[3];
                            var product = new Product(productName, price);

                            productsNames.Add(productName);
                            if (!typesProducts.ContainsKey(productType))
                            {
                                typesProducts[productType] = new OrderedBag<Product> { product };
                            }
                            else
                            {
                                if (typesProducts[productType].Count > 9)
                                {
                                    if (product.CompareTo(typesProducts[productType][9]) < 0)
                                    {
                                        typesProducts[productType].RemoveLast();
                                        typesProducts[productType].Add(product);
                                    }
                                }
                                else
                                {
                                    typesProducts[productType].Add(product);
                                }
                            }
                            productsPrices.Add(product);

                            result.AppendLine($"Ok: Product {productName} added successfully");
                        }
                        break;
                    case "filter":
                        if (tokens[2] == "type")
                        {
                            productType = tokens[3];
                            if (!typesProducts.ContainsKey(productType))
                            {
                                result.AppendLine($"Error: Type {productType} does not exists");
                            }
                            else
                            {
                                result.Append("Ok: ");

                                result.AppendLine(string.Join(", ", typesProducts[productType]));
                            }
                        }

                        else if (tokens[2] == "price")
                        {
                            if (tokens[3] == "to")
                            {
                                var comparisonObject = new Product(decimal.Parse(tokens[4]));
                                var resultSet = productsPrices.RangeTo(comparisonObject, true).Take(10);
                                result.Append("Ok: ");


                                result.AppendLine(string.Join(", ", resultSet));
                            }

                            else if (tokens[3] == "from")
                            {
                                if (tokens.Length == 7)
                                {
                                    var comparisonObjectFrom = new Product(decimal.Parse(tokens[4]));
                                    var comparisonObjectTo = new Product(decimal.Parse(tokens[6]));
                                    var resultSet = productsPrices.Range(comparisonObjectFrom, true, comparisonObjectTo, true).Take(10);
                                    result.Append("Ok: ");
                                    result.AppendLine(string.Join(", ", resultSet));

                                }
                                else
                                {
                                    var comparisonObjectFrom = new Product(decimal.Parse(tokens[4]));

                                    var resultSet = productsPrices.RangeFrom(comparisonObjectFrom, true).Take(10);
                                    result.Append("Ok: ");
                                    result.AppendLine(string.Join(", ", resultSet));
                                }
                            }
                        }
                        break;
                }
            }
            Console.WriteLine(result.ToString().Trim());
        }
    }
}
