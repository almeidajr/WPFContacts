using System;
using System.Windows;
using System.Windows.Controls;
using Contacts.Models;

namespace Contacts.Controls;

/// <summary>
/// Interaction logic for ContactControl.xaml
/// </summary>
public partial class ContactControl : UserControl
{
    public Contact Contact
    {
        get => (Contact)GetValue(ContactProperty);
        set => SetValue(ContactProperty, value);
    }

    // Using a DependencyProperty as the backing store for Contact.
    // This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ContactProperty =
        DependencyProperty.Register(
            "Contact",
            typeof(Contact),
            typeof(ContactControl),
            new PropertyMetadata(null, OnContactChanged));

    public ContactControl()
    {
        InitializeComponent();
    }

    private static void OnContactChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as ContactControl;
        var contact = e.NewValue as Contact;

        ArgumentNullException.ThrowIfNull(control);
        ArgumentNullException.ThrowIfNull(contact);

        control.NameTextBlock.Text = contact.Name;
        control.EmailTextBlock.Text = contact.Email;
        control.PhoneTextBlock.Text = contact.Phone;
    }
}

