using IBeauty.Database;
using IBeauty.Models;
using MySql.Data.MySqlClient;
using System.Windows;
using System;

public class UsuarioDAO
{
    private static Conexao _conn = new Conexao();

    public void Insert(Usuario usuario)
    {
        try
        {
            if (_conn == null)
            {
                throw new Exception("A conexão com o banco de dados não foi estabelecida.");
            }

            var comando = _conn.Query();
            comando.CommandText = "INSERT INTO Usuario (email_usu, senha_usu, id_cad_fk) VALUES (@email, @senha, @id_cad_fk)";
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@senha", usuario.Senha);
            comando.Parameters.AddWithValue("@id_cad_fk", usuario.Cadastro.Id); // Certifique-se de passar o id do Cadastro
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
            comando.CommandText = "SELECT * FROM Usuario WHERE email_usu = @email";
            comando.Parameters.AddWithValue("@email", email);
            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.Read())
            {
                // Obter o Cadastro relacionado ao Usuario
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

    public Usuario AuthenticateUser(string email, string senha)
    {
        var comando = _conn.Query();
        comando.CommandText = "SELECT id_usu, email_usu, senha_usu, id_cad_fk FROM Usuario WHERE email_usu = @email";
        comando.Parameters.AddWithValue("@email", email);

        using (MySqlDataReader reader = comando.ExecuteReader())
        {
            if (reader.Read())
            {
                // Comparar a senha informada com a senha armazenada no banco
                string senhaSalva = reader.GetString("senha_usu");

                if (senhaSalva == senha) // Se a senha bater
                {
                    // Obter id_cad_fk que referencia o CadastroUsuario
                    int idCadastro = reader.GetInt32("id_cad_fk");

                    // Fechar o DataReader anterior antes de abrir o próximo
                    reader.Close();

                    // Criar a consulta para buscar o CadastroUsuario
                    var comandoCadastro = _conn.Query();
                    comandoCadastro.CommandText = "SELECT * FROM Cadastro WHERE id_cad = @id";
                    comandoCadastro.Parameters.AddWithValue("@id", idCadastro);

                    using (MySqlDataReader readerCadastro = comandoCadastro.ExecuteReader())
                    {
                        CadastroUsuario cadastro = null;

                        if (readerCadastro.Read())
                        {
                            cadastro = new CadastroUsuario
                            (
                                readerCadastro.GetInt32("id_cad"),
                                readerCadastro.GetString("nome_cad"),
                                readerCadastro.GetString("data_nascimento_cad"),
                                readerCadastro.GetString("senha_cad"),
                                readerCadastro.GetString("genero_cad"),
                                readerCadastro.GetString("email_cad"),
                                readerCadastro.GetString("telefone_cad"),
                                new Endereco
                                (
                                    readerCadastro.GetInt32("id_end"),
                                    readerCadastro.GetString("rua_end"),
                                    readerCadastro.GetString("bairro_end"),
                                    readerCadastro.GetInt32("numero_end"),
                                    readerCadastro.GetString("complemento_end"),
                                    readerCadastro.GetString("cidade_end"),
                                    readerCadastro.GetString("estado_end"),
                                    readerCadastro.GetString("cep_end")
                                )
                            );
                        }

                        // Agora retornar o objeto Usuario com o CadastroUsuario associado
                        return new Usuario
                        (
                            reader.GetInt32("id_usu"),
                            reader.GetString("email_usu"),
                            reader.GetString("senha_usu"),
                            cadastro // Associando o cadastro ao usuario
                        );
                    }
                }
                else
                {
                    // Senha incorreta
                    MessageBox.Show("Senha incorreta. Tente novamente.");
                    return null;
                }
            }
            else
            {
                // Usuário não encontrado
                MessageBox.Show("Usuário não encontrado. Tente novamente.");
                return null;
            }
        }
    }
}
