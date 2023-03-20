using Lab2.Entities;
using Lab2.Enums;
using Lab2.Helpers;

internal class Program
{
    private static void Main(string[] args)
    {
        const int SEED_PATIENTS_CNT = 5;
        var patients = Patient.SeedPatients(SEED_PATIENTS_CNT);

        var reception = new List<Patient>();

        MainMenu(patients, reception);
    }

    private static void MainMenu(List<Patient> patients, List<Patient> reception)
    {
        var exit = false;

        while (!exit)
        {
            ConsolePrintHelpers.MainMenu();
            var userInput = (MainMenuOptions)InputHelpers.InputNumberChoice(
                Enum.GetValues(typeof(MainMenuOptions)).Cast<int>().Min(),
                Enum.GetValues(typeof(MainMenuOptions)).Cast<int>().Max());

            Console.Clear();

            switch (userInput)
            {
                case MainMenuOptions.Quit:
                    exit = true;
                    break;
                case MainMenuOptions.ManagePatients:
                    SubmenuManagePatients(patients);
                    break;
                case MainMenuOptions.ReceptionActions:
                    SubmenuReceptionActions(patients, reception);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private static void SubmenuManagePatients(List<Patient> patients)
    {
        var back = false;

        while (!back)
        {
            ConsolePrintHelpers.SubmenuManagePatients();
            var userInput = (SubmenuManagePatientsOptions)InputHelpers.InputNumberChoice(
                Enum.GetValues(typeof(SubmenuManagePatientsOptions)).Cast<int>().Min(),
                Enum.GetValues(typeof(SubmenuManagePatientsOptions)).Cast<int>().Max());

            Console.Clear();

            switch (userInput)
            {
                case SubmenuManagePatientsOptions.BackToMainMenu:
                    back = true;
                    break;
                case SubmenuManagePatientsOptions.DisplayPatients:
                    DisplayPatients(patients);
                    break;
                case SubmenuManagePatientsOptions.AddPatient:
                    AddPatient(patients);
                    break;
                case SubmenuManagePatientsOptions.EditPatient:
                    EditPatient(patients);
                    break;
                case SubmenuManagePatientsOptions.DeletePatient:
                    DeletePatient(patients);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private static void DisplayPatients(List<Patient> patients, string displayFilter = "all")
    {
        Console.WriteLine(displayFilter == "reception"
            ? "----- Display Currently Admitted Patients: -----"
            : "----- Display All Patients: -----");

        Console.WriteLine($"\nThere is currently {patients.Count} patients{(displayFilter == "reception" ? " admitted" : "")}.");

        foreach (var patient in patients)
        {
            Console.WriteLine(patient);
        }

        ConsolePrintHelpers.ReturnToPreviousMenu();
    }

    private static void AddPatient(List<Patient> patients)
    {
        Console.WriteLine("----- Add Patient: -----");

        Console.WriteLine("\nEnter patient details:");

        var oib = InputHelpers.InputUniqueOib(patients);
        var mbo = InputHelpers.InputUniqueMbo(patients);
        var firstName = InputHelpers.InputValue("First name");
        var lastName = InputHelpers.InputValue("Last name");
        var dateOfBirth = InputHelpers.InputDateOfBirth();
        var gender = InputHelpers.InputGender();
        var diagnosis = InputHelpers.InputValue("Diagnosis");

        patients.Add(new Patient(oib, mbo, firstName, lastName, dateOfBirth, gender, diagnosis));

        Console.WriteLine($"\nPatient {patients.Last()}\nwas successfully added!");

        ConsolePrintHelpers.ReturnToPreviousMenu();
    }

    private static void EditPatient(List<Patient> patients)
    {
        Console.WriteLine("----- Edit Patient: -----");

        Console.WriteLine("\nEnter the MBO of the patient you want to edit:");

        var mbo = Console.ReadLine().Trim();

        var updatedPatient = patients.Find(p => p.Mbo == mbo);

        if (updatedPatient == null)
        {
            Console.WriteLine($"\nPatient with MBO {mbo} doesn't exist.");
        }
        else
        {
            Console.WriteLine($"\nUpdating patient: {updatedPatient}");

            Console.WriteLine("\nChange OIB?");
            var changeOib = InputHelpers.ConfirmAction();

            switch (changeOib)
            {
                case ActionOptions.Confirm:
                    updatedPatient.Oib = InputHelpers.InputUniqueOib(patients);
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange MBO?");
            var changeMbo = InputHelpers.ConfirmAction();

            switch (changeMbo)
            {
                case ActionOptions.Confirm:
                    updatedPatient.Mbo = InputHelpers.InputUniqueMbo(patients);
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange first name?");
            var changeFirstName = InputHelpers.ConfirmAction();

            switch (changeFirstName)
            {
                case ActionOptions.Confirm:
                    updatedPatient.FirstName = InputHelpers.InputValue("First name");
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange last name?");
            var changeLastName = InputHelpers.ConfirmAction();

            switch (changeLastName)
            {
                case ActionOptions.Confirm:
                    updatedPatient.LastName = InputHelpers.InputValue("Last name");
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange date of birth?");
            var changeDateOfBirth = InputHelpers.ConfirmAction();

            switch (changeDateOfBirth)
            {
                case ActionOptions.Confirm:
                    updatedPatient.DateOfBirth = InputHelpers.InputDateOfBirth();
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange gender?");
            var changeGender = InputHelpers.ConfirmAction();

            switch (changeGender)
            {
                case ActionOptions.Confirm:
                    updatedPatient.Gender = InputHelpers.InputGender();
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine("\nChange diagnosis?");
            var changeDiagnosis = InputHelpers.ConfirmAction();

            switch (changeDiagnosis)
            {
                case ActionOptions.Confirm:
                    updatedPatient.Diagnosis = InputHelpers.InputValue("Diagnosis");
                    break;
                case ActionOptions.Cancel: break;
                default: throw new NotImplementedException();
            }

            Console.WriteLine($"\nPatient details successfully updated to: {updatedPatient}");
        }

        ConsolePrintHelpers.ReturnToPreviousMenu();
    }

    private static void DeletePatient(List<Patient> patients)
    {
        Console.WriteLine("----- Delete Patient: -----");

        Console.WriteLine("\nEnter the MBO of the patient you want to delete:");

        var mbo = Console.ReadLine().Trim();

        var deletedPatient = patients.Find(p => p.Mbo == mbo);

        if (deletedPatient == null)
        {
            Console.WriteLine($"\nPatient with MBO {mbo} doesn't exist.");
        }
        else
        {
            Console.WriteLine($"\nAre you sure you want to delete patient: {deletedPatient}\n");
            var userInput = InputHelpers.ConfirmAction();

            switch (userInput)
            {
                case ActionOptions.Confirm:
                    patients.Remove(deletedPatient);
                    Console.WriteLine("\nPatient successfully deleted!");
                    break;
                case ActionOptions.Cancel:
                    Console.WriteLine("\nAction canceled.");
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        ConsolePrintHelpers.ReturnToPreviousMenu();
    }

    private static void SubmenuReceptionActions(List<Patient> patients, List<Patient> reception)
    {
        var back = false;

        while (!back)
        {
            ConsolePrintHelpers.SubmenuReceptionActions();
            var userInput = (SubmenuReceptionActionsOptions)InputHelpers.InputNumberChoice(
                Enum.GetValues(typeof(SubmenuReceptionActionsOptions)).Cast<int>().Min(),
                Enum.GetValues(typeof(SubmenuReceptionActionsOptions)).Cast<int>().Max());

            Console.Clear();

            switch (userInput)
            {
                case SubmenuReceptionActionsOptions.BackToMainMenu:
                    back = true;
                    break;
                case SubmenuReceptionActionsOptions.DisplayAdmittedPatients:
                    DisplayPatients(reception, "reception");
                    break;
                case SubmenuReceptionActionsOptions.PatientAdmittance:
                    PatientAdmittance(patients, reception);
                    break;
                case SubmenuReceptionActionsOptions.PatientDischarge:
                    PatientDischarge(patients, reception);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private static void PatientAdmittance(List<Patient> patients, List<Patient> reception)
    {
        Console.WriteLine("----- Patient Admittance: -----");

        Console.WriteLine("\nEnter the MBO of the patient to be admitted to the hospital:");

        var mbo = Console.ReadLine().Trim();

        var admittedPatient = patients.Find(p => p.Mbo == mbo);

        if (admittedPatient == null)
        {
            Console.WriteLine($"\nPatient with MBO {mbo} doesn't exist.");
        }
        else if (reception.Contains(admittedPatient))
        {
            Console.WriteLine($"\nPatient {admittedPatient}\nis already admitted to the hospital!");
        }
        else
        {
            Console.WriteLine($"\nPatient {admittedPatient}\nadmitted to the hospital at {DateTime.Now}.");
            reception.Add(admittedPatient);
        }

        ConsolePrintHelpers.ReturnToPreviousMenu();
    }

    private static void PatientDischarge(List<Patient> patients, List<Patient> reception)
    {
        Console.WriteLine("----- Patient Discharge: -----");

        Console.WriteLine("\nEnter the MBO of the patient to be discharged from the hospital:");

        var mbo = Console.ReadLine().Trim();

        var dischargedPatient = patients.Find(p => p.Mbo == mbo);

        if (dischargedPatient == null)
        {
            Console.WriteLine($"\nPatient with MBO {mbo} doesn't exist.");
        }
        else if (!reception.Contains(dischargedPatient))
        {
            Console.WriteLine($"\nPatient {dischargedPatient}\nis not currently admitted to the hospital!");
        }
        else
        {
            Console.WriteLine($"\nPatient {dischargedPatient}\ndischarged from the hospital at {DateTime.Now}.");
            reception.Remove(dischargedPatient);
        }

        ConsolePrintHelpers.ReturnToPreviousMenu();
    }
}
