using ImmobilienverwaltungWeb.Models;
using Npgsql;

namespace ImmobilienverwaltungWeb.Repositories;

public class ImmobilienRepository
{
    private NpgsqlConnection ConnectToDB()
    {
        string connectionString = "Host=localhost;Database=ImmobilienVerwaltung;User Id=dbuser;Password=dbuser;";
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        
        connection.Open();
        return connection;
    }
    public List<Immobilien> GetAllImmobiliens()
    {
        //Connect to DB,
        NpgsqlConnection myConnection = ConnectToDB();
        //SQL Query ausführen,
        
        using NpgsqlCommand cmd = new NpgsqlCommand("Select * from Immobilien;", myConnection);

        using NpgsqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Immobilien newImmobilien = new Immobilien();
            newImmobilien.ImmobilienID = (int) reader["eigentuemerid"];
            newImmobilien.Email = (string) reader["Email"];
            newImmobilien.Vorname = (string) reader["Vorname"];
            newImmobilien.Nachname = (string)reader["Nachname"];
            newImmobilien.Telefonnummer = (int)reader["Telefonnummer"];
            
            Immobilien.add(newImmobilien);
        }
        //Datensätze in Objekte umwandeln,
        //mit return ausgeben
        


        myConnection.Close();
        return new List<Immobilien>();
    }

    public void CreateImmobilie(Immobilien immobilien)
    {
        
    }

    public void DeleteImmobilie(int immobilienId)
    {
        
    }

    public void UptadeImmobilie(Immobilien immobilien)
    {
        
    }
}