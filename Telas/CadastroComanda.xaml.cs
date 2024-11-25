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
    /// Interação lógica para CadastroComanda.xam
    /// </summary>
    public partial class CadastroComanda : Page
    {
        public CadastroComanda()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            if (PainelServicoComanda.Visibility == Visibility.Collapsed)
            {
                PainelServicoComanda.Visibility = Visibility.Visible;
            }
            else
            {
                PainelServicoComanda.Visibility = Visibility.Collapsed;
            }
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Função em desenvolvimento!");
        }

        private void btnServicoComanda_Click(object sender, RoutedEventArgs e)
        {
            if (PainelServicoComanda.Visibility == Visibility.Collapsed)
            {
                PainelServicoComanda.Visibility = Visibility.Visible;
            }
            else
            {
                PainelServicoComanda.Visibility = Visibility.Collapsed;
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/TabelaComanda.xaml", UriKind.Relative));
        }
    }
}
