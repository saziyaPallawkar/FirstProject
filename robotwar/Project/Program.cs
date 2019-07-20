using System;
using static System.Console;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string decision = "1";
            do
            {
                Console.WriteLine("Please enter arena max x coordinate value");
                int maxX = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter arena max y coordinate value");
                int maxY = Convert.ToInt32(Console.ReadLine());

                Robot robot1 = new Robot(maxX, maxY);
                Console.WriteLine("Please enter initial position of Robot1 x");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter initial position of Robot1 y");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter initial direction of Robot1");
                int direction = Robot.input(Console.ReadLine());
                Console.WriteLine("Please enter path");
                string path = Console.ReadLine();
                robot1.drive(x, y, direction, path);

                robot1.output();
                Console.WriteLine("");
                Console.WriteLine("");

                Robot robot2 = new Robot(maxX, maxY);
                Console.WriteLine("Please enter initial position of Robot2 x");
                x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter initial position of Robot 2 y");
                y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter initial direction of Robot 2");
                direction = Robot.input(Console.ReadLine());
                Console.WriteLine("Please enter path");
                path = Console.ReadLine();
                robot2.drive(x, y, direction, path);

                robot2.output();

                Console.WriteLine("Press 1 to try it again ...");
                decision = Console.ReadLine();
            }
            while (decision == "1");

           
        }
    }
}
