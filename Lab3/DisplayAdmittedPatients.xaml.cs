using Lab3.Entities;
using System.Collections.Generic;
using System.Windows;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for DisplayAdmittedPatients.xaml
    /// </summary>
    public partial class DisplayAdmittedPatients : Window
    {
        public DisplayAdmittedPatients()
        {
            InitializeComponent();

            List<Patient> admittedPatients = MainWindow.patients.FindAll(p => p.isCurrentlyAdmitted());

            if (admittedPatients != null)
            {
                PatientGrid.ItemsSource = admittedPatients;
            }
        }
    }
}
