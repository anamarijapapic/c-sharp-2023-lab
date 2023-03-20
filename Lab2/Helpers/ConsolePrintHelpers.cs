using Lab2.Enums;

namespace Lab2.Helpers
{
    internal class ConsolePrintHelpers
    {
        public static void MainMenu()
        {
            Console.Clear();
            PrintEnumOptions(new MainMenuOptions(), "Main Menu");
        }

        public static void ReturnToPreviousMenu()
        {
            Console.WriteLine("\nEnter any key to return to previous menu...");
            Console.ReadKey();
        }

        public static void SubmenuManagePatients()
        {
            Console.Clear();
            PrintEnumOptions(new SubmenuManagePatientsOptions(), "Manage Patients");
        }

        public static void SubmenuReceptionActions()
        {
            Console.Clear();
            PrintEnumOptions(new SubmenuReceptionActionsOptions(), "Reception Actions");
        }

        public static void PrintEnumOptions(Enum e, string title)
        {
            Console.WriteLine($"----- {title}: -----");
            foreach (var item in Enum.GetValues(e.GetType()))
            {
                Console.WriteLine("{0} - {1}", (int)item, item);
            }
        }
    }
}
