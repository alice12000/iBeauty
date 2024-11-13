using IBeauty.Database;
using IBeauty.Helpers;
using IBeauty.Telas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace IBeauty.Models
{
    public class CadastroUsuarioDAO
    {
        private Conexao _conn = new Conexao();

        public void Insert(CadastroUsuario obj)
        {
            MySqlTransaction transaction = null;
            try
            {
                Console.WriteLine("Iniciando inserção no banco...");
                var comando = _conn.Query();

                // Iniciar transação
                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                Console.WriteLine("Comando preparado.");

                // Verificar se o endereço já existe
                comando.CommandText = "SELECT id_end FROM Endereco WHERE rua_end = @rua AND bairro_end = @bairro AND cep_end = @cep";
                comando.Parameters.AddWithValue("@rua", obj.Endereco.Rua);
                comando.Parameters.AddWithValue("@bairro", obj.Endereco.Bairro);
                comando.Parameters.AddWithValue("@cep", obj.Endereco.Cep);

                object result = comando.ExecuteScalar();

                int idEndereco;

                if (result != null)
                {
                    // O endereço já existe, obter o ID
                    idEndereco = Convert.ToInt32(result);
                    Console.WriteLine("Endereço já existente. Usando o ID: " + idEndereco);
                }
                else
                {
                    // Endereço não existe, inserir
                    comando.CommandText = "INSERT INTO Endereco (rua_end, bairro_end, numero_end, complemento_end, cidade_end, estado_end, cep_end) " +
                           "VALUES (@rua, @bairro, @numero, @complemento, @cidade, @estado, @cep)";
                    comando.Parameters.AddWithValue("@numero", obj.Endereco.Numero);
                    comando.Parameters.AddWithValue("@complemento", obj.Endereco.Complemento);
                    comando.Parameters.AddWithValue("@cidade", obj.Endereco.Cidade);
                    comando.Parameters.AddWithValue("@estado", obj.Endereco.Estado);

                    // Executar o comando para inserir o endereço
                    comando.ExecuteNonQuery();

                    // Obter o ID do endereço inserido
                    comando.CommandText = "SELECT LAST_INSERT_ID()";
                    idEndereco = Convert.ToInt32(comando.ExecuteScalar());
                    Console.WriteLine("Novo endereço inserido. ID: " + idEndereco);
                }

                // Agora inserir o cadastro com o id_end_fk (id do endereço)
                comando.CommandText = "INSERT INTO Cadastro (nome_cad, data_nascimento_cad, senha_cad, genero_cad, email_cad, telefone_cad, id_end_fk) " +
                                      "VALUES (@nome, @datanascimento, @senha, @genero, @email, @telefone, @idendereco)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@datanascimento", obj.DataNascimento);
                comando.Parameters.AddWithValue("@senha", obj.Senha);
                comando.Parameters.AddWithValue("@genero", obj.Genero);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@idendereco", idEndereco);

                comando.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("Erro: " + ex.Message);
                throw new Exception("Erro ao salvar as informações: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

    

    public List<CadastroUsuario> List()
        {
            try
            {
                var lista = new List<CadastroUsuario>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT Cadastro.id_cad, Cadastro.nome_cad, Cadastro.data_nascimento_cad, Cadastro.senha_cad, Cadastro.genero_cad, Cadastro.email_cad, Cadastro.telefone_cad, " +
                    "Endereco.id_end, Endereco.rua_end, Endereco.bairro_end, Endereco.numero_end, Endereco.complemento_end, Endereco.cidade_end, Endereco.estado_end, Endereco.cep_end " +
                    "FROM Cadastro INNER JOIN Endereco ON Cadastro.id_end_fk = Endereco.id_end";

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Endereco endereco = new Endereco
                    (
                        reader.GetInt32("id_end"),
                        DAOHelper.GetString(reader, "rua_end"),
                        DAOHelper.GetString(reader, "bairro_end"),
                        reader.GetInt32("numero_end"),
                        DAOHelper.GetString(reader, "complemento_end"),
                        DAOHelper.GetString(reader, "cidade_end"),
                        DAOHelper.GetString(reader, "estado_end"),
                        DAOHelper.GetString(reader, "cep_end")
                    );

                    var cadastro = new CadastroUsuario
                    (
                        reader.GetInt32("id_cad"),
                        reader.GetString("nome_cad"),
                        reader.GetString("data_nascimento_cad"),
                        reader.GetString("senha_cad"),
                        reader.GetString("genero_cad"),
                        reader.GetString("email_cad"),
                        reader.GetString("telefone_cad"),
                        endereco
                    );

                    lista.Add(cadastro);
                }

                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(CadastroUsuario obj)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Cadastro WHERE id_cad = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Update(CadastroUsuario obj)
        {
            MySqlTransaction transaction = null;
            try
            {
                Console.WriteLine("Iniciando atualização no banco...");
                var comando = _conn.Query();

                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                comando.CommandText = "UPDATE Endereco SET rua_end = @rua, bairro_end = @bairro, numero_end = @numero, " +
                                      "complemento_end = @complemento, cidade_end = @cidade, estado_end = @estado, cep_end = @cep " +
                                      "WHERE id_end = @id";
                comando.Parameters.AddWithValue("@rua", obj.Endereco.Rua);
                comando.Parameters.AddWithValue("@bairro", obj.Endereco.Bairro);
                comando.Parameters.AddWithValue("@numero", obj.Endereco.Numero);
                comando.Parameters.AddWithValue("@complemento", obj.Endereco.Complemento);
                comando.Parameters.AddWithValue("@cidade", obj.Endereco.Cidade);
                comando.Parameters.AddWithValue("@estado", obj.Endereco.Estado);
                comando.Parameters.AddWithValue("@cep", obj.Endereco.Cep);
                comando.Parameters.AddWithValue("@id", obj.Endereco.Id);

                comando.ExecuteNonQuery();

                comando.CommandText = "UPDATE Cadastro SET nome_cad = @nome, data_nascimento_cad = @datanascimento, " +
                                      "senha_cad = @senha, genero_cad = @genero, email_cad = @email, telefone_cad = @telefone " +
                                      "WHERE id_cad = @id";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@datanascimento", obj.DataNascimento);
                comando.Parameters.AddWithValue("@senha", obj.Senha);
                comando.Parameters.AddWithValue("@genero", obj.Genero);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@id", obj.Id);

                comando.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("Erro: " + ex.Message);
                throw new Exception("Erro ao salvar as informações: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
