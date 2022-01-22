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
    }
}
