using System.Collections.Generic;
using System.Drawing;

namespace Msoft.WpfSnake.Levels
{
    public class Level1 : ILevel
    {
        public string Name => "Level 1";
        public int Height => 25;
        public int Width => 50;

        public List<Point> SnakeStartingPoint { get; private set; }
        public int InitialSnakeLength { get; private set; }

        public Level1()
        {
            SnakeStartingPoint = new()
            {
                new Point(10, 10),
                new Point(11, 10),
                new Point(12, 10),
            };

            InitialSnakeLength = 3;
        }

        public void SpecialEvent()
        {
            //Something unique for this map
        }

        public CellType[,] GetMap()
        {
            var map = new CellType[Height, Width];
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    if (x == 0 || x == Height - 1 || y == 0 || y == Width - 1)
                    {
                        map[x, y] = CellType.Wall;
                    }
                    else
                    {
                        map[x, y] = CellType.Empty;
                    }
                }
            }
            return map;
        }
    }
}
