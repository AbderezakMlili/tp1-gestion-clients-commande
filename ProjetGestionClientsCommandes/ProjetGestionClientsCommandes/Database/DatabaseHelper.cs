using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ProjetGestionClientsCommandes.Database
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = @"Server=.\SQLEXPRESS;Database=GestionClientsCommandes;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
