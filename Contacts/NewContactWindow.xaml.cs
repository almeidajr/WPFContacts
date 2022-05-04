using System.Windows;
using Contacts.Models;
using Contacts.Repositories;

namespace Contacts;

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
        var contact = new Contact
        {
            Name = NameField.Text,
            Email = EmailField.Text,
            Phone = PhoneField.Text,
        };
        ContactsRepository.Create(contact);

        Close();
    }
}
