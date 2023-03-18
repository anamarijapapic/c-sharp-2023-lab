namespace Task3.Helpers
{
    internal class ConsolePrintHelpers
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(@"
+------- Main Menu -------+
| 1 - Enter a new account |
| 2 - Print all accounts  |
| 0 - Quit                |
+-------------------------+");
        }

        public static void ReturntoMainMenu() 
        {
            Console.WriteLine("\nEnter any key to continue to main menu...");
            Console.ReadKey();
        }

        public static void EnterAccountSubmenuTitle()
        {
            Console.WriteLine(@"
+----------------------+
| Enter a new account: |
+----------------------+");
        }

        public static void AccountTypeOptions() 
        {
            Console.WriteLine(@"
Choose the account type:
+--- Account Types ---+
| 0 - Savings         |
| 1 - Current account |
| 2 - Giro account    |
+---------------------+");
        }

        public static void ListAccountsSubmenuTitle() 
        {
            Console.WriteLine(@"
+-----------------------+
| Listing all accounts: |
+-----------------------+");
        }
    }
}
