using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagementC_
{
    class Program
    {
        static void Main(string[] args)
        {
            var userAccounts = new Dictionary<string, Account>();
            string currentUserId = "USER123"; // Simulated logged-in user ID
            CurrentAccount currentAccount = null;
            SavingsAccount savingsAccount = null;

            var menuHandler = new MenuHandler();

            while (true)
            {
                if (currentAccount == null) 
                {
                    menuHandler.DisplayMainMenu_NoCurrentAccount();//display menu for current account creation
                    int choice = SafeInput.ReadInt();

                    switch (choice)
                    {
                        case 1:
                            string name = SafeInput.ReadText("Enter your name: ");
                            currentAccount = new CurrentAccount(currentUserId, name); //create new Current Account object with userId and name
                            userAccounts[currentAccount.AccountNumber] = currentAccount;//strore user accountNumber as key and currentAccount object as a value is adictioanary
                            Console.WriteLine($"Current Account created successfully! Account Number: {currentAccount.AccountNumber}");
                            break;
                        case 2:
                            menuHandler.ExitApplication();//exit the menu
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else if (savingsAccount == null)//when user has current account but doesnt has savings account yet
                {
                    menuHandler.DisplayMainMenu_NoSavingsAccount();//display menu for savings account creation
                    int choice = SafeInput.ReadInt();

                    switch (choice)
                    {
                        case 1:
                            menuHandler.HandleAccountMenu(currentAccount, userAccounts);
                            break;
                        case 2:
                            string name = SafeInput.ReadText("Enter your name for Savings Account: ");
                            savingsAccount = new SavingsAccount(currentUserId, name);// create new savings account object with userId and name
                            userAccounts[savingsAccount.AccountNumber] = savingsAccount;//store user accountNumber as key and savingsAccount obejct as value
                            Console.WriteLine($"Savings Account created successfully! Account Number: {savingsAccount.AccountNumber}");
                            break;
                        case 3:
                            menuHandler.ExitApplication();
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    menuHandler.DisplayMainMenu_AllAccounts();//display this menu if user has created both current account and savings account
                    int choice = SafeInput.ReadInt();

                    switch (choice)
                    {
                        case 1:
                            menuHandler.HandleAccountMenu(currentAccount, userAccounts);
                            break;
                        case 2:
                            menuHandler.HandleAccountMenu(savingsAccount, userAccounts);
                            break;
                        case 3:
                            menuHandler.ExitApplication();
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}