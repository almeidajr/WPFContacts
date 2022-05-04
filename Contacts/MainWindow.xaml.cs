using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Contacts.Models;
using Contacts.Repositories;

namespace Contacts;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<Contact> contacts = new();

    public MainWindow()
    {
        InitializeComponent();
        UpdateData();
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    private void UpdateData()
    {
        contacts = ContactsRepository
            .GetAll()
            .OrderBy(c => c.Name)
            .ToList();
        if (contacts.Count == 0) return;

        ContactsListView.ItemsSource = contacts;
    }

    private void NewContactButton_Click(object sender, RoutedEventArgs e)
    {
        new NewContactWindow().ShowDialog();
        UpdateData();
    }

    private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ContactsListView.SelectedItem is not Contact contact) return;
        new ContactDetailsWindow(contact).ShowDialog();
        UpdateData();
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var searchBox = sender as TextBox;
        var searchText = searchBox?.Text.ToLower();
        if (string.IsNullOrWhiteSpace(searchText))
        {
            ContactsListView.ItemsSource = contacts;
        }
        else
        {
            ContactsListView.ItemsSource = contacts.FindAll(
                c => c.Name.ToLower().Contains(searchText));
        }
    }
}

