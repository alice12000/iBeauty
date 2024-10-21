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
        /*
        private static Conexao _conn = new Conexao();

        public void Insert(Endereco obj)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO curso VALUES " +
                "(null, @rua, @bairro, @numero, @complemento, @cidade, @estado, @cep)";


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

        public List<Cadastro> List()
        {
            try
            {
                var lista = new List<Endereco>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Endereco";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var endereco = new Endereco();  

                    endereco.Id = reader.GetInt32("id_end");
                    endereco.Rua = DAOHelper.GetString(reader, "rua_end");
                    endereco.Bairro = DAOHelper.GetString(reader, "bairro_end");
                    endereco.Numero = DAOHelper.GetStirng(reader, "numero_ end");
                    endereco.Complemento = DAOHelper.GetString(reader, "complemento_end");
                    endereco.Cidade = DAOHelper.GetString(reader, "cidade_end");
                    endereco.Estado = DAOHelper.GetString(reader, "estado_end");
                    endereco.Cep = DAOHelper.GetString(reader, "cep_end");

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

        public void Delete(Curso obj)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "DELETE FROM Curso WHERE id_cur = @id";

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
        public void Update(Curso obj)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Escola SET " +
                "nome_fantasia_esc = @nome, razao_social_esc = @razao, cnpj_esc = @cnpj, insc_estadual_esc = @inscricao," +
                " tipo_esc = @tipo, data_criacao_esc = @data_criacao, responsavel_esc = @resp " +
                "WHERE id_esc = @id";

                
                comando.Parameters.AddWithValue("@nome", escola.NomeFantasia);
                comando.Parameters.AddWithValue("@razao", escola.RazaoSocial);
                comando.Parameters.AddWithValue("@cnpj", escola.Cnpj);
                comando.Parameters.AddWithValue("@inscricao", escola.InscEstadual);
                comando.Parameters.AddWithValue("@tipo", escola.Tipo);
                comando.Parameters.AddWithValue("@data_criacao", escola.DataCriacao?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@resp", escola.Responsavel);

                comando.Parameters.AddWithValue("@id", escola.Id);
                

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
*/
    }
}
