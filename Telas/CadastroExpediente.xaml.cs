using IBeauty.Database;
using IBeauty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace IBeauty.Telas
{
    /// <summary>
    /// Interação lógica para CadastroExpediente.xam
    /// </summary>
    public partial class CadastroExpediente : Page
    {
        public CadastroExpediente()
        {
            InitializeComponent();
        }

        private void cargahoraria_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void mes_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Cadastrar_Click(object sender, RoutedEventArgs e)
        {
            string mes = tb_mes.Text;
            int idFunc;

            // Verifica se o ID do funcionário é um número válido
            if (int.TryParse(tb_idFunc.Text, out idFunc))
            {
                var daoFuncionario = new CadastroDeExpedienteDAO(); // Supondo que você tenha um DAO para verificar o funcionário
                if (daoFuncionario.ExisteFuncionario(idFunc)) // Verifica se o funcionário existe no banco
                {
                    string ano = tb_ano.Text;
                    string carga_horaria = tb_carga_horaria.Text;
                    string salario = tb_salario.Text;
                    int id = 0;

                    // Criação do objeto CadastroDeExpediente
                    var Expediente = new CadastroDeExpediente(id, mes, ano, carga_horaria, salario, null, idFunc);
                    var dao = new CadastroDeExpedienteDAO();
                    dao.Insert(Expediente);
                    MessageBox.Show("Expediente cadastrado com sucesso!");

                    // Redireciona para a tabela de expediente
                    NavigationService.Navigate(new Uri("Telas/TabelaExpediente.xaml", UriKind.Relative));
                }
                else
                {
                    // Se o funcionário não existir, exibe uma mensagem e redireciona para a tela de cadastro de funcionário
                    MessageBox.Show("O ID do funcionário não existe. Redirecionando para o cadastro de funcionários.");
                    NavigationService.Navigate(new Uri("Telas/CadastroFuncionario.xaml", UriKind.Relative));
                }
            }
            else
            {
                // Caso o ID não seja um número válido
                MessageBox.Show("Por favor, insira um valor numérico válido para o ID do funcionário.");
            }
        }


        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Cadastrar_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
