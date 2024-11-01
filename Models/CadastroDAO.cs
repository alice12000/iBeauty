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
    internal class CadastroDAO
    
       
    {
        /*
       private static Conexao _conn = new Conexao();

       public void Insert(Cadastro obj)
       {
           try
           {
               var comando = _conn.Query();

               comando.CommandText = "INSERT INTO curso VALUES " +
               "(null, @nome, @datanascimento, @genero, @email, @telefone, @rua, @bairro, @numero, @complemento, @cidade, @estado, @cep)";


               comando.Parameters.AddWithValue("@nome", obj.Nome);
               comando.Parameters.AddWithValue("@datanascimento", obj.DataNascimento);
               comando.Parameters.AddWithValue("@genero", obj.Genero);
               comando.Parameters.AddWithValue("@email", obj.Email);
               comando.Parameters.AddWithValue("@telefone", obj.Telefone);
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
               var lista = new List<Cadastro>();
               var comando = _conn.Query();

               comando.CommandText = "SELECT * FROM Curso, Escola WHERE Curso.id_esc_fk = Escola.id_esc";

               MySqlDataReader reader = comando.ExecuteReader();

               while (reader.Read())
               {
                   var cadastro = new Cadastro();

                   cadastro.Id = reader.GetInt32("id_cad");
                   cadastro.Nome = DAOHelper.GetString(reader, "nome_cad");
                   cadastro.DataNascimento = DAOHelper.GetString(reader, "data_nascimento_cad");
                   cadastro.Turno = DAOHelper.GetString(reader, "turno_cur");
                   cadastro.Escola.Id = reader.GetInt32("id_esc_fk");
                   cadastro.Escola.NomeFantasia = DAOHelper.GetString(reader, "nome_fantasia_esc");

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
