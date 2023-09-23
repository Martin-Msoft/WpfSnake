using System.Collections.Generic;
using System.Drawing;

namespace Msoft.WpfSnake.Levels
{
    public interface ILevel
    {
        string Name { get; }
        int Height { get; }
        int Width { get; }
        List<Point> SnakeStartingPoint { get; }
        int InitialSnakeLength { get; }
        CellType[,] GetMap();
    }
}
