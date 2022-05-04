using Contacts.Models;
using Contacts.Repositories;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
    }

    private void UpdateData()
    {
        contacts = ContactsRepository.GetAll();
        if (contacts.Count == 0) return;

        ContactsListView.ItemsSource = contacts;
    }

    private void NewContactButton_Click(object sender, RoutedEventArgs e)
    {
        new NewContactWindow().ShowDialog();
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

