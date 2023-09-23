using Msoft.WpfSnake.Levels;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Msoft.WpfSnake
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private int _gameSpeed;
        public List<ILevel> Levels { get; private set; }

        public Menu()
        {
            InitializeComponent();
            Levels = new()
            {
                new Level1(),
                new Level2()
            };
            LevelSelect.ItemsSource = Levels;
            LevelSelect.SelectedIndex = 0;
        }

        private void StartLevel(object sender, RoutedEventArgs e)
        {
            if (OptionEasy.IsChecked == true)
            {
                _gameSpeed = 225;
            }
            else if (OptionMedium.IsChecked == true)
            {
                _gameSpeed = 175;
            }
            else if (OptionHard.IsChecked == true)
            {
                _gameSpeed = 105;
            }

            var level = Levels[LevelSelect.SelectedIndex];
            NavigationService.Navigate(new Game(level, _gameSpeed));
        }
    }
}
