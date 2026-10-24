using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedCSharp02
{
    internal class ProductService
    {
        public List<Product> SearchProducts (List<Product> products , Func<Product, bool> filter)
        {
            List<Product> result = new List<Product>();
            foreach (var item in products)
            {
                if(filter(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public void PrintReport(List<Product> products , Action <Product> printer )
        {
            Console.WriteLine("Product Report");
            Console.WriteLine("--------------");
            foreach (var item in products)
            {
                printer(item);
            }
        }
    }
}    