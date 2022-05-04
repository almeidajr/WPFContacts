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
        InitializeContactForm();
        Owner = Application.Current.MainWindow;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
    }

    private void InitializeContactForm()
    {
        NameField.Text = _contact.Name;
        EmailField.Text = _contact.Email;
        PhoneField.Text = _contact.Phone;
    }

    private void SyncContactForm()
    {
        _contact.Name = NameField.Text;
        _contact.Email = EmailField.Text;
        _contact.Phone = PhoneField.Text;
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        SyncContactForm();
        ContactsRepository.Update(_contact);
        Close();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        ContactsRepository.Delete(_contact);
        Close();
    }
}
