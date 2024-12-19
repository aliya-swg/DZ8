using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task123();
            Task4();

        }
        static void Task123()
        {
            BankAccount myFirstBankAccount = new BankAccount(1000000000, BankAccountType.Savings);
            BankAccount mySecondBankAccount = new BankAccount(100, BankAccountType.Savings);
            myFirstBankAccount.DepositMoney(1);
            mySecondBankAccount.TransferMoneyTo(myFirstBankAccount, 100);
            myFirstBankAccount.Dispose();
        }
        static void Task4()
        {
            Song mySong = new Song();
        }
    }
}
