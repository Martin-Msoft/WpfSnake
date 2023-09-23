using System.Windows.Input;

namespace Msoft.WpfSnake
{
    public class Movement
    {
        private GameState _state;

        public Movement(GameState state) => _state = state;

        //Return direction
        public (int x, int y) GetNewDirection()
        {
            (int x, int y) direction = (0, 0);
            switch (_state.MovementDirection)
            {
                case SnakeDirection.Left:
                    direction = (0, -1);
                    break;
                case SnakeDirection.Right:
                    direction = (0, 1);
                    break;
                case SnakeDirection.Up:
                    direction = (-1, 0);
                    break;
                case SnakeDirection.Down:
                    direction = (1, 0);
                    break;
                default:
                    break;
            }
            return direction;
        }

        //Update the direction
        public void UpdateDirection(Key key)
        {
            var direction = _state.MovementDirection;
            switch (key)
            {
                case Key.Left:
                    direction = direction != SnakeDirection.Right ? SnakeDirection.Left : direction;
                    break;
                case Key.Right:
                    direction = direction != SnakeDirection.Left ? SnakeDirection.Right : direction;
                    break;
                case Key.Up:
                    direction = direction != SnakeDirection.Down ? SnakeDirection.Up : direction;
                    break;
                case Key.Down:
                    direction = direction != SnakeDirection.Up ? SnakeDirection.Down : direction;
                    break;
                default:
                    break;
            }
            _state.MovementDirection = direction;
        }
    }
}
