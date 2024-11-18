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
    public class ClienteDAO
    {
        private Conexao _conn = new Conexao();

        public void Insert(Cliente obj)
        {
            MySqlTransaction transaction = null;

            try
            {
                Console.WriteLine("Iniciando inserção no banco...");
                var comando = _conn.Query();

                transaction = comando.Connection.BeginTransaction();
                comando.Transaction = transaction;

                Console.WriteLine("Comando preparado.");

                int idEndereco = ObterOuInserirEndereco(obj, comando);

                int idAnamneseCap = ObterOuInserirAnamneseCapilar(obj, comando);

                int idAnamneseCor = ObterOuInserirAnamneseCorporal(obj, comando);

                comando.CommandText = @"INSERT INTO Cliente 
                        (nome_cli, celular_cli, genero_cli, email_cli, data_nascimento_cli, cpf_cli, id_end_fk, id_ancap_fk, id_ancor_fk) 
                        VALUES 
                        (@nome, @celular, @genero, @email, @dataNascimento, @cpf, @idEndereco, @idAnamneseCap, @idAnamneseCor)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@celular", obj.Celular);
                comando.Parameters.AddWithValue("@genero", obj.Genero);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@dataNascimento", obj.DataNascimento);
                comando.Parameters.AddWithValue("@cpf", obj.CPF);
                comando.Parameters.AddWithValue("@idEndereco", idEndereco);
                comando.Parameters.AddWithValue("@idAnamneseCap", idAnamneseCap);
                comando.Parameters.AddWithValue("@idAnamneseCor", idAnamneseCor);

                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Dados inseridos com sucesso na tabela Cliente.");
                }
                else
                {
                    Console.WriteLine("Nenhum dado foi inserido na tabela Cliente.");
                }

                // Confirma a transação
                transaction.Commit();
                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("Erro: " + ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine("Erro Interno: " + ex.InnerException.Message);
                }
                throw new Exception("Erro ao salvar as informações: " + ex.Message);
            }
            finally
            {
                _conn.Close();
            }
        }

        private int ObterOuInserirEndereco(Cliente obj, MySqlCommand comando)
        {
            comando.CommandText = "SELECT id_end FROM Endereco WHERE rua_end = @rua AND bairro_end = @bairro AND cep_end = @cep";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@rua", obj.Endereco.Rua);
            comando.Parameters.AddWithValue("@bairro", obj.Endereco.Bairro);
            comando.Parameters.AddWithValue("@cep", obj.Endereco.Cep);

            object result = comando.ExecuteScalar();

            if (result != null)
            {
                Console.WriteLine("Endereço já existente.");
                return Convert.ToInt32(result);
            }

            comando.CommandText = @"INSERT INTO Endereco (rua_end, bairro_end, numero_end, complemento_end, cidade_end, estado_end, cep_end) 
                                    VALUES (@rua, @bairro, @numero, @complemento, @cidade, @estado, @cep)";
            comando.Parameters.AddWithValue("@numero", obj.Endereco.Numero);
            comando.Parameters.AddWithValue("@complemento", obj.Endereco.Complemento);
            comando.Parameters.AddWithValue("@cidade", obj.Endereco.Cidade);
            comando.Parameters.AddWithValue("@estado", obj.Endereco.Estado);

            comando.ExecuteNonQuery();

            comando.CommandText = "SELECT LAST_INSERT_ID()";
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private int ObterOuInserirAnamneseCapilar(Cliente obj, MySqlCommand comando)
        {
            comando.CommandText = "SELECT id_ancap FROM AnamneseCapilar WHERE tipo_cabelo_ancap = @tipoCabelo AND comprimento_ancap = @comprimento";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@tipoCabelo", obj.AnamneseCapilar.TipoCabelo);
            comando.Parameters.AddWithValue("@comprimento", obj.AnamneseCapilar.Comprimento);

            object result = comando.ExecuteScalar();

            if (result != null)
            {
                Console.WriteLine("Anamnese capilar já existente.");
                return Convert.ToInt32(result);
            }

            comando.CommandText = @"INSERT INTO AnamneseCapilar (tipo_cabelo_ancap, comprimento_ancap) 
                                    VALUES (@tipoCabelo, @comprimento)";
            comando.ExecuteNonQuery();

            comando.CommandText = "SELECT LAST_INSERT_ID()";
            return Convert.ToInt32(comando.ExecuteScalar());
        }

        private int ObterOuInserirAnamneseCorporal(Cliente obj, MySqlCommand comando)
        {
            comando.CommandText = "SELECT id_ancor FROM AnamneseCorporal WHERE pergunta_depilacao = @perguntaDepilacao";
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@perguntaDepilacao", obj.AnamneseCorporal.PerguntaDepilacao);

            object result = comando.ExecuteScalar();

            if (result != null)
            {
                Console.WriteLine("Anamnese corporal já existente.");
                return Convert.ToInt32(result);
            }

            comando.CommandText = @"INSERT INTO AnamneseCorporal (pergunta_depilacao, resposta_depilacao) 
                                    VALUES (@perguntaDepilacao, @respostaDepilacao)";
            comando.Parameters.AddWithValue("@respostaDepilacao", obj.AnamneseCorporal.RespostaDepilacao);

            comando.ExecuteNonQuery();

            comando.CommandText = "SELECT LAST_INSERT_ID()";
            return Convert.ToInt32(comando.ExecuteScalar());
        }
        public List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            var comando = _conn.Query();
            MessageBox.Show("Lista carregada");

            comando.CommandText = @"
            SELECT c.id_cli, c.nome_cli, c.data_nascimento_cli, c.genero_cli, c.cpf_cli, c.email_cli, c.celular_cli,
                   e.id_end, e.rua_end, e.bairro_end, e.numero_end, e.complemento_end, e.cidade_end, e.estado_end, e.cep_end,
                   ac.id_ancap, ac.tipo_cabelo_ancap, ac.comprimento_ancap, ac.caracteristica_ancap, ac.elasticidade_ancap,
                   ac.pigmento_ancap, ac.espessura_ancap, ac.observacao_ancap, ac.tingimento, ac.alisamento, 
                   ac.relaxamento, ac.escova_progressiva, ac.escova, ac.luzes, ac.tinturas, ac.alisantes, ac.medicamentos,
                   ac.liq_permanentes, ac.tratamentos_capilares, ac.outro,
                   an.id_ancor, an.pergunta_depilacao, an.resposta_depilacao, an.pergunta_alergia, an.resposta_alergia, 
                   an.pergunta_alergia2, an.resposta_alergia2, an.pergunta_problema, an.resposta_problema,
                   an.pergunta_tratamento, an.resposta_tratamento, an.pergunta_gestante, an.resposta_gestante,
                   an.pergunta_vasos, an.tipo_pele, an.cera_quente, an.cera_fria, an.laser, an.luz_pulsante, an.linha,
                   an.axilas, an.virilha, an.costa, an.peito, an.braco, an.costa_perna, an.nadegas
            FROM Cliente c
            LEFT JOIN Endereco e ON c.id_end_fk = e.id_end
            LEFT JOIN AnamneseCapilar ac ON c.id_ancap_fk = ac.id_ancap
            LEFT JOIN AnamneseCorporal an ON c.id_ancor_fk = an.id_ancor";

            using (var reader = comando.ExecuteReader())
            {
                MessageBox.Show("carregando itens");
                while (reader.Read())
                {

                    Endereco end = new Endereco
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

                    CadastroDeAnamneseCapilar ancap = new CadastroDeAnamneseCapilar
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

                    CadastroDeAnamneseCorporal ancor = new CadastroDeAnamneseCorporal
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
                    Cliente cliente = new Cliente
                    (
                        reader.GetInt32("id_cli"),
                        reader.GetString("nome_cli"),
                        reader.GetString("data_nascimento_cli"),
                        reader.GetString("genero_cli"),
                        reader.GetString("cpf_cli"),
                        reader.GetString("email_cli"),
                        reader.GetString("celular_cli"),
                        end, ancap, ancor
                        );
                    clientes.Add(cliente);
                }
                MessageBox.Show("Clientes encotrados");
            }
            return clientes;
        }

    }
}

