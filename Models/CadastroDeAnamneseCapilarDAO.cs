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
    public class CadastroDeAnamneseCapilarDAO
    {
        private Conexao _conn = new Conexao();
        public void Insert(CadastroDeAnamneseCapilar obj)
        {
            MySqlTransaction transaction = null;
            
                var comando = _conn.Query();

                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                // Verifica se o endereço já existe


                // Insere os dados da anamnese capilar
                comando.CommandText = "INSERT INTO AnamneseCapilar (tipo_cabelo_ancap, comprimento_ancap, caracteristica_ancap, elasticidade_ancap, " +
                                      "pigmento_ancap, espessura_ancap, observacao_ancap, tingimento, alisamento, relaxamento, " +
                                      "escova_progressiva, escova, luzes, tinturas, alisantes, medicamentos, liq_permanentes, " +
                                      "tratamentos_capilares, outro) " +
                                      "VALUES (@tipoCabelo, @comprimento, @caracteristica, @elasticidade, @pigmento, @espessura, @observacao, " +
                                      "@tingimento, @alisamento, @relaxamento, @escovaProgressiva, @escova, @luzes, @tinturas, " +
                                      "@alisantes, @medicamentos, @liqPermanentes, @tratamentosCapilares, @outro)";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@tipoCabelo", obj.TipoCabelo);
                comando.Parameters.AddWithValue("@comprimento", obj.Comprimento);
                comando.Parameters.AddWithValue("@caracteristica", obj.Caracteristica);
                comando.Parameters.AddWithValue("@elasticidade", obj.Elasticidade);
                comando.Parameters.AddWithValue("@pigmento", obj.Pigmento);
                comando.Parameters.AddWithValue("@espessura", obj.Espessura);
                comando.Parameters.AddWithValue("@observacao", obj.Observacao);
                comando.Parameters.AddWithValue("@tingimento", obj.Tingimento);
                comando.Parameters.AddWithValue("@alisamento", obj.Alisamento);
                comando.Parameters.AddWithValue("@relaxamento", obj.Relaxamento);
                comando.Parameters.AddWithValue("@escovaProgressiva", obj.EscovaProgressiva);
                comando.Parameters.AddWithValue("@escova", obj.Escova);
                comando.Parameters.AddWithValue("@luzes", obj.Luzes);
                comando.Parameters.AddWithValue("@tinturas", obj.Tinturas);
                comando.Parameters.AddWithValue("@alisantes", obj.Alisantes);
                comando.Parameters.AddWithValue("@medicamentos", obj.Medicamentos);
                comando.Parameters.AddWithValue("@liqPermanentes", obj.LiquidosPermanentes);
                comando.Parameters.AddWithValue("@tratamentosCapilares", obj.TratamentosCapilares);
                comando.Parameters.AddWithValue("@outro", obj.Outro);

                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dados inseridos com sucesso na tabela AnamneseCapilar.");
                }
                else
                {
                    MessageBox.Show("Nenhum dado foi inserido na tabela AnamneseCapilar.");
                }

                // Comita a transação
                transaction.Commit();     
            
                _conn.Close();
            
        }
        public List<CadastroDeAnamneseCapilar> List()
        {
            try
            {
                var lista = new List<CadastroDeAnamneseCapilar>();
                var comando = _conn.Query();

                comando.CommandText = @"SELECT id_ancap, tipo_cabelo_ancap, comprimento_ancap, caracteristica_ancap, 
                               elasticidade_ancap, pigmento_ancap, espessura_ancap, observacao_ancap, tingimento, 
                               alisamento, relaxamento, escova_progressiva, escova, luzes, tinturas, alisantes, medicamentos, 
                               liq_permanentes, tratamentos_capilares, outro
                        FROM AnamneseCapilar";

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var cadastro = new CadastroDeAnamneseCapilar
                    (
                        reader.GetInt32("id_ancap"),
                        reader.GetString("tipo_cabelo_ancap"),
                        reader.GetString("comprimento_ancap"),
                        reader.GetString("caracteristica_ancap"),
                        reader.GetString("elasticidade_ancap"),
                        reader.GetString("pigmento_ancap"),
                        reader.GetString("espessura_ancap"),
                        reader.GetString("observacao_ancap"),
                        reader.GetString("tingimento"),
                        reader.GetString("alisamento"),
                        reader.GetString("relaxamento"),
                        reader.GetString("escova_progressiva"),
                        reader.GetString("escova"),
                        reader.GetString("luzes"),
                        reader.GetString("tinturas"),
                        reader.GetString("alisantes"),
                        reader.GetString("medicamentos"),
                        reader.GetString("liq_permanentes"),
                        reader.GetString("tratamentos_capilares"),
                        reader.GetString("outro")
                    );

                    lista.Add(cadastro);
                }

                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar a lista de anamnese capilar: {ex.Message}");
                return new List<CadastroDeAnamneseCapilar>();
            }
        }

        public void Delete(CadastroDeAnamneseCapilar obj)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM AnamneseCapilar WHERE id_ancap = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);

                _conn.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir o registro: " + ex.Message);
                throw ex;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Update(CadastroDeAnamneseCapilar obj)
        {
            MySqlTransaction transaction = null;
            try
            {
                Console.WriteLine("Iniciando atualização no banco...");
                var comando = _conn.Query();

                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                comando.CommandText = "UPDATE AnamneseCapilar SET tipo_cabelo_ancap = @tipoCabelo, comprimento_ancap = @comprimento, " +
                                      "caracteristica_ancap = @caracteristica, elasticidade_ancap = @elasticidade, " +
                                      "pigmento_ancap = @pigmento, espessura_ancap = @espessura, observacao_ancap = @observacao, " +
                                      "tingimento = @tingimento, alisamento = @alisamento, relaxamento = @relaxamento, " +
                                      "escova_progressiva = @escovaProgressiva, escova = @escova, luzes = @luzes, " +
                                      "tinturas = @tinturas, alisantes = @alisantes, medicamentos = @medicamentos, " +
                                      "liq_permanentes = @liqPermanentes, tratamentos_capilares = @tratamentosCapilares, outro = @outro " +
                                      "WHERE id_ancap = @id";

                comando.Parameters.AddWithValue("@tipoCabelo", obj.TipoCabelo);
                comando.Parameters.AddWithValue("@comprimento", obj.Comprimento);
                comando.Parameters.AddWithValue("@caracteristica", obj.Caracteristica);
                comando.Parameters.AddWithValue("@elasticidade", obj.Elasticidade);
                comando.Parameters.AddWithValue("@pigmento", obj.Pigmento);
                comando.Parameters.AddWithValue("@espessura", obj.Espessura);
                comando.Parameters.AddWithValue("@observacao", obj.Observacao);
                comando.Parameters.AddWithValue("@tingimento", obj.Tingimento);
                comando.Parameters.AddWithValue("@alisamento", obj.Alisamento);
                comando.Parameters.AddWithValue("@relaxamento", obj.Relaxamento);
                comando.Parameters.AddWithValue("@escovaProgressiva", obj.EscovaProgressiva);
                comando.Parameters.AddWithValue("@escova", obj.Escova);
                comando.Parameters.AddWithValue("@luzes", obj.Luzes);
                comando.Parameters.AddWithValue("@tinturas", obj.Tinturas);
                comando.Parameters.AddWithValue("@alisantes", obj.Alisantes);
                comando.Parameters.AddWithValue("@medicamentos", obj.Medicamentos);
                comando.Parameters.AddWithValue("@liqPermanentes", obj.LiquidosPermanentes);
                comando.Parameters.AddWithValue("@tratamentosCapilares", obj.TratamentosCapilares);
                comando.Parameters.AddWithValue("@outro", obj.Outro);
                comando.Parameters.AddWithValue("@id", obj.Id);

                comando.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("Dados atualizados com sucesso!");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("Erro: " + ex.Message);
                throw new Exception("Erro ao atualizar as informações: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
    }



}


