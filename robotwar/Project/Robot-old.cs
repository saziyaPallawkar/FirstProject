using System;
using static System.Console;

namespace Project
{
    public class RobotOld
    {
        public int x;
        public int y;
        public int dir;
        public string path;
        private readonly int A = 5, B = 5;        //Boundary limit

        public RobotOld(int aX, int aY, int aDir, string aPath)
        {
            x = aX;
            y = aY;
            dir = aDir;
            path = aPath;
        }
        public void war()
        {
            
            //follow the path for robot
            for (int i = 0; i < path.Length; i++)
            {
                char move = path[i];

                //if move is left or right then change direction accordingly and if its 'M' move forward a step from current direction
                if (move == 'R')
                    dir = (dir + 1) % 4;
                else if (move == 'L')
                    dir = (4 + dir - 1) % 4;
                else if (move == 'M')
                {
                    if (dir == 0)       //direction is North
                    {
                        y++;
                        // Alert on reaching the boundary and break the loop without further increment of position
                        if (y == B)
                        {
                            WriteLine("ALERT: Reached boundary");
                            break;
                        }

                    }

                    else if (dir == 1)  //direction is East
                    {
                        x++;
                        // Alert on reaching the boundary and break the loop without further increment of position
                        if (x == A)
                        {
                            WriteLine("ALERT: Reached boundary");
                            break;
                        }
                    }

                    else if (dir == 2)  //direction is South
                    {
                        y--;
                        // Alert on reaching the boundary and break the loop without further increment of position
                        if (y == (B - 5))
                        {
                            WriteLine("ALERT: Reached boundary");
                            break;
                        }
                    }
                    else if (dir == 3)  //direction is West
                    {
                        x--;
                      
                    }

                }


            }

        }

        //method to print final position and direction of robots on console
        public void output()
        {
            if (dir == 0)
            {
                WriteLine(x + " " + y + "  N");
                ReadLine();
               
            }
            if (dir == 1)
            {
                WriteLine(x + " " + y + "  E");
                ReadLine();
            }
            if (dir == 2)
            {
                WriteLine(x + " " + y + "  S");
                ReadLine();
            }
            if (dir == 3)
            {
                WriteLine(x + " " + y + "  W");
                ReadLine();
            }

        }
        
    }
}
