using IBeauty.Database;
using IBeauty.Models;
using MySql.Data.MySqlClient;
using System.Windows;
using System;

namespace IBeauty.Models
{
    public class UsuarioDAO
    {
        private static Conexao _conn = new Conexao();

        public Usuario GetByUsuario(string email)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "SELECT * FROM Usuario WHERE email_usu = @email";
                comando.Parameters.AddWithValue("@email", email);
                MySqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    var cadastro = new CadastroUsuarioDAO().GetById(reader.GetInt32("id_cad_fk"));

                    return new Usuario
                    (
                        reader.GetInt32("id_usu"),
                        reader.GetString("email_usu"),
                        reader.GetString("senha_usu"),
                        cadastro
                    );
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar o usuário: " + ex.Message);
            }
        }

        public CadastroUsuario AuthenticateCadastro(string email, string senha)
        {
            try
            {
                // Consulta SQL para verificar se o e-mail e a senha correspondem na tabela Cadastro
                var comando = _conn.Query();
                comando.CommandText = @"
            SELECT 
                Cadastro.id_cad,
                Cadastro.nome_cad,
                Cadastro.data_nascimento_cad,
                Cadastro.senha_cad,
                Cadastro.genero_cad,
                Cadastro.email_cad,
                Cadastro.telefone_cad
            FROM Cadastro
            WHERE Cadastro.email_cad = @email AND Cadastro.senha_cad = @senha";

                // Adiciona os parâmetros para o e-mail e senha
                comando.Parameters.AddWithValue("@email", email);
                comando.Parameters.AddWithValue("@senha", senha);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    // Verifica se a consulta retornou algum resultado
                    if (reader.Read())
                    {
                        // Se encontrar o usuário com o e-mail e senha, cria o objeto CadastroUsuario
                        return new CadastroUsuario
                        (
                            reader.GetInt32("id_cad"),
                            reader.GetString("nome_cad"),
                            reader.GetString("data_nascimento_cad"),
                            reader.GetString("senha_cad"),
                            reader.GetString("genero_cad"),
                            reader.GetString("email_cad"),
                            reader.GetString("telefone_cad"), 
                            null
                        );
                    }
                    else
                    {
                        MessageBox.Show("Credenciais inválidas. Tente novamente.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao autenticar o usuário: " + ex.Message);
            }
        }


    }
}
