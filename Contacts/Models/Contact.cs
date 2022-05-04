using SQLite;
using System.Text;

namespace Contacts.Models;

public class Contact
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public override string? ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"Name: {Name}");
        builder.AppendLine($"Phone: {Phone}");
        builder.AppendLine($"Email: {Email}");
        return builder.ToString();
    }
}
