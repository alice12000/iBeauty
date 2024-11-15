    using IBeauty.Database;
    using IBeauty.Helpers;
    using IBeauty.Telas;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace IBeauty.Models
    {
        public class CadastroDeFuncionarioDAO
        {
            private Conexao _conn = new Conexao();
            public void Insert(CadastroDeFuncionario obj)
            {
                MySqlTransaction transaction = null;
                try
                {
                    Console.WriteLine("Iniciando inserção no banco...");
                    var comando = _conn.Query();

                    transaction = comando.Connection.BeginTransaction();
                    comando.Transaction = transaction;

                    Console.WriteLine("Comando preparado.");

                    comando.CommandText = "SELECT id_end FROM Endereco WHERE rua_end = @rua AND bairro_end = @bairro AND cep_end = @cep";
                    comando.Parameters.AddWithValue("@rua", obj.Endereco.Rua);
                    comando.Parameters.AddWithValue("@bairro", obj.Endereco.Bairro);
                    comando.Parameters.AddWithValue("@cep", obj.Endereco.Cep);

                    object result = comando.ExecuteScalar();

                    int idEndereco;

                    if (result != null)
                    {
                        idEndereco = Convert.ToInt32(result);
                        Console.WriteLine("Endereço já existente. Usando o ID: " + idEndereco);
                    }
                    else
                    {
                        comando.CommandText = "INSERT INTO Endereco (rua_end, bairro_end, numero_end, complemento_end, cidade_end, estado_end, cep_end) " +
                               "VALUES (@rua, @bairro, @numero, @complemento, @cidade, @estado, @cep);";
                        comando.Parameters.AddWithValue("@numero", obj.Endereco.Numero);
                        comando.Parameters.AddWithValue("@complemento", obj.Endereco.Complemento);
                        comando.Parameters.AddWithValue("@cidade", obj.Endereco.Cidade);
                        comando.Parameters.AddWithValue("@estado", obj.Endereco.Estado);

                        comando.ExecuteNonQuery();

                        comando.CommandText = "SELECT LAST_INSERT_ID()";
                        idEndereco = Convert.ToInt32(comando.ExecuteScalar());
                        Console.WriteLine("Novo endereço inserido. ID: " + idEndereco);
                    }

                    comando.CommandText = "INSERT INTO Funcionario (nome_func, telefone_func, genero_func, email_func, observacao_func, data_nascimento_func, expediente_func, categoria_func, id_end_fk) " +
                                          "VALUES (@nome, @telefone, @genero, @email, @observacao, @dataNascimento, @expediente, @categoria, @idendereco);";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@nome", obj.Nome);
                    comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                    comando.Parameters.AddWithValue("@genero", obj.Genero);
                    comando.Parameters.AddWithValue("@email", obj.Email);
                    comando.Parameters.AddWithValue("@observacao", obj.Observacao);
                    comando.Parameters.AddWithValue("@dataNascimento", obj.DataNascimento);
                    comando.Parameters.AddWithValue("@expediente", obj.Expediente);
                    comando.Parameters.AddWithValue("@categoria", obj.Categoria);
                    comando.Parameters.AddWithValue("@idendereco", idEndereco);

                    int rowsAffected = comando.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Dados inseridos com sucesso na tabela Funcionario.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum dado foi inserido na tabela Funcionario.");
                    }
                    transaction.Commit();
                    Console.WriteLine("Funcionário cadastrado com sucesso!");
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



            public List<CadastroDeFuncionario> List()
            {
                try
                {
                    var lista = new List<CadastroDeFuncionario>();
                    var comando = _conn.Query();

                    comando.CommandText = @"SELECT Funcionario.id_func, Funcionario.nome_func, Funcionario.telefone_func, 
                                            Funcionario.genero_func, Funcionario.email_func, Funcionario.observacao_func, 
                                            Funcionario.data_nascimento_func, Funcionario.expediente_func, 
                                            Funcionario.categoria_func, Funcionario.id_end_fk, Endereco.id_end, 
                                            Endereco.rua_end, Endereco.bairro_end, Endereco.numero_end, Endereco.complemento_end, 
                                            Endereco.cidade_end, Endereco.estado_end, Endereco.cep_end
                            FROM Funcionario 
                            INNER JOIN Endereco ON Endereco.id_end = Funcionario.id_end_fk";

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

                        var cadastro = new CadastroDeFuncionario
                        (
                            reader.GetInt32("id_func"),
                            reader.GetString("nome_func"),
                            reader.GetString("telefone_func"),
                            DAOHelper.GetString(reader, "genero_func"),
                            DAOHelper.GetString(reader, "email_func"),
                            DAOHelper.GetString(reader, "observacao_func"),
                            DAOHelper.GetString(reader, "data_nascimento_func"),
                            DAOHelper.GetString(reader, "expediente_func"),
                            DAOHelper.GetString(reader, "categoria_func"),
                            endereco
                        );

                        lista.Add(cadastro);
                    }

                    reader.Close();
                    return lista;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao carregar os funcionários: {ex.Message}");
                    return new List<CadastroDeFuncionario>();
                }
            }

            public void Delete(CadastroDeFuncionario obj)
            {
                try
                {
                    var comando = _conn.Query();
                    comando.CommandText = "DELETE FROM Funcionario WHERE id_func = @id";
                    comando.Parameters.AddWithValue("@id", obj.Id);

                    _conn.Open();
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

            public void Update(CadastroDeFuncionario obj)
            {
                MySqlTransaction transaction = null;
                try
                {
                    Console.WriteLine("Iniciando atualização no banco...");
                    var comando = _conn.Query();

                    transaction = comando.Connection.BeginTransaction();
                    comando.Transaction = transaction;

                    comando.CommandText = "SELECT id_end FROM Endereco WHERE rua_end = @rua AND bairro_end = @bairro AND cep_end = @cep";
                    comando.Parameters.AddWithValue("@rua", obj.Endereco.Rua);
                    comando.Parameters.AddWithValue("@bairro", obj.Endereco.Bairro);
                    comando.Parameters.AddWithValue("@cep", obj.Endereco.Cep);

                    object result = comando.ExecuteScalar();

                    int idEndereco;

                    if (result != null)
                    {
                        idEndereco = Convert.ToInt32(result);
                        Console.WriteLine("Endereço já existente. Usando o ID: " + idEndereco);
                    }
                    else
                    {
                        comando.CommandText = "INSERT INTO Endereco (rua_end, bairro_end, numero_end, complemento_end, cidade_end, estado_end, cep_end) " +
                            "VALUES (@rua, @bairro, @numero, @complemento, @cidade, @estado, @cep);";
                        comando.Parameters.AddWithValue("@numero", obj.Endereco.Numero);
                        comando.Parameters.AddWithValue("@complemento", obj.Endereco.Complemento);
                        comando.Parameters.AddWithValue("@cidade", obj.Endereco.Cidade);
                        comando.Parameters.AddWithValue("@estado", obj.Endereco.Estado);

                        comando.ExecuteNonQuery();

                        comando.CommandText = "SELECT LAST_INSERT_ID()";
                        idEndereco = Convert.ToInt32(comando.ExecuteScalar());
                        Console.WriteLine("Novo endereço inserido. ID: " + idEndereco);
                    }

                    comando.CommandText = "UPDATE Funcionario SET nome_func = @nome, telefone_func = @telefone, " +
                                          "genero_func = @genero, email_func = @email, observacao_func = @observacao, " +
                                          "data_nascimento_func = @dataNascimento, expediente_func = @expediente, " +
                                          "categoria_func = @categoria WHERE id_func = @id";
                    comando.Parameters.Clear();
                    comando.Parameters.AddWithValue("@nome", obj.Nome);
                    comando.Parameters.AddWithValue("@email", obj.Email);
                    comando.Parameters.AddWithValue("@observacao", obj.Observacao);
                    comando.Parameters.AddWithValue("@dataNascimento", obj.DataNascimento);
                    comando.Parameters.AddWithValue("@expediente", obj.Expediente);
                    comando.Parameters.AddWithValue("@categoria", obj.Categoria);
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

