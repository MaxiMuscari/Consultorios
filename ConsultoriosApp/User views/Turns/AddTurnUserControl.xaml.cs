using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
using Microsoft.EntityFrameworkCore;



namespace ConsultoriosApp
{
    /// <summary>
    /// Lógica de interacción para AddTurnUserControl.xaml
    /// </summary>
    public partial class AddTurnUserControl : UserControl
    {

        private readonly ConsultorioContext _context = new ConsultorioContext();

        private Patient patient;
        public AddTurnUserControl()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbMedics.ItemsSource = _context.Medics.ToList();
                       
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainTurnUserControl();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var search = txtSearch.Text.ToLower();
            patient = _context.Patients
                .Where(x => x.DNI.Equals(search))
                .FirstOrDefault();

            if (patient != null)
            {
                patientData.Text = $"{patient.Names}";
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var newTurn = new Turn()
            {
                Patient = patient,
                Paid = (bool)chkPaid.IsChecked,
                Schedule = dtpDate.SelectedDate.Value + tmpTime.SelectedTime.Value.TimeOfDay,
                Medic = (Medic)cmbMedics.SelectedItem
            };

            _context.Turns.Add(newTurn);
            _context.SaveChanges();
            Application.Current.MainWindow.Content = new MainTurnUserControl();

        }
    }
}
