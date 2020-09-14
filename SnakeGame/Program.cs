using System;

namespace SnakeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(20, 20);
            Console.WriteLine("Welcome to Snake Game. Prepare To Die\n\n\n\n\n");
            game.Render();

            
            while (true)
            {
                game.GetUserMovement();
            }
        }
    }
}
