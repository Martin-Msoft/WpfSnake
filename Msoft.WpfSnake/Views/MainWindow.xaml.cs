using System.Windows;
using System.Windows.Input;

namespace Msoft.WpfSnake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            MaxWidth = Width;
            MaxHeight = Height;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //if (e.OriginalSource is Grid) // Replace with your actual control type
            //{
            //    // Let the event pass through so TextBox can handle it
            //    return;
            //}

            //if (e.Key == Key.Up || e.Key == Key.Down || e.Key == Key.Left || e.Key == Key.Right)
            //{
            //    e.Handled = true;
            //}
        }






    }
}
