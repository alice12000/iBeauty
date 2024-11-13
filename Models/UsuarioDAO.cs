using IBauty.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    internal class UsuarioDAO
    {
        private static Conexao _conn = new Conexao();
        public void Insert(Usuario usuario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Usuario (email_usu, senha_usu) VALUES (@email, @senha)";

                comando.Parameters.AddWithValue("@email", usuario.Email);
                comando.Parameters.AddWithValue("@senha", usuario.Senha);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Erro ao salvar o usuário.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o usuário: " + ex.Message);
            }
        }

        public Usuario GetByUsuario(string email)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "SELECT * FROM Usuario WHERE email = @email";
                comando.Parameters.AddWithValue("@email", email);

                MySqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = reader.GetInt32("id_usu"),
                        Email = reader.GetString("email_usu"),
                        Senha = reader.GetString("senha_usu")
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuário: " + ex.Message);
            }
        }
    }
}
