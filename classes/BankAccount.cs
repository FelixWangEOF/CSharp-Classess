using System;
using System.Collections.Generic;
using System.Text;

namespace classes
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;

        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;

            // this.Balance = initialBalance;
            //var initialTransaction = new Transaction(initialBalance, DateTime.Now , "Initial Transaction");
            //allTransactions.Add(initialTransaction);

            MakeDeposit(initialBalance, DateTime.Now, "Initial balance for " + name);

            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit mush be positive.");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal mush be positive.");
            }
            if(this.Balance - amount < 0)
            {
                throw new InvalidOperationException("Now sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\tTransaction\tBalance\tNote");
            foreach(var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        private List<Transaction> allTransactions = new List<Transaction>();

    }
}
