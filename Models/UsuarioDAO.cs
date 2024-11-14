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

        public Usuario AuthenticateEmail(string email, string senha)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = @"
                    SELECT 
                        Usuario.id_usu, 
                        Usuario.email_usu, 
                        Usuario.senha_usu, 
                        Usuario.id_cad_fk,
                        Cadastro.nome_cad, 
                        Cadastro.data_nascimento_cad, 
                        Cadastro.senha_cad, 
                        Cadastro.genero_cad, 
                        Cadastro.email_cad, 
                        Cadastro.telefone_cad, 
                        Endereco.id_end, 
                        Endereco.rua_end, 
                        Endereco.bairro_end, 
                        Endereco.numero_end, 
                        Endereco.complemento_end, 
                        Endereco.cidade_end, 
                        Endereco.estado_end, 
                        Endereco.cep_end
                    FROM Usuario 
                    INNER JOIN Cadastro ON Usuario.id_cad_fk = Cadastro.id_cad
                    LEFT JOIN Endereco ON Cadastro.id_end_fk = Endereco.id_end
                    WHERE Usuario.email_usu = @email";
                comando.Parameters.AddWithValue("@email", email);

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string senhaSalva = reader.GetString("senha_usu");

                        if (senhaSalva == senha) 
                        {
                            var endereco = reader.IsDBNull(reader.GetOrdinal("id_end")) ? null : new Endereco
                            (
                                reader.GetInt32("id_end"),
                                reader.GetString("rua_end"),
                                reader.GetString("bairro_end"),
                                reader.GetInt32("numero_end"),
                                reader.GetString("complemento_end"),
                                reader.GetString("cidade_end"),
                                reader.GetString("estado_end"),
                                reader.GetString("cep_end")
                            );

                            CadastroUsuario cadastro = new CadastroUsuario
                            (
                                reader.GetInt32("id_cad_fk"),
                                reader.GetString("nome_cad"),
                                reader.GetString("data_nascimento_cad"),
                                reader.GetString("senha_cad"),
                                reader.GetString("genero_cad"),
                                reader.GetString("email_cad"),
                                reader.GetString("telefone_cad"),
                                endereco
                            );

                            return new Usuario
                            (
                                reader.GetInt32("id_usu"), 
                                reader.GetString("email_usu"),
                                reader.GetString("senha_usu"),
                                cadastro
                            );
                        }
                        else
                        {
                            MessageBox.Show("Senha incorreta. Tente novamente.");
                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado. Tente novamente.");
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
