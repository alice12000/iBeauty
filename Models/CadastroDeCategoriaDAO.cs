using IBeauty.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace IBeauty.Models
{
    public class CadastroDeCategoriaDAO
        {
            private Conexao _conn = new Conexao();

            public void Insert(CadastroDeCategoria obj)
            {
                var funcionarioExiste = VerificarFuncionarioExistente(obj.Profissional);
                if (!funcionarioExiste)
                {
                    MessageBox.Show("O ID do funcionário não existe.");
                }
                else
                {
                    try


                    {
                        var comando = _conn.Query();
                        comando.CommandText = @"
            INSERT INTO Categoria 
            (nome_cat, tipo_cat, id_func_fk) 
            VALUES (@nome, @tipo, @profissional)";

                        comando.Parameters.AddWithValue("@nome", obj.Nome);
                        comando.Parameters.AddWithValue("@tipo", obj.Tipo);
                        comando.Parameters.AddWithValue("@profissional", obj.Profissional);
                        comando.ExecuteNonQuery();
                        Console.WriteLine("Categoria cadastrado com sucesso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Erro ao cadastrar categoria: " + ex.Message);
                        throw;
                    }
                    finally
                    {
                        _conn.Close();
                    }
                }
            }

            private bool VerificarFuncionarioExistente(int idFun)
            {
                var comando = _conn.Query();
                comando.CommandText = "SELECT COUNT(*) FROM funcionario WHERE id_func = @profissional";
                comando.Parameters.AddWithValue("@profissional", idFun);
                int count = Convert.ToInt32(comando.ExecuteScalar());
                return count > 0;
            }

            public List<CadastroDeCategoria> List()
            {
                try
                {
                    var lista = new List<CadastroDeCategoria>();
                    var comando = _conn.Query();

                    comando.CommandText = @"
            SELECT 
                Categoria.id_cat,
                Categoria.nome_cat,
                Categoria.tipo_cat,
                Categoria.id_func_fk
            FROM  
                Categoria 
            INNER JOIN 
                Funcionario 
            ON 
                Categoria.id_func_fk = Funcionario.id_func";

                    using (var reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var novaCategoria = new CadastroDeCategoria
                            (
                             reader.GetString("nome_cat"),
                             reader.GetString("tipo_cat"),
                             reader.GetInt32("id_func_fk")
                            );

                            lista.Add(novaCategoria);
                        }
                    }

                    return lista;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao listar os dados da tabela categoria: " + ex.Message);
                    return new List<CadastroDeCategoria>();
                }
                finally
                {
                    _conn.Close();
                }
            }
            public bool ExisteFuncionario(int id)
            {
                try
                {
                    var comando = _conn.Query(); // Utilizando a conexão da classe Conexao
                    comando.CommandText = "SELECT COUNT(*) FROM funcionario WHERE id_fun = @profissional";
                    comando.Parameters.AddWithValue("@profissional", id);

                    // Executa a consulta e verifica se o número de resultados é maior que 0
                    int count = Convert.ToInt32(comando.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao verificar funcionário: " + ex.Message);
                    return false;
                }
                finally
                {
                    _conn.Close(); // Garante que a conexão seja fechada ao final
                }
            }
           
        }

}
