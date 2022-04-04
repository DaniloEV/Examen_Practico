using ApplicativoWpf.MVVM.ViewModel;
using ApplicativoWpf.MVVM.View;
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

namespace ApplicativoWpf.MVVM.CustomControl
{
    /// <summary>
    /// Lógica de interacción para CustomBienvenidoUserControl.xaml
    /// </summary>
    public partial class CustomBienvenidoUserControl : UserControl
    {
        BienvenidoViewModel bienvenidoViewModel = new BienvenidoViewModel();
        public CustomBienvenidoUserControl()
        {
            bienvenidoViewModel.Usuario = LoginViewModel.GetUsuario();
            bienvenidoViewModel.InitList();
            InitializeComponent();
            DataContext = bienvenidoViewModel;
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "MVVM/CustomControl/", "CustomRegistrarUserControl", ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }
    }
}
