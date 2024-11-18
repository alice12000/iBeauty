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
    public class CadastroDeAnamneseCorporalDAO
    {
        private Conexao _conn = new Conexao();

        // Método para inserir os dados da anamnese corporal no banco de dados
        public void Insert(CadastroDeAnamneseCorporal obj)
        {
            MySqlTransaction transaction = null;

            try
            {
                var comando = _conn.Query();
                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                // Inserir os dados da anamnese corporal
                comando.CommandText = "INSERT INTO AnamneseCorporal (pergunta_depilacao, resposta_depilacao, pergunta_alergia, resposta_alergia, " +
                                      "pergunta_alergia2, resposta_alergia2, pergunta_problema, resposta_problema, pergunta_tratamento, " +
                                      "resposta_tratamento, pergunta_gestante, resposta_gestante, pergunta_vasos, tipo_pele, cera_quente, " +
                                      "cera_fria, laser, luz_pulsante, linha, axilas, virilha, costa, peito, braco, costa_perna, nadegas) " +
                                      "VALUES (@perguntaDepilacao, @respostaDepilacao, @perguntaAlergia, @respostaAlergia, @perguntaAlergia2, @respostaAlergia2, " +
                                      "@perguntaProblema, @respostaProblema, @perguntaTratamento, @respostaTratamento, @perguntaGestante, @respostaGestante, " +
                                      "@perguntaVasos, @tipoPele, @ceraQuente, @ceraFria, @laser, @luzPulsante, @linha, @axilas, @virilha, @costa, @peito, " +
                                      "@braco, @costaPerna, @nadegas)";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@perguntaDepilacao", obj.PerguntaDepilacao);
                comando.Parameters.AddWithValue("@respostaDepilacao", obj.RespostaDepilacao);
                comando.Parameters.AddWithValue("@perguntaAlergia", obj.PerguntaAlergia);
                comando.Parameters.AddWithValue("@respostaAlergia", obj.RespostaAlergia);
                comando.Parameters.AddWithValue("@perguntaAlergia2", obj.PerguntaAlergia2);
                comando.Parameters.AddWithValue("@respostaAlergia2", obj.RespostaAlergia2);
                comando.Parameters.AddWithValue("@perguntaProblema", obj.PerguntaProblema);
                comando.Parameters.AddWithValue("@respostaProblema", obj.RespostaProblema);
                comando.Parameters.AddWithValue("@perguntaTratamento", obj.PerguntaTratamento);
                comando.Parameters.AddWithValue("@respostaTratamento", obj.RespostaTratamento);
                comando.Parameters.AddWithValue("@perguntaGestante", obj.PerguntaGestante);
                comando.Parameters.AddWithValue("@respostaGestante", obj.RespostaGestante);
                comando.Parameters.AddWithValue("@perguntaVasos", obj.PerguntaVasos);
                comando.Parameters.AddWithValue("@tipoPele", obj.TipoPele);
                comando.Parameters.AddWithValue("@ceraQuente", obj.CeraQuente);
                comando.Parameters.AddWithValue("@ceraFria", obj.CeraFria);
                comando.Parameters.AddWithValue("@laser", obj.Laser);
                comando.Parameters.AddWithValue("@luzPulsante", obj.LuzPulsante);
                comando.Parameters.AddWithValue("@linha", obj.Linha);
                comando.Parameters.AddWithValue("@axilas", obj.Axilas);
                comando.Parameters.AddWithValue("@virilha", obj.Virilha);
                comando.Parameters.AddWithValue("@costa", obj.Costa);
                comando.Parameters.AddWithValue("@peito", obj.Peito);
                comando.Parameters.AddWithValue("@braco", obj.Braco);
                comando.Parameters.AddWithValue("@costaPerna", obj.CostaPerna);
                comando.Parameters.AddWithValue("@nadegas", obj.Nadegas);

                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dados inseridos com sucesso na tabela AnamneseCorporal.");
                }
                else
                {
                    MessageBox.Show("Nenhum dado foi inserido na tabela AnamneseCorporal.");
                }

                // Comita a transação
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Erro ao inserir os dados: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        // Método para listar as anamneses corporais
        public List<CadastroDeAnamneseCorporal> List()
        {
            try
            {
                var lista = new List<CadastroDeAnamneseCorporal>();
                var comando = _conn.Query();

                comando.CommandText = @"SELECT id_ancor, pergunta_depilacao, resposta_depilacao, pergunta_alergia, resposta_alergia, 
                                       pergunta_alergia2, resposta_alergia2, pergunta_problema, resposta_problema, pergunta_tratamento, 
                                       resposta_tratamento, pergunta_gestante, resposta_gestante, pergunta_vasos, tipo_pele, cera_quente, 
                                       cera_fria, laser, luz_pulsante, linha, axilas, virilha, costa, peito, braco, costa_perna, nadegas
                        FROM AnamneseCorporal";

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var cadastro = new CadastroDeAnamneseCorporal
                    (
                        reader.GetInt32("id_ancor"),
                        reader.GetString("pergunta_depilacao"),
                        reader.GetString("resposta_depilacao"),
                        reader.GetString("pergunta_alergia"),
                        reader.GetString("resposta_alergia"),
                        reader.GetString("pergunta_alergia2"),
                        reader.GetString("resposta_alergia2"),
                        reader.GetString("pergunta_problema"),
                        reader.GetString("resposta_problema"),
                        reader.GetString("pergunta_tratamento"),
                        reader.GetString("resposta_tratamento"),
                        reader.GetString("pergunta_gestante"),
                        reader.GetString("resposta_gestante"),
                        reader.GetString("pergunta_vasos"),
                        reader.GetString("tipo_pele"),
                        reader.GetString("cera_quente"),
                        reader.GetString("cera_fria"),
                        reader.GetString("laser"),
                        reader.GetString("luz_pulsante"),
                        reader.GetString("linha"),
                        reader.GetString("axilas"),
                        reader.GetString("virilha"),
                        reader.GetString("costa"),
                        reader.GetString("peito"),
                        reader.GetString("braco"),
                        reader.GetString("costa_perna"),
                        reader.GetString("nadegas")
                    );

                    lista.Add(cadastro);
                }

                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar a lista de anamnese corporal: {ex.Message}");
                return new List<CadastroDeAnamneseCorporal>();
            }
        }

        // Método para excluir um registro da anamnese corporal
        public void Delete(CadastroDeAnamneseCorporal obj)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM AnamneseCorporal WHERE id_ancor = @id";
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

        // Método para atualizar um registro da anamnese corporal
        public void Update(CadastroDeAnamneseCorporal obj)
        {
            MySqlTransaction transaction = null;
            try
            {
                var comando = _conn.Query();
                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                comando.CommandText = "UPDATE AnamneseCorporal SET pergunta_depilacao = @perguntaDepilacao, resposta_depilacao = @respostaDepilacao, " +
                                      "pergunta_alergia = @perguntaAlergia, resposta_alergia = @respostaAlergia, pergunta_alergia2 = @perguntaAlergia2, " +
                                      "resposta_alergia2 = @respostaAlergia2, pergunta_problema = @perguntaProblema, resposta_problema = @respostaProblema, " +
                                      "pergunta_tratamento = @perguntaTratamento, resposta_tratamento = @respostaTratamento, pergunta_gestante = @perguntaGestante, " +
                                      "resposta_gestante = @respostaGestante, pergunta_vasos = @perguntaVasos, tipo_pele = @tipoPele, cera_quente = @ceraQuente, " +
                                      "cera_fria = @ceraFria, laser = @laser, luz_pulsante = @luzPulsante, linha = @linha, axilas = @axilas, virilha = @virilha, " +
                                      "costa = @costa, peito = @peito, braco = @braco, costa_perna = @costaPerna, nadegas = @nadegas " +
                                      "WHERE id_ancor = @id";

                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@perguntaDepilacao", obj.PerguntaDepilacao);
                comando.Parameters.AddWithValue("@respostaDepilacao", obj.RespostaDepilacao);
                comando.Parameters.AddWithValue("@perguntaAlergia", obj.PerguntaAlergia);
                comando.Parameters.AddWithValue("@respostaAlergia", obj.RespostaAlergia);
                comando.Parameters.AddWithValue("@perguntaAlergia2", obj.PerguntaAlergia2);
                comando.Parameters.AddWithValue("@respostaAlergia2", obj.RespostaAlergia2);
                comando.Parameters.AddWithValue("@perguntaProblema", obj.PerguntaProblema);
                comando.Parameters.AddWithValue("@respostaProblema", obj.RespostaProblema);
                comando.Parameters.AddWithValue("@perguntaTratamento", obj.PerguntaTratamento);
                comando.Parameters.AddWithValue("@respostaTratamento", obj.RespostaTratamento);
                comando.Parameters.AddWithValue("@perguntaGestante", obj.PerguntaGestante);
                comando.Parameters.AddWithValue("@respostaGestante", obj.RespostaGestante);
                comando.Parameters.AddWithValue("@perguntaVasos", obj.PerguntaVasos);
                comando.Parameters.AddWithValue("@tipoPele", obj.TipoPele);
                comando.Parameters.AddWithValue("@ceraQuente", obj.CeraQuente);
                comando.Parameters.AddWithValue("@ceraFria", obj.CeraFria);
                comando.Parameters.AddWithValue("@laser", obj.Laser);
                comando.Parameters.AddWithValue("@luzPulsante", obj.LuzPulsante);
                comando.Parameters.AddWithValue("@linha", obj.Linha);
                comando.Parameters.AddWithValue("@axilas", obj.Axilas);
                comando.Parameters.AddWithValue("@virilha", obj.Virilha);
                comando.Parameters.AddWithValue("@costa", obj.Costa);
                comando.Parameters.AddWithValue("@peito", obj.Peito);
                comando.Parameters.AddWithValue("@braco", obj.Braco);
                comando.Parameters.AddWithValue("@costaPerna", obj.CostaPerna);
                comando.Parameters.AddWithValue("@nadegas", obj.Nadegas);

                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Dados atualizados com sucesso.");
                }
                else
                {
                    MessageBox.Show("Nenhum dado foi atualizado.");
                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show("Erro ao atualizar os dados: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
