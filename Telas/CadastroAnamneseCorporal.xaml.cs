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
    /// Interação lógica para CadastroAnamneseCorporal.xam
    /// </summary>
    public partial class CadastroAnamneseCorporal : Page
    {
        public CadastroAnamneseCorporal()
        {
            InitializeComponent();
        }

        private void bSalvar_Click(object sender, RoutedEventArgs e)
        {


            // Verifica se todos os campos obrigatórios estão preenchidos
            if (string.IsNullOrEmpty(cbJaDepilou.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(cbOcorreuAlergia.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(cbPossuiAlergia.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(cbProblemaPele.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(cbEstaemTratamento.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(cbGestante.SelectedItem?.ToString()) ||
                string.IsNullOrEmpty(tbTipoPele.Text) ||
                string.IsNullOrEmpty(cbVasosVarizes.SelectedItem?.ToString()) ||
                (cbGestante.SelectedItem.ToString() == "Sim" && string.IsNullOrEmpty(tbSimGravida.Text)))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Salvar os dados aqui (exemplo fictício)
            //string anamnese = $"Depilação: {cbJaDepilou.SelectedItem}, Alergia: {cbOcorreuAlergia.SelectedItem}, Problema de Pele: {cbProblemaPele.SelectedItem}, Tratamento Dermatológico: {cbEstaemTratamento.SelectedItem}, Gestante: {cbGestante.SelectedItem}, Tipo de Pele: {tbTipoPele.Text}, Vasos/Varizes: {cbVasosVarizes.SelectedItem}";

            // Aqui você pode adicionar a lógica de salvar os dados no banco de dados
            MessageBox.Show("Dados salvos com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

            // Após salvar, navegar de volta para a tela de cadastro de cliente
            Window.GetWindow(this)?.Close();

        }

        private void bFechar_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
    // Função para salvar os dados no banco de dados
    /*
    private void SalvarButton_Click(object sender, RoutedEventArgs e)
    {
        // Dados do cadastro
        string nome = nomeTextBox.Text;
        string endereco = enderecoTextBox.Text;
        string corresponde = comboBoxCorresponde.SelectedItem is System.Windows.Controls.ComboBoxItem selectedItem ? selectedItem.Content.ToString() : string.Empty;
        string textoCorresponde = textBoxCorresponde.Text;

        // Conexão com o banco de dados (ajuste o connectionString conforme sua configuração)
        string connectionString = "Data Source=servidor;Initial Catalog=nomeDoBanco;Integrated Security=True";

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Comando para inserir os dados no banco de dados
                string query = "INSERT INTO CadastroAnamneseCapilar (Nome, Endereco, Corresponde, TextoCorresponde) VALUES (@Nome, @Endereco, @Corresponde, @TextoCorresponde)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parâmetros para evitar SQL Injection
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Endereco", endereco);
                    command.Parameters.AddWithValue("@Corresponde", corresponde);
                    command.Parameters.AddWithValue("@TextoCorresponde", textoCorresponde);

                    // Executa o comando
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cadastro realizado com sucesso!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao salvar: " + ex.Message);
        }
    }*/
}
