using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace IBeauty.Database
{
    internal class Conexao
    {
        private string host = "localhost";
        private string port = "3306";
        private string user = "root";
        private string password = "root";
        private string dbname = "Ibeauty_bd";
        private MySqlConnection connection;
        private MySqlCommand command; 

        public Conexao()
        {
            connection = new MySqlConnection($"server={host};database={dbname};port={port};user={user};password={password}");
            connection.Open();
        }

        public MySqlCommand Query()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                return command;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar comando: " + ex.Message);
            }
        }

        public void Close()
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
