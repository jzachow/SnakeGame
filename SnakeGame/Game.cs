using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Numerics;


namespace SnakeGame
{
    public class Game
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public char[,] Board { get; set; }
        public Snake Snake { get; set; }

        private Point Up = new Point(-1, 0);
        private Point Left = new Point(0, -1);
        private Point Down = new Point(1, 0);
        private Point Right = new Point(0, 1);

        public Game(int height, int width)
        {
            Height = height;
            Width = width;
            Board = new char[height, width];
            Snake = new Snake(new Point(0, 0), new Point(0, 1));           
            Snake.Body.Add(new Point(1, 1));
            Snake.Body.Add(new Point(1, 2));
            Snake.Body.Add(new Point(2, 2));
            Snake.Body.Add(new Point(2, 3));
            Snake.Body.Add(new Point(2, 4));
            Snake.Body.Add(new Point(2, 5));
            Snake.Body.Add(new Point(2, 6));
        }

        public void Render()
        {            

            Console.WriteLine();
            RenderTopAndBottomBorder();
            for (int i = 0; i < Height; i++)
            {                
                Console.WriteLine();
                Console.Write("|");
                for (int j = 0; j < Width; j++)
                {
                    char c = Board[i, j];
                    
                    if (new Point(i, j) == Snake.Head())
                        Console.Write("X");
                    else if (Snake.Body.Contains(new Point(i, j)))
                        Console.Write("O");
                    else
                        Console.Write(" ");
                }
                Console.Write("|");
            }
            Console.WriteLine();
            RenderTopAndBottomBorder();
            Console.WriteLine();
        }

        private void RenderTopAndBottomBorder()
        {
            for (int i = 0; i < Width + 2; i++)
            {
                if (i == 0 || i == Width + 1)
                    Console.Write("+");
                else
                    Console.Write("-");
            }
        }

        public void GetUserMovement()
        {
            Point direction = GrabUserDirectionInput();

            if (ValidateDirection(direction))
            {
               
                Point currentPosition = Snake.Head();
                Point newPosition = Snake.Head();
                newPosition.Offset(direction);

                if (VildatePosition(newPosition))
                {
                    Snake.SetDirection(direction);
                    Snake.TakeStep(newPosition);
                    Render();
                }
            }

            
        }
        private bool ValidateDirection(Point direction)
        {
            Point oppositeDirection = new Point(direction.X, direction.Y);
            oppositeDirection.Offset(Snake.Direction);

            Point zero = new Point(0, 0);


            if (direction == zero || oppositeDirection == zero)
                return false;           
            else
                return true;
        }
        
        private bool VildatePosition(Point newPosition)
        {
            if (newPosition.X < 0 || newPosition.Y < 0)
                return false;
            if ((newPosition.X > Height - 1) || (newPosition.Y > Width - 1))
                return false;
            else
                return true;
        }

        private Point GrabUserDirectionInput()
        {
            ConsoleKeyInfo keyinfo = Console.ReadKey();
            Point direction;

            switch (keyinfo.Key)
            {
                case ConsoleKey.W:
                    direction = Up;
                    break;
                case ConsoleKey.A:
                    direction = Left;
                    break;
                case ConsoleKey.S:
                    direction = Down;
                    break;
                case ConsoleKey.D:
                    direction = Right;
                    break;
                default:
                    direction = new Point(0, 0);
                    break;
            }
            return direction;
        }      
    }
}
