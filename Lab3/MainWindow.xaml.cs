using Lab3.Entities;
using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int SEED_PATIENTS_CNT = 5;
        public static List<Patient> patients = Patient.SeedPatients(SEED_PATIENTS_CNT);

        public MainWindow()
        {
            InitializeComponent();

            PatientGrid.ItemsSource = patients;
        }

        private void DisplayAdmittedPatients_Click(object sender, RoutedEventArgs e)
        {
            DisplayAdmittedPatients displayAdmittedPatients = new DisplayAdmittedPatients();
            displayAdmittedPatients.Show();
        }

        private void AdmittOrDischarge_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = ((FrameworkElement)sender).DataContext as Patient;
            if (!patient.isCurrentlyAdmitted())
            {
                patient.Admitt();
            }
            else
            {
                patient.Discharge();
            }
        }
    }
}
