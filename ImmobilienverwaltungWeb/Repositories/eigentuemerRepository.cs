using ImmobilienverwaltungWeb.Models.ImmobilienverwaltungWeb.Models;
using Npgsql;


namespace ImmobilienverwaltungWeb.Repositories
{
    public class EigentuemerRepository
    {
        private string connectionString =
            "Host=localhost;Database=ImmobilienVerwaltung;User Id=dbuser;Password=dbuser;";

        private NpgsqlConnection ConnectToDB()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public List<Eigentuemer> GetAllEigentuemers()
        {
            List<Eigentuemer> eigentuemerList = new List<Eigentuemer>();

            using (NpgsqlConnection myConnection = ConnectToDB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM gebäude;", myConnection))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Eigentuemer newEigentuemer = new Eigentuemer
                            {
                                EigentuemerId = (int)reader["eigentuemerid"],
                                Email = (string)reader["email"],
                                Vorname = (string)reader["vorname"],
                                Nachname = (string)reader["nachname"],
                                Telefonnummer = (string)reader["telefonnummer"]
                            };
                            eigentuemerList.Add(newEigentuemer);
                        }
                    }
                }
            }

            return eigentuemerList;
        }

        public void CreateEigentuemer(Eigentuemer eigentuemer)
        {
            using (NpgsqlConnection myConnection = ConnectToDB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                           "INSERT INTO gebäude (eigentuemerid, email, vorname, nachname, telefonnummer) VALUES (@eigentuemerid, @Email, @Vorname, @Nachname, @Telefonnummer)",
                           myConnection))
                {
                    cmd.Parameters.AddWithValue("eigentuemerid", eigentuemer.EigentuemerId);
                    cmd.Parameters.AddWithValue("Email", eigentuemer.Email);
                    cmd.Parameters.AddWithValue("Vorname", eigentuemer.Vorname);
                    cmd.Parameters.AddWithValue("Nachname", eigentuemer.Nachname);
                    cmd.Parameters.AddWithValue("Telefonnummer", eigentuemer.Telefonnummer);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEigentuemer(int eigentuemerId)
        {
            using (NpgsqlConnection myConnection = ConnectToDB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM gebäude WHERE eigentuemerid = @eigentuemerid",
                           myConnection))
                {
                    cmd.Parameters.AddWithValue("eigentuemerid", eigentuemerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEigentuemer(Eigentuemer eigentuemer)
        {
            using (NpgsqlConnection myConnection = ConnectToDB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand(
                           "UPDATE gebäude SET email = @Email, vorname = @Vorname, nachname = @Nachname, telefonnummer = @Telefonnummer WHERE eigentuemerid = @eigentuemerid",
                           myConnection))
                {
                    cmd.Parameters.AddWithValue("eigentuemerid", eigentuemer.EigentuemerId);
                    cmd.Parameters.AddWithValue("Email", eigentuemer.Email);
                    cmd.Parameters.AddWithValue("Vorname", eigentuemer.Vorname);
                    cmd.Parameters.AddWithValue("Nachname", eigentuemer.Nachname);
                    cmd.Parameters.AddWithValue("Telefonnummer", eigentuemer.Telefonnummer);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}