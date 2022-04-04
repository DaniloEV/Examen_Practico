using ApplicativoWpf.MVVM.ViewModel;
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
using System.Windows.Shapes;

namespace ApplicativoWpf.MVVM.View
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginViewModel loginViewModel = new LoginViewModel();
        public Login()
        {
            InitializeComponent();
            DataContext = loginViewModel;
        }
        private void BtnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IniciarSesion();
            }
            catch (Exception ex)
            {

            }
        }
        private void IniciarSesion()
        {
            try
            {
                loginViewModel.AutenticarUsuario();

                if (loginViewModel.UsuarioLogin != null)
                {
                    MainWindow mainWindow = new MainWindow();
                    Close();
                    mainWindow.Show();
                    Application.Current.MainWindow = mainWindow;
                }
                else
                {
                    MessageBox.Show("Datos de inicio incorrectos.", "Error al autenticar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al autenticar", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
