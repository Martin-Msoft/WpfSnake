using Msoft.WpfSnake.Levels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Msoft.WpfSnake
{
    public partial class Game : Page
    {
        private Render _render;
        private GameState _state;
        private Movement _movement;

        public Key Key;

        public Game(ILevel level, int speed)
        {
            InitializeComponent();
            _state = new(speed, level, UpdateScoreLabel);
            _render = new(_state);
            _movement = new(_state);
        }

        private async Task GameLoop()
        {
            GameGrid.Focus();
            _render.SetGrid(GameGrid);
            while (_state.IsAlive)
            {
                var newCoordinates = _movement.GetNewDirection();
                _state.Update(newCoordinates);
                _render.RenderFrame();
                await Task.Delay(_state.GameSpeed);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
            _movement.UpdateDirection(e.Key);
        }

        private void ExitLevel_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Menu());
        private async void Grid_Loaded(object sender, RoutedEventArgs e) => await GameLoop();
        private async void UpdateScoreLabel(int score) => await Dispatcher.BeginInvoke(() => ScoreLabel.Content = $"Score: {_state.Score}");
    }
}