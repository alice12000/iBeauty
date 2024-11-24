using IBeauty.Controle;
using IBeauty.Telas;
using System.Windows;

namespace IBeauty
{
    public partial class JanelaPrincipal : Window
    {
        public JanelaPrincipal()
        {
            InitializeComponent();
            MainFrame.Navigate(new Teste());

            bool isUserLoggedIn = false;

            if (MainFrame == null)
            {
                MessageBox.Show("MainFrame não está inicializado.");
                return;
            }

            if (isUserLoggedIn)
            {
                menuLogin.Visibility = Visibility.Collapsed;
                menuControl.Visibility = Visibility.Visible;
            }
            else
            {
                menuLogin.Visibility = Visibility.Visible;
                menuControl.Visibility = Visibility.Collapsed;
            }

            ((MenuLogin)menuLogin).MainFrame = MainFrame;
            ((MenuControl)menuControl).MainFrame = MainFrame;
        }

        private void JanelaPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
