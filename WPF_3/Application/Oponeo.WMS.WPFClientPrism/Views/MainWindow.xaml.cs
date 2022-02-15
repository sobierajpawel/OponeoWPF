using Oponeo.WMS.WPFClientPrism.ViewModels;
using System.Windows;

namespace Oponeo.WMS.WPFClientPrism.Views
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
            if (DataContext is MainWindowViewModel viewModel)
            {
                MessageBox.Show("Sukces");
            }
        }
    }
}
