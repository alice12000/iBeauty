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
    /// Interação lógica para TabelaCaixa.xam
    /// </summary>
    public partial class TabelaCaixa : Page
    {
        public TabelaCaixa()
        {
            InitializeComponent();
        }

        private void btnAbrirCaixa_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Telas/CadastroCaixa.xaml", UriKind.Relative));
        }
    }
}
