using System;

namespace supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Checkout checkout = new Checkout();
            checkout.addItem(new Item("A", 50, 130, 3));
            checkout.addItem(new Item("B", 30, 45, 2));
            checkout.addItem(new Item("C", 20, 0, 0));
            checkout.addItem(new Item("D", 15, 0, 0));
            string decision = "1";
            do
            {
                Console.WriteLine("Please scan the item");
                string Sku = Console.ReadLine();
                checkout.Scan(Sku);
                Console.WriteLine("Press 1 to scan more items or press ...");
                decision = Console.ReadLine();
            }
            while (decision == "1");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Total Price is -");
            Console.WriteLine("");
            Console.WriteLine(checkout.GetTotal());
        }
    }
}
