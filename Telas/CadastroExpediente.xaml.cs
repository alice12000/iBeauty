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
            string nome = tb_nome.Text;
            string ano = tb_ano.Text;
            string carga_horaria = tb_carga_horaria.Text;
            string salario = tb_salario.Text;
            int numero = 0;

            var Conexao = new Conexao();

            var Expediente = new CadastroExpediente(0, mes, nome, ano, carga_horaria, salario);


        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

    }
}
