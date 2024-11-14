using IBeauty.Database;
using IBeauty.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IBeauty.Models
{
    public class CadastroDoFornecedorDAO
    {
        private Conexao _conn = new Conexao();

        public void Insert(CadastroDoFornecedor obj)
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

                comando.CommandText = "INSERT INTO Fornecedor (nome_for, empresa_for, cpfcnpj_for, telefone_for, website_for, id_end_fk) " +
                                      "Values (@nome, @empresa, @cpfcnpj, @telefone, @website, @idendereco);";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@empresa", obj.Empresa);
                comando.Parameters.AddWithValue("@cpfcnpj", obj.CpfCnpj);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@website", obj.Website);
                comando.Parameters.AddWithValue("@idendereco", idEndereco);

                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Dados inseridos com sucesso na tabela Fornecedor.");
                }
                else
                {
                    Console.WriteLine("Nenhum dado foi inserido na tabela Fornecedor.");
                }
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



        public List<CadastroDoFornecedor> List()
        {
            try
            {
                var lista = new List<CadastroDoFornecedor>();
                var comando = _conn.Query();

                comando.CommandText = @"SELECT Fornecedor.id_for, Fornecedor.nome_for, Fornecedor.empresa_for, 
                               Fornecedor.cpfcnpj_for, Fornecedor.telefone_for, Fornecedor.website_for, 
                               Fornecedor.id_end_fk, Endereco.id_end, Endereco.rua_end, Endereco.bairro_end, 
                               Endereco.numero_end, Endereco.complemento_end, Endereco.cidade_end, 
                               Endereco.estado_end, Endereco.cep_end
                        FROM Fornecedor 
                        INNER JOIN Endereco ON Endereco.id_end = Fornecedor.id_end_fk";


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

                    var cadastro = new CadastroDoFornecedor
                    (
                        reader.GetInt32("id_for"),
                        reader.GetString("nome_for"),
                        reader.GetString("empresa_for"),
                        reader.GetString("cpfcnpj_for"),
                        reader.GetString("telefone_for"),
                        reader.GetString("website_for"),
                        endereco
                    );

                    lista.Add(cadastro);
                }

                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os fornecedores: {ex.Message}");
                return new List<CadastroDoFornecedor>();
            }
        }


        public void Delete(CadastroDoFornecedor obj)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Fornecedor WHERE id_for = @id";
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
                _conn.Close(); // Fecha a conexão após a exclusão
            }
        }

        public void Update(CadastroDoFornecedor obj)
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

                comando.CommandText = "UPDATE Fornecedor SET nome_for = @nome, empresa_for = @empresa, " +
                                      "cpfcnpj_for = @cpfcnpj, telefone_for = @telefone, website_for = @website " +
                                      "WHERE id_for = @id";
                comando.Parameters.Clear(); 
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@empresa", obj.Empresa);
                comando.Parameters.AddWithValue("@cpfcnpj", obj.CpfCnpj);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@website", obj.Website);
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
