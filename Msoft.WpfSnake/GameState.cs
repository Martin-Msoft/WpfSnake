using Msoft.WpfSnake.Entities;
using Msoft.WpfSnake.Levels;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Msoft.WpfSnake
{
    public class GameState
    {
        private Snake _snake;
        private Food _food;
        private Action<int> _scoreChanged;

        public int GameSpeed { get; set; }
        public int Score { get; set; }
        public bool IsAlive { get; set; }
        public readonly int MapHeight;
        public readonly int MapWidth;
        public CellType[,] Map { get; private set; }
        public SnakeDirection MovementDirection = SnakeDirection.Right;

        public GameState(int speed, ILevel level, Action<int> scoreChanged)
        {
            IsAlive = true;
            Score = 0;
            GameSpeed = speed;
            Map = level.GetMap();
            MapHeight = level.Height;
            MapWidth = level.Width;
            _scoreChanged += scoreChanged;
            _food = new();
            _snake = new(level.InitialSnakeLength, level.SnakeStartingPoint);
        }

        public void Update((int x, int y) direction)
        {
            var newCoordinates = _snake.UpdateSnakePosition(direction);

            if (CheckCollision(newCoordinates))
            {
                IsAlive = false;
                return;
            }

            if (Map[newCoordinates.X, newCoordinates.Y] != CellType.Food)
            {
                var removeCoordinates = _snake.RemoveTail();
                Map[removeCoordinates.X, removeCoordinates.Y] = CellType.Empty;
            }
            else
            {
                Score++;
                _scoreChanged.Invoke(Score);
                _food.Exists = false;
            }

            Map[newCoordinates.X, newCoordinates.Y] = CellType.Snake;
            if (!_food.Exists)
            {
                var newFood = _food.GetNewFoodCoordinates(GetEmptyCells());
                Map[newFood.X, newFood.Y] = CellType.Food;
            }
        }

        private List<Point> GetEmptyCells()
        {
            List<Point> emptyCells = new();
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (Map[y, x] == CellType.Empty)
                    {
                        emptyCells.Add(new Point(y, x));
                    }
                }
            }
            return emptyCells;
        }

        private bool CheckCollision(Point coordinates)
        {
            var cell = Map[coordinates.X, coordinates.Y];
            return cell == CellType.Snake || cell == CellType.Wall;
        }
    }
}
