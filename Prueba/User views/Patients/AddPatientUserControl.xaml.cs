using Microsoft.EntityFrameworkCore;
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

namespace Prueba
{
    /// <summary>
    /// Lógica de interacción para FormUserControl.xaml
    /// </summary>
    public partial class AddPatientUserControl : UserControl
    {
        private readonly ConsultorioContext _context = new ConsultorioContext();


        public AddPatientUserControl()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var patient = new Patient(txtName.Text, txtSurname.Text, txtDNI.Text, txtAddress.Text, txtMedicalSecurity.Text, txtPhoneNumber.Text);
            //var patient = new Patient();
            _context.Patients.Add(patient);
            txtClean();
            validationClean();
            _context.SaveChanges();
            Application.Current.MainWindow.Content = new MainPatientUserControl();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainPatientUserControl();
        }

        public void txtClean()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtDNI.Text = "";
            txtMedicalSecurity.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
        }

        public void validationClean()
        {
            nameValidationMsj.Text = "";
            surnameValidationMsj.Text = "";
            DNIValidationMsj.Text = "";
            medicalSecurityValidationMsj.Text = "";
            phoneNumberValidationMsj.Text = "";
            addressValidationMsj.Text = "";
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
            var text = txtAddress.Text;
            bool isTextValid = Regex.IsMatch(text, @"^[ a-zA-Z0-9]+$");
            if (!isTextValid)
            {
                addressValidationMsj.Text = "El domicilio es invalido";
                btnSave.IsEnabled = false;
            }
            else
            {
                addressValidationMsj.Text = "";
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
