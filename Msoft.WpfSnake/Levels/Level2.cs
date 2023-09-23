using System.Collections.Generic;
using System.Drawing;

namespace Msoft.WpfSnake.Levels
{
    public class Level2 : ILevel
    {
        public string Name => "Level 2";
        public int Height => 25;
        public int Width => 50;

        public List<Point> SnakeStartingPoint { get; private set; }
        public int InitialSnakeLength { get; private set; }

        public Level2()
        {
            SnakeStartingPoint = new()
            {
                new Point(10, 10),
                new Point(11, 10),
                new Point(12, 10),
            };

            InitialSnakeLength = 3;
        }

        //Hyper food
        public void SpecialEvent()
        {
            //Something unique for this map
        }

        public CellType[,] GetMap()
        {
            var map = new CellType[Height, Width];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    //Map borders
                    if (y == 0 || y == Height - 1 || x == 0 || x == Width - 1 ||

                        //Left cove
                        ((y >= 8 && y <= 16) && (x == 5 || (x >= 5 && x <= 10) && (y == 8 || y == 16))) ||

                        //Right cove
                        ((y >= 8 && y <= 16) && (x == Width - 6 || (x <= Width - 6 && x >= Width - 11) && (y == 8 || y == 16))) ||

                        //Lines in the middle
                        (((y >= 1 && y <= 24) && (y != 11 && y != 12 && y != 13)) && (x == Width - 22 || x == Width - 29)))
                    {
                        map[y, x] = CellType.Wall;
                    }
                    else
                    {
                        map[y, x] = CellType.Empty;
                    }
                }
            }
            return map;
        }
    }
}
