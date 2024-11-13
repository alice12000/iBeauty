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
    /// Interação lógica para Cadastro.xam
    /// </summary>
    public partial class Cadastro : Page
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Endereco endereco = new Endereco(0, tbrua.Text, tbbairro.Text, Convert.ToInt32(tbnumero.Text), tbcomplemento.Text, tbcidade.Text, cbestado.Text, tbcep.Text);
            CadastroUsuario cadastro = new CadastroUsuario(0, tbnome.Text, Convert.ToDateTime(tbdn.Text), cbgenero.Text, tbemail.Text, Convert.ToInt32(tbtelefone.Text), endereco);
        }
    }
}
