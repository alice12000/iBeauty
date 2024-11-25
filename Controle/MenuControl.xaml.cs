using IBeauty.Telas;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace IBeauty.Controle
{
    public partial class MenuControl : UserControl
    {

        private bool isAgendaExpanded = false;
        private bool isFinanceiroExpanded = false;
        private bool isClienteExpanded = false;
        private bool isRelatorioExpanded = false;
        private bool isServicoExpanded = false;
        private bool isProdutoExpanded = false;
        private bool isFuncionarioExpanded = false;
        private bool isMenuExpanded = false;

        public Frame MainFrame { get; set; }

        public MenuControl()
        {
            InitializeComponent();
        }

        private void BtnToggleMenu_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(0.3))
            };

            if (isMenuExpanded)
            {
                animation.From = MenuPanel.ActualWidth;
                animation.To = 0;

                animation.Completed += (s, a) =>
                {
                    MenuPanel.Visibility = Visibility.Collapsed;
                };
            }
            else
            {
                MenuPanel.Visibility = Visibility.Visible;

                animation.From = 0;
                animation.To = 250;
            }

            MenuPanel.BeginAnimation(FrameworkElement.WidthProperty, animation);
            isMenuExpanded = !isMenuExpanded;
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            Window novaJanela = new Window
            {
                Content = new InformacoesUsuario(),
                Width = 800,
                Height = 460,
                Owner = Application.Current.MainWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                WindowStyle = WindowStyle.None, 
                ResizeMode = ResizeMode.NoResize
            };
            novaJanela.ShowDialog();
        }
        private void AlternarVisibilidade(string painel)
        {
            if (AgendaOptions.Visibility == Visibility.Visible && painel == "Agenda")
            {
                AgendaOptions.Visibility = Visibility.Collapsed;
            }
            else if (FinanceiroOptions.Visibility == Visibility.Visible && painel == "Financeiro")
            {
                FinanceiroOptions.Visibility = Visibility.Collapsed;
            }
            else if (ClientesOptions.Visibility == Visibility.Visible && painel == "Cliente")
            {
                ClientesOptions.Visibility = Visibility.Collapsed;
            }
            else if (RelatorioOptions.Visibility == Visibility.Visible && painel == "Relatorio")
            {
                RelatorioOptions.Visibility = Visibility.Collapsed;
            }
            else if (ServicoOptions.Visibility == Visibility.Visible && painel == "Servico")
            {
                ServicoOptions.Visibility = Visibility.Collapsed;
            }
            else if (ProdutoOptions.Visibility == Visibility.Visible && painel == "Produto")
            {
                ProdutoOptions.Visibility = Visibility.Collapsed;
            }
            else if (FuncionarioOptions.Visibility == Visibility.Visible && painel == "Funcionario")
            {
                FuncionarioOptions.Visibility = Visibility.Collapsed;
            }
            else
            {
                AgendaOptions.Visibility = painel == "Agenda" ? Visibility.Visible : Visibility.Collapsed;
                FinanceiroOptions.Visibility = painel == "Financeiro" ? Visibility.Visible : Visibility.Collapsed;
                ClientesOptions.Visibility = painel == "Cliente" ? Visibility.Visible : Visibility.Collapsed;
                RelatorioOptions.Visibility = painel == "Relatorio" ? Visibility.Visible : Visibility.Collapsed;
                ServicoOptions.Visibility = painel == "Servico" ? Visibility.Visible : Visibility.Collapsed;
                ProdutoOptions.Visibility = painel == "Produto" ? Visibility.Visible : Visibility.Collapsed;
                FuncionarioOptions.Visibility = painel == "Funcionario" ? Visibility.Visible : Visibility.Collapsed;
            }

        }

        private void BtnAgenda_Click(object sender, RoutedEventArgs e)
        {
            AlternarVisibilidade("Agenda");
        }

        private void BtnFinanceiro_Click(object sender, RoutedEventArgs e)
        {
            AlternarVisibilidade("Financeiro");
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            AlternarVisibilidade("Cliente");
        }

        private void BtnRelatorio_Click(object sender, RoutedEventArgs e)
        {
            AlternarVisibilidade("Relatorio");
        }

        private void BtnServico_Click(object sender, RoutedEventArgs e)
        {
            AlternarVisibilidade("Servico");
        }

        private void BtnProduto_Click(object sender, RoutedEventArgs e)
        {
            AlternarVisibilidade("Produto");
        }

        private void BtnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            AlternarVisibilidade("Funcionario");
        }

        private void BtnCalendario_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.Agenda());
        }

        private void BtnListagemAgenda_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new Telas.ListagemAgenda());
        }

        private void BtnBloqueios_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.AgendaBloqueio());
        }

        private void BtnComandas_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaComanda());
        }

        private void BtnCaixa_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaCaixa());
        }

        private void BtnListagemClientes_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaCliente());
        }

        private void BtnOrcamento_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new Telas.Orcamento());
        }

        private void BtnPainel_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new Telas.Painel());
        }

        private void BtnListagemServico_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaServico());
        }

        private void BtnCategoria_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new Telas.CategoriaServico());
        }

        private void BtnPacote_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new Telas.Pacote());
        }

        private void BtnListagemProduto_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaProduto());
        }

        private void BtnCategoriaProduto_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new Telas.CategoriaProduto());
        }

        private void BtnFornecedor_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaFornecedor());
        }

        private void BtnListagemFuncionario_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaFuncionario());
        }

        private void BtnExpediente_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Telas.TabelaExpediente());
        }

        private void BtnEstoque_Click(object sender, RoutedEventArgs e)
        {
            //MainFrame.Navigate(new Telas.Estoque());
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void BtnDesconectar_Click(object sender, RoutedEventArgs e)
        {
            JanelaPrincipal janelaPrincipal = new JanelaPrincipal();

            janelaPrincipal.MainFrame.Navigate(new TelaInicial());

            janelaPrincipal.menuLogin.Visibility = Visibility.Visible;
            janelaPrincipal.menuControl.Visibility = Visibility.Collapsed;

            Application.Current.MainWindow = janelaPrincipal;
            janelaPrincipal.Show();
            Window.GetWindow(this)?.Close();
        }

    }
}
