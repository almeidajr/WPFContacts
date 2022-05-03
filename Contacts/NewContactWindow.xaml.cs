using Contacts.Models;
using SQLite;
using System;
using System.IO;
using System.Windows;

namespace Contacts
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var contact = new Contact()
            {
                Name = NameField.Text,
                Email = EmailField.Text,
                Phone = PhoneField.Text,
            };
            var database = "contacts.db";
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(directory, database);
            using var connection = new SQLiteConnection(path);
            connection.CreateTable<Contact>();
            connection.Insert(contact);

            Close();
        }
    }
}
