using ImmobilienverwaltungWeb.Models;
using Npgsql;
using System.Collections.Generic;

namespace ImmobilienverwaltungWeb.Repositories
{
    public class ImmobilienartRepository
    {
        private string connectionString = "Host=localhost;Database=ImmobilienVerwaltung;User Id=dbuser;Password=dbuser;";

        private NpgsqlConnection ConnectToDB()
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public List<Immobilienart> GetAllImmobilienarten()
        {
            List<Immobilienart> immobilienartList = new List<Immobilienart>();

            using (NpgsqlConnection myConnection = ConnectToDB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM immobilienart;", myConnection))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Immobilienart newImmobilienart = new Immobilienart
                            {
                                ImmobilienartId = (int)reader["immobilienartid"],
                                Bezeichnung = (string)reader["bezeichnung"]
                            };
                            immobilienartList.Add(newImmobilienart);
                        }
                    }
                }
            }
            return immobilienartList;
        }

        public void CreateImmobilienart(Immobilienart immobilienart)
        {
            using (NpgsqlConnection myConnection = ConnectToDB())
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO immobilienart (immobilienartid, bezeichnung) VALUES (@immobilienartid, @Bezeichnung)", myConnection))
                {
                    cmd.Parameters.AddWithValue("immobilienartid", immobili