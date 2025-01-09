using System;
using System.Collections.Generic;

namespace FinanceManagementC_
{
    abstract class Account
    {
        public string AccountNumber { get; private set; }
        public string Name { get; private set; }
        public decimal Balance { get; protected set; }
        public List<Transaction> Transactions { get; private set; }

        public Account(string userId, string name)
        {
            AccountNumber = GenerateAccountNumber();
            Name = name;
            Balance = 0;
            Transactions = new List<Transaction>();
        }

        public virtual void Deposit()
        {
            decimal amount = SafeInput.ReadDecimal("Enter amount to deposit: ");
            Balance += amount;
            AddTransaction($"Deposit of {amount:C}", amount);
            Console.WriteLine($"Deposited {amount:C}. New balance: {Balance:C}");
        }

        public virtual void Withdraw()
        {
            decimal amount = SafeInput.ReadDecimal("Enter amount to withdraw: ");
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                Balance -= amount;
                AddTransaction($"Withdrawal of {amount:C}", -amount);
                Console.WriteLine($"Withdrew {amount:C}. New balance: {Balance:C}");
            }
        }

        public void Transfer(Dictionary<string, Account> userAccounts)
        {
            string targetAccountNumber = SafeInput.ReadAccountNumber("Enter target account number: ");
            if (!userAccounts.ContainsKey(targetAccountNumber))
            {
                Console.WriteLine("Target account not found.");
                return;
            }

            decimal amount = SafeInput.ReadDecimal("Enter amount to transfer: ");
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds.");
            }
            else
            {
                Balance -= amount;
                var targetAccount = userAccounts[targetAccountNumber];
                targetAccount.Balance += amount;

                AddTransaction($"Transfer out to {targetAccountNumber} ({targetAccount.Name})", -amount);
                targetAccount.AddTransaction($"Transfer in from {AccountNumber} ({Name})", amount);

                Console.WriteLine($"Transferred {amount:C} to account {targetAccountNumber}.");
            }
        }

        public void ViewDetails()
        {
            Console.WriteLine($"\nAccount Number: {AccountNumber}");
            Console.WriteLine($"Account Holder: {Name}");
            Console.WriteLine($"Balance: {Balance:C}");
        }

        public void ViewTransactionHistory()
        {
            Console.WriteLine("\n--- Transaction History ---");
            if (Transactions.Count == 0)
            {
                Console.WriteLine("No transactions available.");
            }
            else
            {
                foreach (var transaction in Transactions)
                {
                    Console.WriteLine(transaction);
                }
            }
        }

        private string GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }

        private void AddTransaction(string description, decimal amount)
        {
            Transactions.Add(new Transaction(description, amount));
        }
    }
}
