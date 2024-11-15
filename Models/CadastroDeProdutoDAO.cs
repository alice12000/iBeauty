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
    public class CadastroDeProdutoDAO
    {

        private Conexao _conn = new Conexao();

        public void Insert(CadastroDeProduto obj)
        {
            MySqlTransaction transaction = null;
            try
            {
                Console.WriteLine("Iniciando inserção no banco...");
                var comando = _conn.Query();

                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                Console.WriteLine("Comando preparado.");

                comando.CommandText = "INSERT INTO Produto (id_pro, nome_pro, unidades_pro, descricao_pro, preco_unitario_pro, comissao_pro, preco_venda_pro) " +
                "VALUES (@id, @nome, @unidades, @descricao, @precoUnitario, @comissao, @precoVenda);";
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@unidades", obj.Unidades);
                comando.Parameters.AddWithValue("@descricao", obj.Descricao);
                comando.Parameters.AddWithValue("@precoUnitario", obj.PrecoUnitario);
                comando.Parameters.AddWithValue("@comissao", obj.Comissao);
                comando.Parameters.AddWithValue("@precoVenda", obj.PrecoFinal);

                // Apenas uma chamada ao ExecuteNonQuery()
                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Dados inseridos com sucesso na tabela Produto.");
                }
                else
                {
                    Console.WriteLine("Nenhum dado foi inserido na tabela Produto.");
                }

                transaction.Commit();
                Console.WriteLine("Produto cadastrado com sucesso!");
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


        public List<CadastroDeProduto> List()
        {
            try
            {
                var list = new List<CadastroDeProduto>();
                var comando = _conn.Query();

                comando.CommandText = @"SELECT id_pro, nome_pro, unidades_pro, descricao_pro, 
                               preco_unitario_pro, comissao_pro, preco_venda_pro 
                        FROM Produto";

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var produto = new CadastroDeProduto
                    (
                        reader.GetInt32("id_pro"),
                        reader.GetString("nome_pro"),
                        reader.GetInt32("unidades_pro"),
                        reader.GetString("descricao_pro"),
                        reader.GetDouble("preco_unitario_pro"),
                        reader.GetDouble("comissao_pro"),
                        reader.GetDouble("preco_venda_pro")
                    );

                    list.Add(produto);
                }

                reader.Close();
                return list;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar os produtos: {ex.Message}");
                return new List<CadastroDeProduto>();
            }
        }

        public void Delete(CadastroDeProduto obj)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Produto WHERE id_pro = @id";
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

        }
    }
}