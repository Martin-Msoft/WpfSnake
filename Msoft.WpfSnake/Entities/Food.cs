using System;
using System.Collections.Generic;
using System.Drawing;

namespace Msoft.WpfSnake.Entities
{
    public class Food
    {
        public bool Exists;

        public Point GetNewFoodCoordinates(List<Point> validCells)
        {
            int maxInteger = validCells.Count;
            Random random = new();
            var index = random.Next(0, maxInteger);
            Exists = true;
            return validCells[index];
        }
    }
}
