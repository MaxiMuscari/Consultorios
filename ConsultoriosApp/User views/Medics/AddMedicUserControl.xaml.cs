using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConsultoriosApp
{
    /// <summary>
    /// Lógica de interacción para AddMedicUserControl.xaml
    /// </summary>
    public partial class AddMedicUserControl : UserControl
    {

        private readonly ConsultorioContext _context = new ConsultorioContext();

        public AddMedicUserControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbEspecialities.ItemsSource = Enum.GetValues(typeof(Especialities));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var especiality = (Especialities)Enum.Parse(typeof(Especialities), cmbEspecialities.SelectedItem.ToString());
            var medic = new Medic(txtName.Text, txtSurname.Text, txtDNI.Text, txtCUIL.Text, txtPhoneNumber.Text, especiality);
            _context.Medics.Add(medic);
            _context.SaveChanges();
            Application.Current.MainWindow.Content = new MainMedicsUserControl();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainMedicsUserControl();
        }


        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = txtName.Text;
            bool isTextValid = Regex.IsMatch(text, @"^[a-zA-Z]+$");
            if (!isTextValid)
            {
                nameValidationMsj.Text = "El nombre es invalido";
                btnSave.IsEnabled = false;
            }
            else
            {
                nameValidationMsj.Text = "";
                btnSave.IsEnabled = true;
            }
        }

        private void txtSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = txtSurname.Text;
            bool isTextValid = Regex.IsMatch(text, @"^[a-zA-Z]+$");
            if (!isTextValid)
            {
                surnameValidationMsj.Text = "El apellido es invalido";
                btnSave.IsEnabled = false;
            }
            else
            {
                surnameValidationMsj.Text = "";
                btnSave.IsEnabled = true;
            }
        }

        private void txtDNI_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = txtDNI.Text;
            bool isTextValid = Regex.IsMatch(text, "^[0-9]+$");
            if (!isTextValid)
            {
                DNIValidationMsj.Text = "El DNI es invalido";
                btnSave.IsEnabled = false;
            }
            else
            {
                DNIValidationMsj.Text = "";
                btnSave.IsEnabled = true;
            }
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = txtCUIL.Text;
            bool isTextValid = Regex.IsMatch(text, @"^[ a-zA-Z0-9]+$");
            if (!isTextValid)
            {
                CUILValidationMsj.Text = "El CUIL es invalido";
                btnSave.IsEnabled = false;
            }
            else
            {
                CUILValidationMsj.Text = "";
                btnSave.IsEnabled = true;
            }
        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = txtPhoneNumber.Text;
            bool isTextValid = Regex.IsMatch(text, "^[0-9]+$");
            if (!isTextValid)
            {
                phoneNumberValidationMsj.Text = "El numero de telefono es invalido";
                btnSave.IsEnabled = false;
            }
            else
            {
                phoneNumberValidationMsj.Text = "";
                btnSave.IsEnabled = true;
            }
        }
    }
}
