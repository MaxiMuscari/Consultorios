using Microsoft.EntityFrameworkCore;
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
    /// <summary>
    /// Lógica de interacción para ModifyMedicUserControl.xaml
    /// </summary>
    public partial class ModifyMedicUserControl : UserControl
    {
        private readonly ConsultorioContext _context = new ConsultorioContext();

        private Medic _medic;

        public ModifyMedicUserControl(Medic medic)
        {
            InitializeComponent();
            _medic = medic;
            CompleteTextBox();

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbEspecialities.ItemsSource = Enum.GetValues(typeof(Especialities));
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CompleteMedic();
            _context.Medics.UpdateRange(_medic);
            _context.SaveChanges();
            Application.Current.MainWindow.Content = new MainMedicsUserControl();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainMedicsUserControl();
        }

        private void CompleteTextBox()
        {
            txtName.Text = _medic.Name;
            txtSurname.Text = _medic.Surname;
            txtDNI.Text = _medic.DNI;
            txtCUIL.Text = _medic.CUIL;
            txtPhoneNumber.Text = _medic.PhoneNumber;
            cmbEspecialities.SelectedItem = _medic.Especialities;
        }

        private void CompleteMedic()
        {
            _medic.Name = txtName.Text;
            _medic.Surname = txtSurname.Text;
            _medic.DNI = txtDNI.Text;
            _medic.CUIL = txtCUIL.Text;
            _medic.PhoneNumber = txtPhoneNumber.Text;
            _medic.Especialities = (Especialities)Enum.Parse(typeof(Especialities), cmbEspecialities.SelectedItem.ToString());
        }


    }
}
