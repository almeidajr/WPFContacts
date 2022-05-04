using Contacts.Repositories;
using System.Windows;
using System.Windows.Controls;

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
            UpdateData();
        }

        private void UpdateData()
        {
            var contacts = ContactsRepository.GetAll();
            if (contacts.Count == 0) return;

            ContactsListView.ItemsSource = contacts;
        }

        private void NewContactButton_Click(object sender, RoutedEventArgs e)
        {
            new NewContactWindow().ShowDialog();
            UpdateData();
        }
    }
}
