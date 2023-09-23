using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Msoft.WpfSnake
{
    public class Render
    {
        private GameState _state;
        private TextBlock[,] _grid;

        public Render(GameState gameState)
        {
            _state = gameState;
            _grid = new TextBlock[_state.MapHeight, _state.MapWidth];
        }

        public void SetGrid(Grid grid)
        {
            for (int y = 0; y < _state.MapHeight; y++)
            {
                for (int x = 0; x < _state.MapWidth; x++)
                {
                    var textBlock = new TextBlock
                    {
                        // Initialize with default properties
                        FontFamily = new FontFamily("Terminal"),
                        FontSize = 32,
                        TextAlignment = TextAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                    };

                    // Add to the Grid
                    Grid.SetRow(textBlock, y);
                    Grid.SetColumn(textBlock, x);
                    grid.Children.Add(textBlock);

                    // Store a reference in the 2D array
                    _grid[y, x] = textBlock;
                }
            }
        }

        public void RenderFrame()
        {
            for (int y = 0; y < _state.MapHeight; y++)
            {
                for (int x = 0; x < _state.MapWidth; x++)
                {
                    var cellType = _state.Map[y, x];
                    var textBlock = _grid[y, x];

                    switch (cellType)
                    {
                        case CellType.Wall:
                            textBlock.Background = new SolidColorBrush(Colors.Black);
                            break;
                        case CellType.Empty:
                            textBlock.Background = new SolidColorBrush(Colors.White);
                            textBlock.Text = string.Empty;
                            break;
                        case CellType.Snake:
                            textBlock.Text = "■";
                            break;
                        case CellType.Food:
                            textBlock.Text = "o";
                            break;
                    }
                }
            }
        }
    }
}
