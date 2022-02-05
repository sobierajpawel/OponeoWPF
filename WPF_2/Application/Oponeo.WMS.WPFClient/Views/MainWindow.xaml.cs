using Oponeo.WMS.Model;
using Oponeo.WMS.WPFClient.ViewModels;
using System.Windows;

namespace Oponeo.WMS.WPFClient.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel mainWindowViewModel)
            {
                MessageBox.Show(mainWindowViewModel.ToString());
            }
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            string sourceObject = e.Source.ToString(); 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void Grid_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}
