using IBauty.Database;
using IBeauty.Helpers;
using IBeauty.Telas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    internal class CadastroUsuarioDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(CadastroUsuario obj)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = comando.CommandText = comando.CommandText = "INSERT INTO Cliente (nome, datanascimento, genero, email, telefone, rua, bairro, numero, complemento, cidade, estado, cep) VALUES " +

                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@datanascimento", obj.DataNascimento);
                comando.Parameters.AddWithValue("@genero", obj.Genero);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@rua", obj.Endereco.Rua);
                comando.Parameters.AddWithValue("@bairro", obj.Endereco.Bairro);
                comando.Parameters.AddWithValue("@numero", obj.Endereco.Numero);
                comando.Parameters.AddWithValue("@complemento", obj.Endereco.Complemento);
                comando.Parameters.AddWithValue("@cidade", obj.Endereco.Cidade);
                comando.Parameters.AddWithValue("@estado", obj.Endereco.Estado);
                comando.Parameters.AddWithValue("@cep", obj.Endereco.Cep);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                throw new Exception("Erro ao salvar as informações: " + ex.Message);
            }
        }

        public List<CadastroUsuario> List()
        {
            try
            {
                var lista = new List<CadastroUsuario>();
                var comando = _conn.Query();

                comando.CommandText = comando.CommandText = "SELECT Cliente.id_cli, Cliente.nome_cli, Cliente.data_nascimento_cli, Cliente.genero_cli, Cliente.email_cli, Cliente.telefone_cli, " +
                       "Endereco.id_end, Endereco.rua_end, Endereco.bairro_end, Endereco.numero_end, Endereco.complemento_end, Endereco.cidade_end, Endereco.estado_end, Endereco.cep_end " +
                       "FROM Cliente INNER JOIN Endereco ON Cliente.id_end_fk = Endereco.id_end";

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Endereco endereco = new Endereco
                        (
                            reader.GetInt32("id_end"),
                            DAOHelper.GetString(reader, "rua"),
                            DAOHelper.GetString(reader, "bairro"),
                            reader.GetInt32("numero"),
                            DAOHelper.GetString(reader, "complemento"),
                            DAOHelper.GetString(reader, "cidade"),
                            DAOHelper.GetString(reader, "estado"),
                            DAOHelper.GetString(reader, "cep")
                        );
                    var cadastro = new CadastroUsuario 
                    (
                        reader.GetInt32("id_cli"),
                        reader.GetString("nome_cli"),
                        reader.GetDateTime("data_nascimento_cli"),
                        reader.GetString("genero_cli"),
                        reader.GetString("email_cli"),
                        reader.GetInt32("telefone_cli"),
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

                comando.CommandText = "DELETE FROM Cadastro WHERE id_cli = @id";

                comando.Parameters.AddWithValue("@id", obj.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(CadastroUsuario obj)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Cadastro SET " +
                               "nome = @nome, datanascimento = @datanascimento, genero = @genero, email = @email, telefone = @telefone, " +
                               "rua = @rua, bairro = @bairro, numero = @numero, complemento = @complemento, cidade = @cidade, estado = @estado, cep = @cep " +
                               "WHERE id = @id";

                comando.Parameters.AddWithValue("@nome", obj.Nome);
                comando.Parameters.AddWithValue("@datanascimento", obj.DataNascimento);
                comando.Parameters.AddWithValue("@genero", obj.Genero);
                comando.Parameters.AddWithValue("@email", obj.Email);
                comando.Parameters.AddWithValue("@telefone", obj.Telefone);
                comando.Parameters.AddWithValue("@rua", obj.Endereco.Rua);
                comando.Parameters.AddWithValue("@bairro", obj.Endereco.Bairro);
                comando.Parameters.AddWithValue("@numero", obj.Endereco.Numero);
                comando.Parameters.AddWithValue("@complemento", obj.Endereco.Complemento);
                comando.Parameters.AddWithValue("@cidade", obj.Endereco.Cidade);
                comando.Parameters.AddWithValue("@estado", obj.Endereco.Estado);
                comando.Parameters.AddWithValue("@cep", obj.Endereco.Cep);


                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}