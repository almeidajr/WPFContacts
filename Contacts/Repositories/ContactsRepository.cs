using System;
using System.Collections.Generic;
using System.IO;
using Contacts.Models;
using SQLite;

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

    public static List<Contact> GetAll()
    {
        using var connection = new SQLiteConnection(_databasePath);
        connection.CreateTable<Contact>();
        return connection.Table<Contact>().ToList();
    }

    public static void Update(Contact contact)
    {
        using var connection = new SQLiteConnection(_databasePath);
        connection.CreateTable<Contact>();
        connection.Update(contact);
    }

    public static void Delete(Contact contact)
    {
        using var connection = new SQLiteConnection(_databasePath);
        connection.CreateTable<Contact>();
        connection.Delete(contact);
    }
}