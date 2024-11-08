using Microsoft.Win32;
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
    /// Interação lógica para CadastroProduto.xam
    /// </summary>
    public partial class CadastroProduto : Page
    {
        public CadastroProduto()
        {
            InitializeComponent();
        }
        private void BtnCarregarImagem_Click(object sender, RoutedEventArgs e)
        {//pegar a imagem do produto
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Imagens (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == true)
                {
                    //exibir a imagem selecionada
                    string caminhoArquivo = openFileDialog.FileName;
                    BitmapImage bitmap = new BitmapImage(new Uri(caminhoArquivo, UriKind.Absolute));
                    ImgCarregada.Source = bitmap;
                    //esconde o botão de carregar a imagem 
                    BtnCarregarImagem.Visibility = Visibility.Collapsed;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
