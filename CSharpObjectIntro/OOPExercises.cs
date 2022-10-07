using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpObjectIntro.Classes.Diary;
using CSharpObjectIntro.Classes.BankAccount;
using System.Diagnostics;

namespace CSharpObjectIntro
{
    internal class OOPExercises
    {
        internal static void Run()
        {
            UseDiary();
        }

        internal static void UseDiary()
        {
            //Diary Diary = new Diary("Bob Smith");
            //Diary.AddEvent(DateOnly.FromDateTime(DateTime.Today), 18, "I had fried chicken for dinner", "Canteen", 20);
            //Diary.AddEvent(DateOnly.FromDateTime(DateTime.Today), 7, "I brushed my teeth", "Wash Room", 5);
            //Diary.AddEvent(DateOnly.FromDateTime(DateTime.Today), 11, "I had pasta for lunch", "Canteen", 15);
            //Console.WriteLine(Diary.CheckDiary(DateOnly.FromDateTime(DateTime.Today)));
            //Console.WriteLine(Diary.CheckDiaryForMorningEvents(DateOnly.FromDateTime(DateTime.Today)));

            
            
            BankAccount MyBankAccount = new BankAccount(DateOnly.FromDateTime(DateTime.Today));
            MyBankAccount.SetLimit(1000);
      
            MyBankAccount.deposit(new DateOnly(2015,12,25), 1000, "Friends & Family", "Simon Wang", "Transfer", "Christmas Gift");
            MyBankAccount.withdraw(new DateOnly(2015, 12, 27), 350, "Gaming", "Nintendo", "Payment", "Nintendo Switch");
            Debug.Assert(MyBankAccount.Balance == 650);
            MyBankAccount.withdraw(new DateOnly(2016, 1, 1), 200, "Service", "Fancy Restaurant", "Payment", "Food");
            MyBankAccount.withdraw(new DateOnly(2016, 1, 19), 100, "Gaming", "Nintendo", "Payment", "£100 Gift Card");

            Console.WriteLine(MyBankAccount.CheckPreviousBalance(new DateOnly(2015, 12, 29)));
            Console.WriteLine(MyBankAccount.CheckCategories("Gaming"));
            Console.WriteLine(MyBankAccount.CheckMoneySpentInAGivenPeriod(new DateOnly(2016, 1, 1), new DateOnly(2016, 1, 19)));

            // Create a new diary 
            // Diary diary = new Diary("Bob Smith"); 

            // Add some events to your diary

            // Now check how many events you have on a particular day

            // Implement a new method in the Diary class to return the number of morning events on a particular day
            // Call this method
        }

        internal static void UseBankAccount()
        {
            // Implement your bank account class following the instructions in the BankAccount class

            // Write calling code from here
        }
    }
}

