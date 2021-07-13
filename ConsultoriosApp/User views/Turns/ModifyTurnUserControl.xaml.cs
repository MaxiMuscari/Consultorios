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
using System.Collections;

namespace ConsultoriosApp
{
    /// <summary>
    /// Lógica de interacción para ModifyTurnUserControl.xaml
    /// </summary>
    public partial class ModifyTurnUserControl : UserControl
    {
        private readonly ConsultorioContext _context = new ConsultorioContext();

        private Turn _turn;
        public ModifyTurnUserControl(Turn turn)
        {
            InitializeComponent();
            _turn = turn;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cmbMedics.ItemsSource = _context.Medics.ToList();
            FillUserControl();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Content = new MainTurnUserControl();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            FillTurn();
            _context.Update(_turn);
            _context.SaveChanges();
            Application.Current.MainWindow.Content = new MainTurnUserControl();

        }

        private void FillUserControl()
        {
            patientData.Text = $"{_turn.Patient.Names}";
            chkPaid.IsChecked = _turn.Paid;
            cmbMedics.SelectedItem = _turn.Medic;
            dtpDate.SelectedDate = _turn.Schedule.Date;
            tmpTime.SelectedTime = _turn.Schedule.ToLocalTime().AddHours(3);

        }

        private void FillTurn()
        {

            _turn.Paid = (bool)chkPaid.IsChecked;
            _turn.Medic = (Medic)cmbMedics.SelectedItem;
            _turn.Schedule = dtpDate.SelectedDate.Value + tmpTime.SelectedTime.Value.TimeOfDay;

        }

    }
}
