using IBeauty.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                // Verifica ou insere o endereço
                int idEndereco = ObterOuInserirEndereco(obj, comando);

                // Verifica ou insere a anamnese capilar
                int idAnamneseCap = ObterOuInserirAnamneseCapilar(obj, comando);

                // Verifica ou insere a anamnese corporal
                int idAnamneseCor = ObterOuInserirAnamneseCorporal(obj, comando);

                // Insere os dados do cliente
                comando.CommandText = @"INSERT INTO Funcionario 
                                        (nome_cli, telefone_cli, genero_cli, email_cli, data_nascimento_func, cpf_cli, id_end_fk, id_ancap_fk, id_ancor_fk) 
                                        VALUES 
                                        (@nome, @telefone, @genero, @email, @dataNascimento, @cpf, @idEndereco, @idAnamneseCap, @idAnamneseCor)";
                comando.Parameters.Clear();
                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@telefone", obj.Celular);
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
                    Console.WriteLine("Dados inseridos com sucesso na tabela Funcionario.");
                }
                else
                {
                    Console.WriteLine("Nenhum dado foi inserido na tabela Funcionario.");
                }

                // Confirma a transação
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
    }
}

