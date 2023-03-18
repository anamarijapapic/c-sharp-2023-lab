using Task3.Entities;
using Task3.Enums;
using Task3.Helpers;

internal class Program
{
    public const int MAX_ACCOUNTS = 5;
    public static int numberOfAccounts = 0;

    private static void Main(string[] args)
    {
        MainMenu();
    }

    private static void MainMenu()
    {
        var exit = false;
        var bankAccounts = new BankAccount[MAX_ACCOUNTS];

        while (!exit)
        {
            ConsolePrintHelpers.MainMenu();
            var userInput = InputHelpers.InputNumberChoice(0, 2);

            Console.Clear();
            switch (userInput)
            {
                case 0:
                    exit = true;
                    break;
                case 1:
                    EnterAccount(bankAccounts);
                    break;
                case 2:
                    PrintAccounts(bankAccounts);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    private static void EnterAccount(BankAccount[] bankAccounts)
    {
        ConsolePrintHelpers.EnterAccountSubmenuTitle();
        if (numberOfAccounts == MAX_ACCOUNTS)
        {
            Console.WriteLine("\nYou already have maximal number of accounts!");
        }
        else
        {
            Console.WriteLine("\nEnter the account number:");
            bankAccounts[numberOfAccounts].number = Console.ReadLine();

            Console.WriteLine("\nEnter the account amount:");
            var amountInput = decimal.Parse(Console.ReadLine());
            bankAccounts[numberOfAccounts].amount = amountInput;

            ConsolePrintHelpers.AccountTypeOptions();
            var accountTypeNumber = InputHelpers.InputNumberChoice(0, 2);
            bankAccounts[numberOfAccounts].accountType = (AccountTypes)accountTypeNumber;

            numberOfAccounts++;
            Console.WriteLine("\nNew bank account sucessfully added!");
        }

        ConsolePrintHelpers.ReturntoMainMenu();
    }

    private static void PrintAccounts(BankAccount[] bankAccounts)
    {
        ConsolePrintHelpers.ListAccountsSubmenuTitle();

        foreach (var bankAccount in bankAccounts)
        {
            Console.WriteLine($"\nAccount No. {bankAccount.number}, " +
                $"Amount: {bankAccount.amount:C}, " +
                $"Type: {bankAccount.accountType}");
        }

        ConsolePrintHelpers.ReturntoMainMenu();
    }
}
