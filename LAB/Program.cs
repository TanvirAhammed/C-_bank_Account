using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accountList = new List<Account>();
            while(true)
            {
                string menu_1 = "1. Open Account\n2. Account Details\n3. Quit\n";
                Console.WriteLine(menu_1);
                string option_urs = Console.ReadLine();
                if(option_urs == "1")
                {
                    string acty;
                    Console.WriteLine("\n\nChoose account type:\n1. Savings\n2. Checking\n3. Quit");
                    acty = Console.ReadLine();
                    if(acty == "1")
                    {
                        accountList.Add(savingsAccountCreate());
                    }
                    else if(acty == "2")
                    {
                        accountList.Add(checkingAccountCreate());
                    }
                    else
                    {
                        Console.WriteLine("Exit successfully.\n\n");
                        break;
                    }
                }

                else if(option_urs == "2")
                {
                    string currentUser;
                    Console.Write("Enter your account number: ");
                    currentUser = Console.ReadLine();
                    foreach(var acc in accountList)
                    {
                        if(acc.AccountNo == currentUser)
                        {
                            string accAction;
                            Console.WriteLine("\n\nChoose an option:\n1. Deposit\n2. Withdraw\n3. Transfer\n4. Change\n5. Show\n6. Quit");
                            accAction = Console.ReadLine();
                            if (accAction == "1")
                            {
                                Console.Write("Enter an amount: ");
                                double amount = Convert.ToDouble(Console.ReadLine());
                                acc.deposite(amount);
                            }

                            else if (accAction == "2")
                            {
                                Console.Write("Enter Withdraw Amount:");
                                double amount = Convert.ToDouble(Console.ReadLine());
                                acc.withdraw(amount);
                            }
                            else if(accAction == "3")
                            {
                                string tfAccNo;
                                Console.Write("Enter an destination account number: ");
                                tfAccNo = Console.ReadLine();
                                foreach (var trAcc in accountList)
                                {
                                    if(tfAccNo == trAcc.AccountNo)
                                    {
                                        double trAmount = Convert.ToDouble(Console.ReadLine());
                                        if(acc.Balance >= trAmount)
                                        {
                                            acc.transferBalance(-(trAmount));
                                            trAcc.transferBalance(trAmount);
                                            Console.Write("\nTransfer Successful!\n\n");
                                            break;
                                        }
                                        else
                                        {
                                            Console.Write("Invalid Amount!\n\n");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Transfer failed! Invalid destination.\n\n");
                                    }
                                }
                            }
                            else if (accAction == "4")
                            {
                                Console.Write("Enter New Owner Name:");
                                string ownm = Console.ReadLine();
                                acc.AccountName = ownm;

                            }
                            else if (accAction == "5")
                            {
                                acc.PrintAccountDetails();
                            }
                            else
                            {
                                break;
                            }

                        }
                    }
                    
                }

                else
                {
                    Console.WriteLine("Exit successfully.\n\n");
                    break;
                }
            }
        }

        public static Account savingsAccountCreate()
        {
            Random AccountNum = new Random();

            string accNum, name, dob, addr;
            double stbal;
            accNum = Convert.ToString(AccountNum.Next(1000, 9999)); 
            Console.WriteLine("Your account number is: {0}", accNum);
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter date of birth: ");
            dob = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            addr = Console.ReadLine();
            Console.WriteLine("Enter initial balance: ");
            stbal = Convert.ToDouble(Console.ReadLine());

            return (new Account("Savings", accNum, name, dob, addr, stbal));
        }

        public static Account checkingAccountCreate()
        {
            Random AccountNum = new Random();

            string accNum, name, dob, addr;
            double stbal;
            accNum = Convert.ToString(AccountNum.Next(1000, 9999)); // 1000 - 9999 ___ 1500
            Console.WriteLine("Your account number is: {0}", accNum);
            Console.WriteLine("Enter name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter date of birth: ");
            dob = Console.ReadLine();
            Console.WriteLine("Enter address: ");
            addr = Console.ReadLine();
            Console.WriteLine("Enter initial balance: ");
            stbal = Convert.ToDouble(Console.ReadLine());

            return (new Account("Checking", accNum, name, dob, addr, stbal));
        }
    }
}
