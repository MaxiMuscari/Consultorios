using System;
using System.Collections.Generic;
using System.Text;
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
    public partial class ModifyPatientUserControl : UserControl
    {
        private readonly ConsultorioContext _context = new ConsultorioContext();

        private Patient _patient;

        public ModifyPatientUserControl(Patient patient)
        {
            InitializeComponent();
            _patient = patient;
            FillTextBox();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            FillPatient();
            _context.Update(_patient);
            _context.SaveChanges();
            Application.Current.MainWindow.Content = new MainPatientUserControl();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainPatientUserControl();
        }

        private void FillTextBox()
        {
            txtName.Text = _patient.Name;
            txtSurname.Text = _patient.Surname;
            txtDNI.Text = _patient.DNI;
            txtAddress.Text = _patient.Address;
            txtMedicalSecurity.Text = _patient.MedicalSecurity;
            txtPhoneNumber.Text = _patient.PhoneNumber;
        }

        private void FillPatient()
        {
            _patient.Name = txtName.Text;
            _patient.Surname = txtSurname.Text;
            _patient.DNI = txtDNI.Text;
            _patient.Address = txtAddress.Text;
            _patient.MedicalSecurity = txtMedicalSecurity.Text;
            _patient.PhoneNumber = txtPhoneNumber.Text;
        }
    }
}
