using System.Data;
using Microsoft.Data.SqlClient;

try
{
    var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database.mdf;TrustServerCertificate=True";

    // ----------
    // Connection
    // ----------
    using var connection = new SqlConnection(connectionString);

    // -------
    // Command
    // -------
    var comKlanten = connection.CreateCommand();
    comKlanten.CommandType = CommandType.Text;
    comKlanten.CommandText = "select Voornaam, Familienaam from klanten";

    connection.Open();
    Console.WriteLine("Database geopend");

    // ------
    // Reader
    // ------
    using var rdrKlanten = comKlanten.ExecuteReader();

    var klantFamilienaamPos = rdrKlanten.GetOrdinal("Familienaam");
    var klantVoornaamPos = rdrKlanten.GetOrdinal("Voornaam");

    while (rdrKlanten.Read())
        Console.WriteLine($"{rdrKlanten.GetString(klantVoornaamPos)} {rdrKlanten.GetString(klantFamilienaamPos)}");

    Console.WriteLine();
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}");
}
