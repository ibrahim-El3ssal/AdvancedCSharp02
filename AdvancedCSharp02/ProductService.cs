using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdvancedCSharp02
{
    internal class ProductService
    {
        ///  we used it: Because To explicitly define a custom method signature from scratch and establish a domain - specific contract(ProductFilterDelegate) for matching products.
        public List<Product> SearchProducts(List<Product> products, Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();
            foreach (var item in products)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        /// we used it: Because the task is purely execution-oriented and does not return any value (void).
        public void PrintReport(List<Product> products, Action<Product> printer)
        {
            Console.WriteLine("Product Report");
            Console.WriteLine("--------------");
            foreach (var item in products)
            {
                printer(item);
            }
        }
        /// we used it: Because the operation is a transformation that must return a computed result. 
        public List<string> TransformProducts(List<Product> products, Func<Product, string> transformer)
        {
            List<string> result = new List<string>();
            foreach (var item in products)
            {
                result.Add(transformer(item));
            }
            return result;
        }

        /// we used it: To perform a conditional evaluation or test that exclusively returns a boolean (true or false).
        public List<Product> FilterProducts(List<Product> products, Predicate<Product> filter)
        {
            List<Product> result = new List<Product>();
            foreach (var item in products)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}    