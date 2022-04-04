using ApplicativoWpf.MVVM.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicativoWpf.MVVM.CustomControl
{
    /// <summary>
    /// Lógica de interacción para CustomRegistrarUserControl.xaml
    /// </summary>
    public partial class CustomRegistrarUserControl : UserControl
    {
        RegistroViewModel RegistroViewModel = new RegistroViewModel();
        public CustomRegistrarUserControl()
        {
            RegistroViewModel.InitList();
            InitializeComponent();
            DataContext = RegistroViewModel;
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegistrarUsuario();
            }
            catch (Exception ex)
            {

            }
        }
        private void BtnRegresar_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "MVVM/CustomControl/", "CustomBienvenidoUserControl", ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }
        private void RegistrarUsuario()
        {
            try
            {

                if (!ValidationForm())
                {
                    this.Cursor = Cursors.Wait;
                    ;
                    if (RegistroViewModel.RegistrarUsuario() != null)
                    {
                        MessageBox.Show("Usuario guardado con éxito.", "Usuario guardado", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Datos del usuario incorrectos.", "Error usuario guardado", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe agregar los campos obligatorios.", "Debe agregar los campos obligatorios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private bool ValidationForm()
        {
            try
            {
                BindingExpression bindingNombre = this.NombreUsuarioTxt.GetBindingExpression(TextBox.TextProperty);
                BindingExpression bindingContrasenna = this.ContrasennaTxt.GetBindingExpression(TextBox.TextProperty);
                BindingExpression bindingRol = this.RolCbx.GetBindingExpression(ComboBox.SelectedItemProperty);

                bindingNombre.UpdateSource();
                bindingContrasenna.UpdateSource();
                bindingRol.UpdateSource();

                bool hasNombreError = bindingNombre.HasError;
                bool hasContrasennaError = bindingContrasenna.HasError;
                bool hasRolError = bindingRol.HasError;

                return hasNombreError || hasContrasennaError || hasRolError;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
