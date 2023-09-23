using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Msoft.WpfSnake.Entities
{
    public class Snake
    {
        public int SnakeLength { get; private set; }
        public List<Point> SnakeBody { get; private set; }

        public Snake(int snakeLength, List<Point> snakeStartingPoint)
        {
            SnakeLength = snakeLength;
            SnakeBody = snakeStartingPoint;
        }

        private Point _lastTail;

        public Point UpdateSnakePosition((int x, int y) direction)
        {
            var newX = SnakeBody.Last().X + direction.x;
            var newY = SnakeBody.Last().Y + direction.y;

            //Save the old tail point
            _lastTail = SnakeBody[0];

            //Move the snake forward by adding a new head
            SnakeBody.Add(new Point(newX, newY));

            //Return the new head
            return new Point(newX, newY);
        }

        public Point RemoveTail()
        {
            //Remove the tail so that the snake does not grow infinitely
            SnakeBody.RemoveAt(0);
            return _lastTail;
        }
    }
}
