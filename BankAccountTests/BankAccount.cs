using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSUnitTestDemo
{
    public class BankAccount
    {
        //fields
        string customer_name;
        double balance;
        public BankAccount(string name,double bal)
        {
            customer_name=name;
            balance=bal;
        }
        //property
        public double Balance 
        { 
            get { return balance; }
        }
        public void Debit(double amount)
        {
            if (balance.Equals(0))
            {
                throw new Exception("balance = 0");
            }
            if (amount <= 0 || amount > balance)
            {
                throw new ArgumentOutOfRangeException("amount <= 0 or amount > balance");
            }
            balance -= amount;


        }
        public void Credit(double amount)
        {
            if (amount <= 0 )
            {
                throw new ArgumentOutOfRangeException("amount<=0");
            }

            balance += amount;
        }



    }
}
