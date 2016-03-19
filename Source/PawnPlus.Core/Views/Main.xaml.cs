using System.Windows;

namespace PawnPlus.Core.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.lineLabel.Visibility = Visibility.Hidden;
            this.columnLabel.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Save window state, location and state.
            if (this.WindowState != WindowState.Minimized)
            {
               Properties.Settings.Default.WindowState = this.WindowState;
            }

            Properties.Settings.Default.Location = new Point(this.Left, this.Top);
            Properties.Settings.Default.Size = new Size(this.Width, this.Height);

            Properties.Settings.Default.Save();
        }
    }
}
