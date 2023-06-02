using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Week6_PD_Pacman.BL;
using System.Threading.Tasks;

namespace Week6_PD_Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a maze
            Grid maze = new Grid(20, 20, "maze.txt");

            // Create a pacman
            Pacman pacman = new Pacman(10, 10);

            // Create ghosts
            List<Ghost> ghosts = new List<Ghost>();
            for (int i = 0; i < 4; i++)
            {
                ghosts.Add(new Ghost(i * 10, i * 10, 1));
            }

            // Start the game loop
            while (true)
            {
                // Clear the screen
                Console.Clear();

                // Draw the maze
                maze.Draw();

                // Draw the pacman
                Console.Write("P");

                // Draw the ghosts
                foreach (var ghost in ghosts)
                {
                    Console.Write("G");
                }

                // Get the user input
                Console.ReadKey();

                // Move the pacman
                char direction = Console.ReadKey().KeyChar;
                pacman.Move(direction);

                // Move the ghosts
                foreach (var ghost in ghosts)
                {
                    ghost.Move();
                }

                // Check if the pacman has reached the exit
                if (maze.FindPacman().Value == 'E')
                {
                    Console.WriteLine("You win!");
                    break;
                }

                // Check if the pacman has collided with a ghost
                foreach (var ghost in ghosts)
                {
                    if (pacman.X == ghost.X && pacman.Y == ghost.Y)
                    {
                        Console.WriteLine("You lose!");
                        break;
                    }
                }
            }
        }
    }
}
 

