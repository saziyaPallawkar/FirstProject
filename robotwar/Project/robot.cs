using System;
namespace Project
{
    public class Robot
    {

        public int X;
        public int Y;
        public int MaxX;
        public int MaxY;
        public int direction;

        public Robot(int maxX, int maxY)
        {
            this.MaxX = maxX;
            this.MaxY = maxY;
        }

        public void drive(int x, int y, int direction, string path)
        {
            this.X = x;
            this.Y = y;
            this.direction = direction;
            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            for (int i = 0; i < path.Length; i++)
            {
                char current_position = path[i];
                if (current_position == 'R')
                {
                    this.direction = (this.direction + 1) % 4;
                }
                else if (current_position == 'L')
                {
                    this.direction = (4 + this.direction - 1) % 4;
                }
                else if (current_position == 'M')
                {
                    if (this.direction == 0 || this.direction == 2)
                    {
                        this.Y = this.direction == 0 ? (this.Y + 1) : (this.Y - 1);
                    }

                    if (this.direction == 1 || this.direction == 3)
                    {
                        this.X = this.direction == 1 ? (this.X + 1) : (this.X - 1);
                    }

                    if (this.X > this.MaxX)
                    {
                        this.X = this.MaxX;
                    }

                    if (this.Y > this.MaxY)
                    {
                        this.Y = this.MaxY;
                    }

                    if (this.X < 0)
                    {
                        this.X = 0;
                    }

                    if (this.Y < 0)
                    {
                        this.Y = 0;
                    }
                }
            }
        }

        //method to print final position and direction of robots on console
        public void output()
        {
            if (this.direction == 0)
            {
                Console.WriteLine(this.X + " " + this.Y + "  N");
                Console.ReadLine();

            }
            if (this.direction == 1)
            {
                Console.WriteLine(this.X + " " + this.Y + "  E");
                Console.ReadLine();
            }
            if (this.direction == 2)
            {
                Console.WriteLine(this.X + " " + this.Y + "  S");
                Console.ReadLine();
            }
            if (this.direction == 3)
            {
                Console.WriteLine(this.X + " " + this.Y + "  W");
                Console.ReadLine();
            }

        }

        public static int input(string value)
        {
            if(value == "N")
            {
                return 0;
            }
            if (value == "E")
            {
                return 1;
            }
            if (value == "S")
            {
                return 2;
            }
            if (value == "W")
            {
                return 3;
            }
            return -1;
        }

    }
}