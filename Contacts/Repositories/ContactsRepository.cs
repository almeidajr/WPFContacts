using Contacts.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Repositories;

public class ContactsRepository
{
    private static readonly string _databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "contacts.db");

    public static void Create(Contact contact)
    {
        using var connection = new SQLiteConnection(_databasePath);
        connection.CreateTable<Contact>();
        connection.Insert(contact);
    }

    public static IList<Contact> GetAll()
    {
        using var connection = new SQLiteConnection(_databasePath);
        connection.CreateTable<Contact>();
        return connection.Table<Contact>().ToList();
    }
}    