using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManagementC_
{
    class SavingsAccount : Account
    {

        private const decimal InterestRate = 0.03m;

        public SavingsAccount(string userId, string name) : base(userId, name) { }

        public override void Deposit()
        {
            base.Deposit();
            decimal interest = Balance * InterestRate;
            Balance += interest;
            Transactions.Add(new Transaction("Interest Applied", interest));
            Console.WriteLine($"Interest of {interest:C} applied. New balance: {Balance:C}");
        }
    }
}
