using AutoMapper;
using Lab4.WPF.Entities;
using Lab4.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Lab4.WPF
{
    public partial class MainWindow : Window
    {
        private List<PatientDto> patients;

        private List<DiagnosisDto> diagnosis;

        private readonly IMapper _mapper;

        public MainWindow()
        {
            InitializeComponent();
            PopulatePatients();
            PopulateDiagnosis();
            PatientsListBox.ItemsSource = patients;
            DiagnosisComboBox.ItemsSource = diagnosis;
            InsuranceComboBox.ItemsSource = Enum.GetValues(typeof(Insurance));
            GenderComboBox.ItemsSource = Enum.GetValues(typeof(Gender));
        }

        public void PopulatePatients()
        {
            var patientsResponse = WebAPI.GetCall("api/patients");

            if (patientsResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var jsonString = patientsResponse.Result.Content.ReadAsStringAsync().Result;

                try
                {
                    patients = JsonSerializer.Deserialize<List<PatientDto>>(jsonString, options);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }

        public void PopulateDiagnosis()
        {
            var patientsResponse = WebAPI.GetCall("api/diagnoses");

            if (patientsResponse.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var jsonString = patientsResponse.Result.Content.ReadAsStringAsync().Result;

                try
                {
                    diagnosis = JsonSerializer.Deserialize<List<DiagnosisDto>>(jsonString, options);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }

        private void CreateNewPatient()
        {
            DiagnosisDto diagnosis = DiagnosisComboBox.SelectedValue as DiagnosisDto;
            Gender gender = (Gender)GenderComboBox.SelectedValue;
            Insurance insurance = (Insurance)InsuranceComboBox.SelectedValue;

            var newPatient = new PatientForCreateDto()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                PatientOib = OIBTextBox.Text,
                PatientMbo = MBOTextBox.Text,
                PatientGender = gender,
                PatientInsurance = insurance,
                DiagnosisId = diagnosis.Id,
                DateOfBirth = DateOfBirthDatePicker.SelectedDate.Value,
                DateOfAdmittance = AdmissionDateDatePicker.SelectedDate.Value,
                DateOfDischarge = DischargeDateDatePicker.SelectedDate.Value,
            };

            if (patients.Count(patient => patient.PatientOib == newPatient.PatientOib) >= 1)
            {
                MessageBox.Show($"Patient with oib {newPatient.PatientOib} already exist");

                return;
            }
            else if (patients.Count(patient => patient.PatientMbo == newPatient.PatientMbo) >= 1)
            {
                MessageBox.Show($"Patient with mbo {newPatient.PatientMbo} already exist");

                return;
            }
            else
            {
                var patientDetails = WebAPI.PostCall("api/patients", newPatient);

                if (patientDetails.Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show($"{newPatient.FirstName} {newPatient.LastName} is successfully added");
                }
                else
                {
                    MessageBox.Show(patientDetails.ToString());
                }
            }
        }

        private void UpdatePatient(PatientDto patientFromDatabase)
        {
            DiagnosisDto diagnosis = DiagnosisComboBox.SelectedValue as DiagnosisDto;
            Gender gender = (Gender)GenderComboBox.SelectedValue;
            Insurance insurance = (Insurance)InsuranceComboBox.SelectedValue;

            var updatedPatient = new PatientForCreateDto()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                PatientOib = OIBTextBox.Text,
                PatientMbo = MBOTextBox.Text,
                PatientGender = gender,
                PatientInsurance = insurance,
                DiagnosisId = diagnosis.Id,
                DateOfBirth = DateOfBirthDatePicker.SelectedDate.Value,
                DateOfAdmittance = AdmissionDateDatePicker.SelectedDate.Value,
                DateOfDischarge = DischargeDateDatePicker.SelectedDate.Value,
            };

            var patientDetails = WebAPI.PutCall($"api/patients/{patientFromDatabase.Id}", updatedPatient);

            if (patientDetails.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show($"{updatedPatient.FirstName} {updatedPatient.LastName} is successfully updated");
            }
            else
            {
                MessageBox.Show($"Failed to update: {updatedPatient.FirstName} {updatedPatient.LastName}");
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsListBox.SelectedItem != null)
            {
                PatientDto selectedPatient = (PatientDto)PatientsListBox.SelectedItem;

                UpdatePatient(selectedPatient);

                ClearInput();
                PatientsListBox.ItemsSource = null;
                PopulatePatients();
                PatientsListBox.ItemsSource = patients;
            }
        }

        private void DeletePatient(PatientDto patient)
        {
            var patientDetails = WebAPI.DeleteCall($"api/patients/{patient.Id}");

            if (patientDetails.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show($"{patient.FirstName} {patient.LastName} is successfully deleted");
            }
            else
            {
                MessageBox.Show($"Failed to delete {patient.FirstName} {patient.LastName}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (patients.Any(p => p.PatientMbo == OIBTextBox.Text))
            {
                MessageBox.Show("A patient with this OIB already exists.");

                return;
            }

            if (ValidateInput())
            {
                CreateNewPatient();

                ClearInput();

                PatientsListBox.ItemsSource = null;
                PopulatePatients();
                PatientsListBox.ItemsSource = patients;
            }
        }

        private void PatientListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PatientsListBox.SelectedItem != null)
            {
                PatientDto selectedPatient = (PatientDto)PatientsListBox.SelectedItem;

                FirstNameTextBox.Text = selectedPatient.FirstName;
                LastNameTextBox.Text = selectedPatient.LastName;
                OIBTextBox.Text = selectedPatient.PatientOib;
                MBOTextBox.Text = selectedPatient.PatientMbo;
                GenderComboBox.SelectedItem = selectedPatient.PatientGender;
                DateOfBirthDatePicker.SelectedDate = selectedPatient.DateOfBirth;
                AdmissionDateDatePicker.SelectedDate = selectedPatient.DateOfAdmittance;
                DischargeDateDatePicker.SelectedDate = selectedPatient.DateOfDischarge;
                DiagnosisComboBox.SelectedIndex = selectedPatient.Diagnosis.Id - 1;
                InsuranceComboBox.SelectedItem = selectedPatient.PatientInsurance;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearInput();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (PatientsListBox.SelectedItem != null)
            {
                PatientDto selectedPatient = (PatientDto)PatientsListBox.SelectedItem;
                DeletePatient(selectedPatient);
                ClearInput();
                PatientsListBox.ItemsSource = null;
                PopulatePatients();
                PatientsListBox.ItemsSource = patients;
            }
        }

        public void ClearInput()
        {
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            OIBTextBox.Clear();
            MBOTextBox.Clear();
            GenderComboBox.SelectedIndex = -1;
            DateOfBirthDatePicker.SelectedDate = null;
            AdmissionDateDatePicker.SelectedDate = null;
            DischargeDateDatePicker.SelectedDate = null;
            DiagnosisComboBox.SelectedIndex = -1;
            InsuranceComboBox.SelectedIndex = -1;
        }

        public bool ValidateInput()
        {
            if (string.IsNullOrEmpty(FirstNameTextBox.Text) || string.IsNullOrEmpty(LastNameTextBox.Text)
                || string.IsNullOrEmpty(OIBTextBox.Text) || string.IsNullOrEmpty(MBOTextBox.Text)
                || GenderComboBox.SelectedItem == null || DateOfBirthDatePicker.SelectedDate == null
                || AdmissionDateDatePicker.SelectedDate == null || DischargeDateDatePicker.SelectedDate == null
                || DiagnosisComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");

                return false;
            }

            string patternOIB = "^[0-9]{11}$";
            Regex regexOIB = new Regex(patternOIB);

            if (!regexOIB.IsMatch(OIBTextBox.Text))
            {
                MessageBox.Show("OIB must have 11 digits.");

                return false;
            }

            string patternMBO = "^[0-9]{9}$";
            Regex regexMBO = new Regex(patternMBO);

            if (!regexMBO.IsMatch(MBOTextBox.Text))
            {
                MessageBox.Show("MBO must have 9 digits.");

                return false;
            }

            string patternLetters = "^[a-zđčćšžA-ZĐČĆŠŽ]+$";
            Regex regexLetters = new Regex(patternLetters);

            if (!regexLetters.IsMatch(FirstNameTextBox.Text))
            {
                MessageBox.Show("First name can contain only letters.");

                return false;
            }

            if (!regexLetters.IsMatch(LastNameTextBox.Text))
            {
                MessageBox.Show("Last name can contain only letters.");

                return false;
            }

            if (AdmissionDateDatePicker.SelectedDate.Value > DischargeDateDatePicker.SelectedDate.Value)
            {
                MessageBox.Show("Admission date can not be greater than discharge date.");

                return false;
            }

            return true;
        }
    }
}
