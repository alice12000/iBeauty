using IBauty.Database;
using IBeauty.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBeauty.Models
{
    internal class EnderecoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Endereco obj)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Endereco (rua, bairro, numero, complemento, cidade, estado, cep) " +
                                      "VALUES (@rua, @bairro, @numero, @complemento, @cidade, @estado, @cep)";

                comando.Parameters.AddWithValue("@rua", obj.Rua);
                comando.Parameters.AddWithValue("@bairro", obj.Bairro);
                comando.Parameters.AddWithValue("@numero", obj.Numero);
                comando.Parameters.AddWithValue("@complemento", obj.Complemento);
                comando.Parameters.AddWithValue("@cidade", obj.Cidade);
                comando.Parameters.AddWithValue("@estado", obj.Estado);
                comando.Parameters.AddWithValue("@cep", obj.Cep);

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

        public List<Endereco> List()
        {
            try
            {
                var lista = new List<Endereco>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Endereco";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var endereco = new Endereco
                    {
                        Id = reader.GetInt32("id_end"),
                        Rua = DAOHelper.GetString(reader, "rua_end"),
                        Bairro = DAOHelper.GetString(reader, "bairro_end"),
                        Numero = reader.GetInt32("numero_end"),
                        Complemento = DAOHelper.GetString(reader, "complemento)end"),
                        Cidade = DAOHelper.GetString(reader, "cidade_end"),
                        Estado = DAOHelper.GetString(reader, "estado_end"),
                        Cep = DAOHelper.GetString(reader, "cep_end")
                    };

                    lista.Add(endereco);
                }

                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Endereco obj)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Endereco WHERE id_end = @id";

                comando.Parameters.AddWithValue("@id", obj.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao deletar as informações.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Endereco obj)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Endereco SET " +
                                      "rua = @rua, bairro = @bairro, numero = @numero, complemento = @complemento, " +
                                      "cidade = @cidade, estado = @estado, cep = @cep " +
                                      "WHERE id_end = @id";

                comando.Parameters.AddWithValue("@rua", obj.Rua);
                comando.Parameters.AddWithValue("@bairro", obj.Bairro);
                comando.Parameters.AddWithValue("@numero", obj.Numero);
                comando.Parameters.AddWithValue("@complemento", obj.Complemento);
                comando.Parameters.AddWithValue("@cidade", obj.Cidade);
                comando.Parameters.AddWithValue("@estado", obj.Estado);
                comando.Parameters.AddWithValue("@cep", obj.Cep);
                comando.Parameters.AddWithValue("@id", obj.Id);

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
