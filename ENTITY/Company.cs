using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Company
    {
        string name;
        decimal balance;
        //private decimal debitAmount;
        //private decimal creditAmount;

        public decimal Balance
        {
            get
            {
                return balance;
            }

            set
            {
                balance = value;
            }
        }

        public Company(string _name, decimal _balance)
        {
            name = _name;
            Balance = _balance;
        }
        public decimal deposite(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            return amount;
        }
        public decimal withdraw(decimal amount)
        {
            if (amount > 0)
            {
                Balance -= amount;
            }
            return amount;
        }
        public void open()
        {
            
        }
    }
}
