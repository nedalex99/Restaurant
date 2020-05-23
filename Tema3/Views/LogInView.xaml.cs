
using System.Windows;
using Tema3.ViewModels;

namespace Tema3.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        public LogInView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
