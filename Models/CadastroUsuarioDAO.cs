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
                      "Endereco.rua, Endereco.bairro, Endereco.numero, Endereco.complemento, Endereco.cidade, Endereco.estado, Endereco.cep " +
                      "FROM Cliente INNER JOIN Endereco ON Cliente.id_end_fk = Endereco.id_end";

                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var cadastro = new CadastroUsuario
                    {
                        Id = reader.GetInt32("id_cad"),
                        Nome = reader.GetString("nome_cad"),
                        DataNascimento = reader.GetDateTime("data_nascimento_cad"),
                        Genero = reader.GetString("genero_cad"),
                        Email = reader.GetString("email_cad"),
                        Telefone = reader.GetInt32("telefone_cad"),
                        Endereco = new Endereco
                        {
                            Rua = reader.GetString("rua_end"),
                            Bairro = reader.GetString("bairro_end"),
                            Numero = reader.GetInt32("numero_end"),
                            Complemento = reader.GetString("complemento_end"),
                            Cidade = reader.GetString("cidade_end"),
                            Estado = reader.GetString("estado_end"),
                            Cep = reader.GetString("cep_end")
                        }
                    };
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
