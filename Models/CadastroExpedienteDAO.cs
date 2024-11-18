using IBeauty.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace IBeauty.Models
{
    public class Expediente
    {
        public int Id { get; set; }
        public string Mes { get; set; }
        public string Ano { get; set; }
        public string NomeFuncionario { get; set; }
        public string CargaHoraria { get; set; }
        public string Salario { get; set; }

        public Expediente(int id, string mes, string ano, string nomeFuncionario, string cargaHoraria, string salario)
        {
            Id = id;
            Mes = mes;
            Ano = ano;
            NomeFuncionario = nomeFuncionario;
            CargaHoraria = cargaHoraria;
            Salario = salario;
        }
    }

    public class ExpedienteDAO
    {
        private Conexao _conn = new Conexao();

        public void Insert(Expediente obj)
        {
            MySqlTransaction transaction = null;
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "INSERT INTO Expediente (mes_exp, ano_exp, nome_exp, carga_horaria_exp, salario_exp) " +
                                      "VALUES (@mes, @ano, @nome, @cargaHoraria, @salario)";
                comando.Parameters.AddWithValue("@mes", obj.Mes);
                comando.Parameters.AddWithValue("@ano", obj.Ano);
                comando.Parameters.AddWithValue("@nomeFuncionario", obj.NomeFuncionario);
                comando.Parameters.AddWithValue("@cargaHoraria", obj.CargaHoraria);
                comando.Parameters.AddWithValue("@salario", obj.Salario);

                comando.ExecuteNonQuery();
                Console.WriteLine("Expediente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao cadastrar expediente: " + ex.Message);
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public List<Expediente> List()
        {
            try
            {
                var lista = new List<Expediente>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT id_exp, mes_exp, ano_exp, nome_funcionario, carga_horaria_exp, salario_exp FROM Expediente";

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var expediente = new Expediente(
                            reader.GetInt32("id_exp"),
                            reader.GetString("mes_exp"),
                            reader.GetString("ano_exp"),
                            reader.GetString("nome_funcionario"),
                            reader.GetString("carga_horaria_exp"),
                            reader.GetString("salario_exp")
                        );

                        lista.Add(expediente);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar expedientes: " + ex.Message);
                return new List<Expediente>();
            }
        }

        public void Delete(int id)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Expediente WHERE id_exp = @id";
                comando.Parameters.AddWithValue("@id", id);
                comando.ExecuteNonQuery();
                Console.WriteLine("Expediente excluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao excluir expediente: " + ex.Message);
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }

        public void Update(Expediente obj)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "UPDATE Expediente SET mes_exp = @mes, ano_exp = @ano, nome_exp = @nome, " +
                                      "carga_horaria_exp = @cargaHoraria, salario_exp = @salario WHERE id_exp = @id";
                comando.Parameters.AddWithValue("@id", obj.Id);
                comando.Parameters.AddWithValue("@mes", obj.Mes);
                comando.Parameters.AddWithValue("@ano", obj.Ano);
                comando.Parameters.AddWithValue("@nomeFuncionario", obj.NomeFuncionario);
                comando.Parameters.AddWithValue("@cargaHoraria", obj.CargaHoraria);
                comando.Parameters.AddWithValue("@salario", obj.Salario);

                comando.ExecuteNonQuery();
                Console.WriteLine("Expediente atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao atualizar expediente: " + ex.Message);
                throw;
            }
            finally
            {
                _conn.Close();
            }
        }
    }
}
