using System.Windows;

namespace Contacts
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

        private void NewContactButton_Click(object sender, RoutedEventArgs e)
            => new NewContactWindow().ShowDialog();
    }
}
