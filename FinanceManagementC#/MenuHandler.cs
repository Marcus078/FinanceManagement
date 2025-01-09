using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagementC_
{
    class MenuHandler
    {
        public void DisplayMainMenu_NoCurrentAccount()
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Create Current Account");
            Console.WriteLine("2. Exit");
        }

        public void DisplayMainMenu_NoSavingsAccount()
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. View Current Account");
            Console.WriteLine("2. Create Savings Account");
            Console.WriteLine("3. Exit");
        }

        public void DisplayMainMenu_AllAccounts()
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. View Current Account");
            Console.WriteLine("2. View Savings Account");
            Console.WriteLine("3. Exit");
        }

        // Handle the menu for managing a specific account (e.g., deposit, withdraw, transfer).
        // Takes the account to manage as 'account' and a dictionary of all user accounts
        // as 'userAccounts' to enable operations like transfers between accounts.
        public void HandleAccountMenu(Account account, Dictionary<string, Account> userAccounts)
        {
            while (true)
            {
                Console.WriteLine($"\n--- {account.Name}'s Account Menu ---");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. View Account Details");
                Console.WriteLine("5. View Transaction History");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("Select an option: ");

                int choice = SafeInput.ReadInt();
                //peform operation on specefic account
                switch (choice)
                {
                    case 1:
                        account.Deposit();
                        break;
                    case 2:
                        account.Withdraw();
                        break;
                    case 3:
                        account.Transfer(userAccounts);
                        break;
                    case 4:
                        account.ViewDetails();
                        break;
                    case 5:
                        account.ViewTransactionHistory();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        public void ExitApplication()
        {
            Console.WriteLine("Exiting the application. Goodbye!");
        }
    }
}
