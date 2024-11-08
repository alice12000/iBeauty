using IBeauty.Controle;
using System.Windows;

namespace IBeauty
{
    public partial class JanelaPrincipal : Window
    {
        public JanelaPrincipal()
        {
            InitializeComponent();

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
                cbMenuControl.IsChecked = true;
            }
            else
            {
                menuLogin.Visibility = Visibility.Visible;
                menuControl.Visibility = Visibility.Collapsed;
                cbMenuLogin.IsChecked = true;
            }

            ((MenuLogin)menuLogin).MainFrame = MainFrame;
            ((MenuControl)menuControl).MainFrame = MainFrame;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == cbMenuControl)
            {
                menuControl.Visibility = Visibility.Visible;
                menuLogin.Visibility = Visibility.Collapsed;
                cbMenuLogin.IsChecked = false;
            }
            else if (sender == cbMenuLogin)
            {
                menuControl.Visibility = Visibility.Collapsed;
                menuLogin.Visibility = Visibility.Visible;

                ((MenuLogin)menuLogin).FecharMenu();
                cbMenuControl.IsChecked = false;
            }
        }

    }
}
 