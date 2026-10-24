namespace AdvancedCSharp02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Product Catalog 
            List<Product> catalog = new()
            {
                new Product { Id=1, Name="Laptop", Category="Electronics", Price=1200, Stock=10 },
                new Product { Id=2,Name="Phone", Category="Electronics", Price=800, Stock=25 },
                new Product { Id=3, Name="T-Shirt", Category="Clothing", Price=30, Stock=100 },
                new Product { Id=4, Name="Jeans", Category="Clothing", Price=60, Stock=50 },
                new Product { Id=5, Name="Chocolate", Category="Food", Price=5, Stock=200 },
                new Product { Id=6, Name="Coffee Beans", Category="Food", Price=15, Stock=80 },
                new Product { Id=7, Name="C# Book", Category="Books", Price=45, Stock=30 },
                new Product { Id=8, Name="Novel", Category="Books", Price=20, Stock=60 },
                new Product { Id=9,Name="Headphones", Category="Electronics", Price=150, Stock=40 },
                new Product { Id=10, Name="Jacket", Category="Clothing", Price=120, Stock=15 }
            };
            #endregion

            #region Task 01 : Smart Product Search
            ProductService searchService = new ProductService();
            var electronics = searchService.SearchProducts(catalog, p => p.Category == "Electronics");
            Console.WriteLine("--- Electronics ___");
            foreach (var item in electronics)
            {
                Console.WriteLine($"{item.Name} - ${item.Price} (Stock: {item.Stock})");
            }
            /// --- Under $50 --- 
            var electronicsCheapest = searchService.SearchProducts(catalog, p => p.Price < 50);
            Console.WriteLine("\n--- Under $50  ___\n");
            foreach (var item in electronicsCheapest)
            {
                Console.WriteLine($"{item.Name} - ${item.Price} (Stock: {item.Stock})");
            }
            ///  Products that are in stock
            var allElectronics = searchService.SearchProducts(catalog, p => p.Stock > 0);
            Console.WriteLine("\n--- Products that are in stock   ___\n");
            foreach (var item in allElectronics)
            {
                Console.WriteLine($"{item.Name} - ${item.Price} (Stock: {item.Stock})");
            }
            /// Clothing products under $100
            var colthingProducts = searchService.SearchProducts(catalog, p => p.Category == "Clothing" && p.Price < 100);
            Console.WriteLine("\n--- Clothing products under $100   ___\n");
            foreach (var item in colthingProducts)
            {
                Console.WriteLine($"{item.Name} - ${item.Price} (Stock: {item.Stock})");
            }
            #endregion

            #region Task 03 : Custom Report Generator
            ProductService print = new ProductService();
            Console.WriteLine("\n--- --- Short Report ---___\n");
            print.PrintReport(catalog, p => Console.WriteLine($"{p.Name} - ${p.Price}"));

            Console.WriteLine("\n--- --- Detailed Report ---___\n");
            print.PrintReport(catalog, p => Console.WriteLine($"[{p.Category}] {p.Name} | Price: ${p.Price} | Stock: {p.Stock}"));
            #endregion

            #region 3.2. Transform Products 
            ProductService Transform = new ProductService();
            Console.WriteLine("\n--- Summary List --- \n");
            var summaryList = Transform.TransformProducts (catalog,p => ($"{p.Name} (${p.Price})"));
            foreach (var item in summaryList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n--- Price Labels ---");
            var priceLabels = Transform.TransformProducts(catalog, p => $"{p.Name}: {(p.Price > 100 ? "Expensive!" : "Affordable")}");
            foreach (var item in priceLabels)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region 3.3. Filter Products 
            ProductService filterService = new ProductService();
            var lowStockProducts = filterService.FilterProducts(catalog, p => p.Stock < 20);
            Console.WriteLine("\n--- Low-Stock Alert ---");
            foreach (var item in lowStockProducts)
            {
                Console.WriteLine($"[LOW STOCK] {item.Name}: only {item.Stock} left!");
            }
            #endregion
        }
    }
}
