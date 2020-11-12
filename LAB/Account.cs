using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB
{
    class Account
    {


        private string accountName, accountNo, dateOfBirth, address, typeOfAccount;
        private double balance;
        private int transectionCount = 0;


        public Account(string act, string an, string nm, string db, string adr, double bl)
        {
            this.typeOfAccount = act;
            this.accountNo = an;
            this.accountName = nm;
            this.dateOfBirth = db;
            this.address = adr;
            this.balance = bl;
            Console.WriteLine("\n\n************Account created successfully.************\n\n");
        }
        public string AccountName
        {

            set { this.accountName = value; }

            get { return this.accountName; }
        }

        public void incTransectionCount()
        {
            this.transectionCount += 1;
        }

        public void showTransectionCount()
        {

            Console.WriteLine("\n\nTotal transection for this account: {0}\n\n", this.transectionCount);
        }


        public void transferBalance(double amount)
        {
            balance += amount;
            incTransectionCount();
        }


        public string AccountNo
        {

            set { this.accountNo = value; }

            get { return this.accountNo; }
        }

        public string DateOfBirth

        {
            set { this.dateOfBirth = value; }

            get { return this.dateOfBirth; }

        }

        public string TypeOfAccount
        {

            set { this.typeOfAccount = value; }

            get { return this.typeOfAccount; }
        }



        public string Address
        {

            set { this.address = value; }

            get { return this.address; }
        }
        public double Balance
            {
                set
                {
                    if (value < 0)
                    {
                        throw new Exception();
                    }
                    else { this.balance = value; }
                }
                get { return this.balance; }
            }

        public void withdraw(double value)
        {
            if (value <= balance)
            {
                incTransectionCount();
                balance -= value;
                Console.WriteLine("\n\nWithdraw Successful.\n\n");
            }
            else
            {
                Console.WriteLine("\n\nWithdraw failed.\n\n");
            }
        }

        public void deposite(double value)
        {
            if(value > 0)
            {
                incTransectionCount();
                balance += value;
                Console.WriteLine("\n\nDeposite Successful.\n\n");
            }
            else
            {
                Console.WriteLine("\n\nDeposite Failed.\nPlease Enter a valid amount.\n\n");
            }
        }

       



        public void PrintAccountDetails()
        {
            Console.WriteLine("\n\n=========================================");
            Console.WriteLine("Account Name:{0}\nAccount No:{1}\nBalance:{2}\nDate Of Birth:{3}\nAddress:{4}\nType Of Account :{5}", this.accountName, this.accountNo, this.balance, this.dateOfBirth, this.address, this.typeOfAccount);
            showTransectionCount();
            Console.WriteLine("=========================================\n\n");
        }
    }
}

