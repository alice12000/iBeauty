using IBeauty.Models;
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
    /// Interação lógica para TabelaExpediente.xam
    /// </summary>
    public partial class TabelaExpediente : Page
    {
        public TabelaExpediente()
        {
            InitializeComponent();
            CarregarExpediente();
        }

        private void CarregarExpediente()
        {
            CadastroDeExpedienteDAO dao = new CadastroDeExpedienteDAO();
            List<CadastroDeExpediente> expedientes = dao.List();

            var fornecedoresExibidos = expedientes.Select(e => new
            {
                ID = e.Id,
                Mes = e.Mes,
                Nome= e.NomeFuncionario,
                Ano = e.Ano,
                Carga_Horaria= e.CargaHoraria,
              
            }).ToList();

            dataGridExpediente.ItemsSource = expedientes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroExpediente.xaml", UriKind.Relative));
        }

        private void ButtonExcluir(object sender, RoutedEventArgs e)
        {

        }

        private void dataGridExpediente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
