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
    /// Interação lógica para CadastroCaixa.xam
    /// </summary>
    public partial class CadastroCaixa : Page
    {
        public CadastroCaixa()
        {
            InitializeComponent();
        }

        private void btnSalvarEntrada_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFecharEntrada_Click(object sender, RoutedEventArgs e)
        {
            if (PainelEntrada.Visibility == Visibility.Collapsed)
            {
                PainelEntrada.Visibility = Visibility.Visible;
            }
            else
            {
                PainelEntrada.Visibility = Visibility.Collapsed;
            }
        }

        private void btnEntrada_Click(object sender, RoutedEventArgs e)
        {
            if (PainelEntrada.Visibility == Visibility.Collapsed)
            {
                PainelEntrada.Visibility = Visibility.Visible;
            }
            else
            {
                PainelEntrada.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSaida_Click(object sender, RoutedEventArgs e)
        {
            if (PainelSaida.Visibility == Visibility.Collapsed)
            {
                PainelSaida.Visibility = Visibility.Visible;
            }
            else
            {
                PainelSaida.Visibility = Visibility.Collapsed;
            }
        }

        private void btnFecharSaida_Click(object sender, RoutedEventArgs e)
        {
            if (PainelSaida.Visibility == Visibility.Collapsed)
            {
                PainelSaida.Visibility = Visibility.Visible;
            }
            else
            {
                PainelSaida.Visibility = Visibility.Collapsed;
            }
        }

        private void btnFecharCaixa_Click(object sender, RoutedEventArgs e)
        {
            if (PainelDetalhes.Visibility == Visibility.Collapsed)
            {
                PainelDetalhes.Visibility = Visibility.Visible;
            }
            else
            {
                PainelDetalhes.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSalvarCaixa_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Função em desenvolvimento!");
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/TabelaCaixa.xaml", UriKind.Relative));
        }

        private void btnDetalhes_Click(object sender, RoutedEventArgs e)
        {
            if (PainelDetalhes.Visibility == Visibility.Collapsed)
            {
                PainelDetalhes.Visibility = Visibility.Visible;
            }
            else
            {
                PainelDetalhes.Visibility = Visibility.Collapsed;
            }
        }
    }
}
