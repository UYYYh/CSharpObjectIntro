using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CSharpObjectIntro.Classes.BankAccount
{
    public class AccountTransaction
    {
        public DateOnly Date { get; private set; }
        public decimal Amount { get; private set; }
        public string Category { get; private set; }
        public string Counterparty { get; private set; }
        public string TransactionType { get; private set; }
        public string Description { get; private set; }
        public AccountTransaction(DateOnly date, decimal amount, string category, string counterparty, string transactionType, string description = "N/A")
        {
            Date = date;
            Amount = amount;
            Category = category;
            Counterparty = counterparty;
            TransactionType = transactionType;
            Description = description;
        }
    }
    public class BankAccount
    {
        // As you complete each task make sure you test your code carefully
        // Choose some combination of manual testing, Debug.Assert and unit tests

        // Task One        
        // The bank account should have a balance property        
        // It should have a constructor that sets the initial balance (default zero) and the opening date (default today)
        // It should have methods to deposit and withdraw/make payments from the account. 
        
        public decimal Balance { get; private set; }
        public DateOnly OpeningDate { get; private set; }
        public decimal Limit { get; private set; }
        public List<AccountTransaction> Transactions { get; private set; }
        public BankAccount(DateOnly openingDate,int balance = 0)
        {
            Balance = balance;
            OpeningDate = openingDate;
            Limit = -1;
            Transactions = new List<AccountTransaction>();
        }
        
        public void SetLimit(int amount)
        {
            Limit = amount;
            //Console.WriteLine($"Overdraft limit set to: {Limit}");
        }

        public void withdraw(DateOnly date, decimal amount, string category, string counterparty, string transactionType, string description = "N/A")
        {   
            if (Limit == -1 || amount <= Limit)
            {
                Balance = Balance - amount;
                AccountTransaction Transaction = new AccountTransaction(date,-amount,category,counterparty,transactionType,description);
                Transactions.Add(Transaction);
                Console.WriteLine($"Your Current Balance is {Balance}");
            }
            else
            {
                Console.WriteLine("Transfer Denied: Overdraft Limit Exceeded");
            }
        }

        public void deposit(DateOnly date, decimal amount, string category, string counterparty, string transactionType, string description = "N/A")
        {
            Balance = Balance+amount;
            AccountTransaction Transaction = new AccountTransaction(date,amount,category,counterparty,transactionType,description);
            Transactions.Add(Transaction);
            Console.WriteLine($"Your Current Balance iss {Balance}");
        }

        public string CheckPreviousBalance(DateOnly date)
        {
            decimal Temp_Balance = Balance;
            foreach (AccountTransaction transaction in Transactions)
            {   
                if (transaction.Date > date) 
                {
                    Temp_Balance = Temp_Balance - transaction.Amount;
                }
            }
            return $"Your balance on {date} is: {Temp_Balance}";
        }

        public string CheckCategories(string Category)
        {
            decimal counter = 0;
            foreach (AccountTransaction transaction in Transactions)
            {
                if (transaction.Category == Category)
                {
                    counter = counter - transaction.Amount;
                }
            }
            return $"The total amount of money you've spent on {Category} is: {counter}";
        }

        public string CheckMoneySpentInAGivenPeriod(DateOnly StartingDate, DateOnly EndingDate)
        {
            decimal counter = 0;
            foreach (AccountTransaction transaction in Transactions)
            {   
                if (StartingDate<=transaction.Date && transaction.Date <= EndingDate && transaction.Amount<0)
                {
                    counter = counter - transaction.Amount;
                }
            }
            return $"The total amount of money you've spent from {StartingDate} to {EndingDate} is: {counter}";
        }


        // Task Two
        // Give the option to set an overdraft limit
        // Do not allow a withdrawal/payment if the overdraft limit is exceeded. You could return false or throw an exception.

        // Task Three
        // Create a new class called AccountTransaction.
        // It could contain properties such as
        // date, amount, category, counterparty, transactionType, description (optional)
        // e.g 26/09/2022 16:45, -300, Groceries, Waitrose, Card, Weekly shop
        //     27/09/2022 17:40, 200, Gift, Bob Smith, Cheque, Birthday present
        // You might wish to use enums for category and transactionType
        // Amend your bank account to contain a list of transactions
        // The methods for  deposit and withdraw/make payments should be amended to add transactions

        // Task Four
        // Now add some new methods to your account
        // - See what the balance was at a previous date
        // - See how much money was spent in a given time period
        // - See how much money was spent in different categories

        // Extension
        // Work out how much interest is payable on your account
        // For the moment make up the interest rates, though later we could look at loading them from a website
        // The interest should be added as transactions to your account





    }
}
