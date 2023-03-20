using Lab2.Entities;
using Lab2.Enums;
using System.Text.RegularExpressions;
using static Bogus.DataSets.Name;

namespace Lab2.Helpers
{
    public class InputHelpers
    {
        public static int InputNumberChoice(int minValue, int maxValue, string message = "\nEnter your choice:")
        {
            do
            {
                Console.WriteLine(message);
                if (int.TryParse(Console.ReadLine(), out int numberChoice)
                    && numberChoice >= minValue && numberChoice <= maxValue)
                {
                    return numberChoice;
                }

                Console.WriteLine("Wrong input!");
            } while (true);
        }

        public static string InputValue(string inputType)
        {
            do
            {
                Console.WriteLine($"{inputType}:");

                var input = Console.ReadLine().Trim();

                if (ValidateInput(input, inputType)) return input;

                Console.WriteLine("Input is invalid!");
            } while (true);
        }

        public static bool ValidateInput(string input, string inputType)
        {
            switch (inputType)
            {
                case "OIB":
                    return ValidateOib(input);
                case "MBO":
                    return ValidateMbo(input);
                case "First name":
                case "Last name":
                case "Diagnosis":
                    return input.Length > 0;
                default: return false;
            }
        }

        public static bool ValidateOib(string input)
        {
            return Regex.IsMatch(input, "^[0-9]{11}$");
        }

        public static bool IsOibUnique(string oib, List<Patient> patients)
        {
            return !patients.Any(p => p.Oib == oib);
        }

        public static string InputUniqueOib(List<Patient> patients)
        {
            string oib;
            bool isOibUnique;

            do
            {
                oib = InputValue("OIB");

                isOibUnique = IsOibUnique(oib, patients);
                if (!isOibUnique)
                {
                    Console.WriteLine("Patient with that OIB already exists. Please retry.");
                }
            } while (!isOibUnique);

            return oib;
        }

        public static bool ValidateMbo(string input)
        {
            return Regex.IsMatch(input, "^[0-9]{9}$");
        }

        public static bool IsMboUnique(string mbo, List<Patient> patients)
        {
            return !patients.Any(p => p.Mbo == mbo);
        }

        public static string InputUniqueMbo(List<Patient> patients)
        {
            string mbo;
            bool isMboUnique;

            do
            {
                mbo = InputValue("MBO");

                isMboUnique = IsMboUnique(mbo, patients);
                if (!isMboUnique)
                {
                    Console.WriteLine("Patient with that MBO already exists. Please retry.");
                }
            } while (!isMboUnique);

            return mbo;
        }

        public static DateTime InputDateOfBirth()
        {
            do
            {
                Console.WriteLine($"Date of birth:");

                if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth) && dateOfBirth < DateTime.Now)
                {
                    return dateOfBirth;
                }

                Console.WriteLine("Input is invalid!");
            } while (true);
        }

        public static Gender InputGender()
        {
            ConsolePrintHelpers.PrintEnumOptions(new Gender(), "Gender");
            return (Gender)InputNumberChoice(
                Enum.GetValues(typeof(Gender)).Cast<int>().Min(),
                Enum.GetValues(typeof(Gender)).Cast<int>().Max());
        }

        public static ActionOptions ConfirmAction()
        {
            ConsolePrintHelpers.PrintEnumOptions(new ActionOptions(), "Proceed");
            return (ActionOptions)InputHelpers.InputNumberChoice(
                Enum.GetValues(typeof(ActionOptions)).Cast<int>().Min(),
                Enum.GetValues(typeof(ActionOptions)).Cast<int>().Max());
        }
    }
}
