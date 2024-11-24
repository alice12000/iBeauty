using IBeauty.Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

namespace IBeauty.Models
{
    public class CadastroDeExpedienteDAO
    {
        private Conexao _conn = new Conexao();

        public void Insert(CadastroDeExpediente obj)
        {
            var funcionarioExiste = VerificarFuncionarioExistente(obj.IdFunc);
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
            INSERT INTO Expediente 
            (mes_exp, ano_exp, carga_horaria_exp, salario_exp, nome_funcionario, id_fun_fk) 
            VALUES (@mes, @ano, @cargaHoraria, @salario, @nomeFuncionario, @idFun)";

                    comando.Parameters.AddWithValue("@mes", obj.Mes);
                    comando.Parameters.AddWithValue("@ano", obj.Ano);
                    comando.Parameters.AddWithValue("@cargaHoraria", obj.CargaHoraria);
                    comando.Parameters.AddWithValue("@salario", obj.Salario);
                    comando.Parameters.AddWithValue("@nomeFuncionario", obj.NomeFuncionario); // Nome correto do parâmetro
                    comando.Parameters.AddWithValue("@idFun", obj.IdFunc); // Certifique-se de que `IdFunc` está correto no objeto

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
        }

        private bool VerificarFuncionarioExistente(int idFun)
        {
            var comando = _conn.Query();
            comando.CommandText = "SELECT COUNT(*) FROM funcionario WHERE id_fun = @idFun";
            comando.Parameters.AddWithValue("@idFun", idFun);
            int count = Convert.ToInt32(comando.ExecuteScalar());
            return count > 0;
        }

        public List<CadastroDeExpediente> List()
        {
            try
            {
                var lista = new List<CadastroDeExpediente>();
                var comando = _conn.Query();

                comando.CommandText = @"
            SELECT 
                Expediente.id_exp, 
                Expediente.mes_exp, 
                Expediente.ano_exp, 
                Expediente.carga_horaria_exp, 
                Expediente.salario_exp, 
                Funcionario.nome_fun, 
                Expediente.id_fun_fk  
            FROM  
                Expediente 
            INNER JOIN 
                Funcionario 
            ON 
                Expediente.id_fun_fk = Funcionario.id_fun";

                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var expedienteFuncionario = new CadastroDeExpediente
                        (
                         reader.GetInt32("id_exp"),
                         reader.GetString("mes_exp"),
                         reader.GetString("ano_exp"),
                         reader.GetString("carga_horaria_exp"),
                         reader.GetString("salario_exp"),
                         reader.GetString("nome_fun"),
                         reader.GetInt32("id_fun_fk")
                        );

                        lista.Add(expedienteFuncionario);
                    }
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao listar expedientes com funcionários: " + ex.Message);
                return new List<CadastroDeExpediente>();
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
                comando.CommandText = "SELECT COUNT(*) FROM funcionario WHERE id_fun = @idFun";
                comando.Parameters.AddWithValue("@idFun", id);

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

        public void Update(CadastroDeExpediente obj)
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
