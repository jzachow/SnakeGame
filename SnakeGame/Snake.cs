using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SnakeGame
{
    public class Snake
    {
        public List<Point> Body{ get; set; }
        public Point Direction { get; set; }
       
        public Snake(Point initialBody, Point initialDirection)
        {
            Body = new List<Point>() { initialBody };
            Direction = initialDirection;
        }

        public void TakeStep(Point position)
        {
            Body.Add(position);
            Body.RemoveAt(0);
        }

        public void SetDirection(Point direction)
        {
            Direction = direction;
        }

        public Point Head()
        {
            return Body.Last();
        }
    }
}
