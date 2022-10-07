using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpObjectIntro.Classes.Diary;
using CSharpObjectIntro.Classes.BankAccount;

namespace CSharpObjectIntro.Tests
{
    [TestClass]
    public class DiaryTests
    {
        [TestMethod]
        public void TestDiaryName()
        {
            var diary = new Diary("Bob Smith");
            Assert.AreEqual("Bob Smith", diary.Name);
        }
    }

    [TestClass]

    public class BankAccountTests
    {
        [TestMethod]
        public void TestBankAccountConstruction()
        {   
            var TestAccount = new BankAccount(new System.DateOnly(2022, 1, 2), 2300);
            Assert.AreEqual(TestAccount.Balance, 2300);
            Assert.AreEqual(TestAccount.OpeningDate, new System.DateOnly(2022, 1, 2));
        }

        
    }
}