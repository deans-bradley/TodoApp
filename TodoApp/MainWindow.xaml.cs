using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using TodoApp.ViewModels;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new TodoViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
        }
    }
}