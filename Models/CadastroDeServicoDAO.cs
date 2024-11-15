using IBeauty.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IBeauty.Models
{
    public class CadastroDeServicoDAO
    {
        private Conexao _conn = new Conexao();

        public void Insert(CadastroDeServico obj)
        {
            MySqlTransaction transaction = null;
            try
            {
                Console.WriteLine("Iniciando inserção no banco...");
                var comando = _conn.Query();

                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                Console.WriteLine("Comando preparado.");

                comando.CommandText = "INSERT INTO Servico (id_ser, descricao_ser, " +
                    "preco_unitario_ser, comissao_ser, preco_venda_ser, duracao_ser, retorno_ser, categoria_ser, id_fun_fk, servico_ser) " +
                "VALUES (@id, @descricao, @precoUnitario,@comissao, @precofinal, " +
                "@duracao, @retorno, @categoria, @funcionario, @nome;";
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@descricao", obj.Descricao);
                comando.Parameters.AddWithValue("@precoUnitario", obj.PrecoUnitario);
                comando.Parameters.AddWithValue("@comissao", obj.Comissao);
                comando.Parameters.AddWithValue("@precofinal", obj.PrecoFinal);
                comando.Parameters.AddWithValue("@duracao", obj.Duracao);
                comando.Parameters.AddWithValue("@retorno", obj.Retorno);
                comando.Parameters.AddWithValue("@categoria", obj.Categoria);
                comando.Parameters.AddWithValue("@funcionario", obj.Funcionario);
                comando.Parameters.AddWithValue("@nome", obj.Servico);


                // Apenas uma chamada ao ExecuteNonQuery()
                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Dados inseridos com sucesso na tabela Serviço.");
                }
                else
                {
                    Console.WriteLine("Nenhum dado foi inserido na tabela Serviço.");
                }

                transaction.Commit();
                Console.WriteLine("Serviço cadastrado com sucesso!");
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


        public List<CadastroDeServico> List()
        {
            try
            {
                var list = new List<CadastroDeServico>();
                var comando = _conn.Query();

                comando.CommandText = @"SELECT id_ser, descricao_ser, categoria_ser,
                preco_unitario_ser, comissao_ser,id_fun_fk, retorno_ser,duracao_ser, preco_venda_ser, servico_ser FROM Servico";

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var servico = new CadastroDeServico
                    (
                        reader.GetInt32("id_ser"),
                        reader.GetString("descricao_ser"),
                        reader.GetString("categoria_ser"),
                        reader.GetDouble("preco_unitario_ser"),
                        reader.GetDouble("comissao_ser"),
                        reader.GetInt32("id_fun_fk"),
                        reader.GetInt32("retorno_ser"),
                        reader.GetInt32("duracao_ser"),
                        reader.GetDouble("preco_venda_ser"),
                        reader.GetString("servico_ser")
                    );

                    list.Add(servico);
                }

                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os serviços: {ex.Message}");
                return new List<CadastroDeServico>();
            }
        }

        public void Delete(CadastroDeServico obj)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Servico WHERE id_ser = @id";
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

        /*
        public void Update(CadastroDeProduto obj)
        {
            MySqlTransaction transaction = null;
            try
            {
                Console.WriteLine("Iniciando atualização no banco...");
                var comando = _conn.Query();

                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;
                object result = comando.ExecuteScalar();

                comando.CommandText = "INSERT INTO Produto (nome_pro, unidades_pro, descricao_pro, preco_unitario_pro, comissao_pro, preco_venda_pro) " +
                                    "VALUES (@nome, @unidades, @descricao, @precoUnitario, @comissao, @precoVenda);";
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@unidades", obj.Unidades);
                comando.Parameters.AddWithValue("@descricao", obj.Descricao);
                comando.Parameters.AddWithValue("@precoUnitario", obj.PrecoUnitario);
                comando.Parameters.AddWithValue("@comissao", obj.Comissao);
                comando.Parameters.AddWithValue("@precoVenda", obj.PrecoFinal);
                comando.ExecuteNonQuery();

                comando.CommandText = "SELECT LAST_INSERT_ID()";
                object idProduto = comando.ExecuteScalar();
                Console.WriteLine("Novo produto inserido. ID: " + idProduto);

                transaction.Commit();
                Console.WriteLine("Dados do produto inseridos com sucesso!");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("Erro: " + ex.Message);
                throw new Exception("Erro ao salvar as informações do produto: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }

        */


    }
}