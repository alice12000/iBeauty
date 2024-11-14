using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interação lógica para CadastroCliente.xam
    /// </summary>
    public partial class CadastroCliente : Page
    {
        public Frame MainFrame { get; set; }
        public CadastroCliente()
        {
            InitializeComponent();
        }
        private void BtnLimpar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                rua_txt.Text = "";
                bairro_txt.Text = "";
                numero_txt.Text = "";
                complemento_txt.Text = "";
                cidade_txt.Text = "";
                estado_txt.Text = "";
                cep_txt.Text = "";
                numero_telefone_txt.Text = "";
                user_txt.Text = "";
                senha_txt.Text = "";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Window novaJanela = new Window
            {
                Content = new CadastroAnamneseCapilar(), // Defina aqui a nova Page
                Width = 800,
                Height = 600,
                Owner = Application.Current.MainWindow, // Define a janela principal como proprietária
                WindowStartupLocation = WindowStartupLocation.CenterOwner // Centraliza a nova janela
            };

            // Exibe a janela como modal
            novaJanela.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window novaJanela = new Window
            {
                Content = new CadastroAnamneseFacial(), // Defina aqui a nova Page
                Width = 800,
                Height = 600,
                Owner = Application.Current.MainWindow, // Define a janela principal como proprietária
                WindowStartupLocation = WindowStartupLocation.CenterOwner // Centraliza a nova janela
            };

            // Exibe a janela como modal
            novaJanela.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            Window novaJanela = new Window
            {
                Content = new CadastroAnamneseCorporal(), // Defina aqui a nova Page
                Width = 800,
                Height = 600,
                Owner = Application.Current.MainWindow, // Define a janela principal como proprietária
                WindowStartupLocation = WindowStartupLocation.CenterOwner // Centraliza a nova janela
            };

            // Exibe a janela como modal
            novaJanela.ShowDialog();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Window novaJanela = new Window
            {
                Content = new CadastroAnamneseManicurePedicure(), // Defina aqui a nova Page
                Width = 800,
                Height = 600,
                Owner = Application.Current.MainWindow, // Define a janela principal como proprietária
                WindowStartupLocation = WindowStartupLocation.CenterOwner // Centraliza a nova janela
            };

            // Exibe a janela como modal
            novaJanela.ShowDialog();
        }
    }
}

