using System;

namespace classes
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Felix Wang", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);

            account.MakeDeposit(100, DateTime.Now, "Salary");
            Console.WriteLine(account.Balance);

            try
            {
                var invalidAccount = new BankAccount("Mr. INVALID", -100);
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.Beep();
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            try
            {
                account.MakeWithdrawal(1000, DateTime.Now, "Invalid Withdraw");
            }
            catch(InvalidOperationException e)
            {
                Console.Beep();
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
