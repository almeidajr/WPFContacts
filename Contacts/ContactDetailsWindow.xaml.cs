using System.Windows;
using Contacts.Models;
using Contacts.Repositories;

namespace Contacts;

/// <summary>
/// Interaction logic for ContactDetailsWindow.xaml
/// </summary>
public partial class ContactDetailsWindow : Window
{
    private readonly Contact _contact;

    public ContactDetailsWindow(Contact contact)
    {
        _contact = contact;
        InitializeComponent();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        ContactsRepository.Delete(_contact);
        Close();
    }
}
