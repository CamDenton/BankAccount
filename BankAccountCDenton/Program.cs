using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankAccountCDenton
{
    class Program
    {
        // Static fields that handle instances of objects
        static string userName = string.Empty;
        static string userSocial = string.Empty;
        static CheckingAccount userChecking = new CheckingAccount();
        static SavingsAccount userSavings = new SavingsAccount();
        static ReserveAccount userReserve = new ReserveAccount();
        static List<string> transactionList = new List<string>();
        static string transaction = string.Empty;


        static void Main(string[] args)
        {
            
                // Gathers the user's name and applies it to each instance of account
                Console.WriteLine("Welcome to CamCash Banking!");
                Console.WriteLine("Please enter your first name and your last name to get started!");
                userName = Console.ReadLine();
                userChecking.UserName = userName;
                userSavings.UserName = userName;
                userReserve.UserName = userName;

                // Gathers the users social and applies it to each instance of account
                Console.WriteLine("Thank you! Please enter your social security number! No hyphens required.");
                userSocial = Console.ReadLine();
                userChecking.UserSocial = userSocial;
                userSavings.UserSocial = userSocial;
                userReserve.UserSocial = userSocial;

                Console.WriteLine("Thank you! You're all set to use CamCash Banking!");

                // Calls the Menu Method 
                Menu();

        }

        // Handles all the main menu options
        static void Menu()
        {
            // clears out the console
            Console.Clear();

            // User chooses which account to access based on their number input
            int menuChoice = 0;
            Console.WriteLine("Which account would you like to access?");
            Console.WriteLine("1: Checking");
            Console.WriteLine("2: Savings");
            Console.WriteLine("3: Reserves");
            Console.WriteLine("4: Exit");
            menuChoice = int.Parse(Console.ReadLine());

            // a switch for the menu options
            // each option calls a respective method 
            switch (menuChoice)
            {
                case 1:
                    CheckingOptions();
                    break;

                case 2:
                    SavingsOptions();
                    break;

                case 3:
                    ReserveOptions();
                    break;


                case 4:
                    Console.WriteLine("Thank you again for using CamCash! Good-Bye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please select one of the options present.");
                    Menu();
                    break;
            }
        }

        // Checking Account Method and options
        static void CheckingOptions()
        {
            Console.Clear();
            int userChoice = 0;

            // Allows the user to choose what they wish to do with the account
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Deposit");
            Console.WriteLine("2: Withdraw");
            Console.WriteLine("3: Show Balance");
            Console.WriteLine("4: Show Recent Transactions");
            Console.WriteLine("5: Exit");
            userChoice = int.Parse(Console.ReadLine());

            // Initiates the seclected options 
            switch(userChoice)
            {
                // Allows the user to deposit and inputed amount, and applies it to the transaction list and variable
                case 1:
                    Console.WriteLine("How much are you depositing?");
                    userChecking.AdjustmentAmount = double.Parse(Console.ReadLine());
                    userChecking.Deposit();
                    transaction = ("+ " + userChecking.AdjustmentAmount + " " + userChecking.AccountBalance + " " + DateTime.Now);
                    userChecking.InterestGain();
                    transactionList.Add(transaction);
                    break;

                 // Allows the user to withdraw from the account only if there are sufficient funds
                 // If not, then the money is pulled from savings so long as it is available
                 // If not in savings, then the account is overdrafted
                case 2:
                    Console.WriteLine("How much will you withdraw?");
                    userChecking.AdjustmentAmount = double.Parse(Console.ReadLine());
                    if(userChecking.AdjustmentAmount > userChecking.AccountBalance)
                    {
                        if (userSavings.AccountBalance > userChecking.AdjustmentAmount && userSavings.CurrentTransfers < userSavings.MaxTransfers) 
                        {
                            userChecking.TransferFunds();
                            userChecking.Withdraw();
                            transaction = ("- " + userChecking.AdjustmentAmount + " " + userChecking.AccountBalance + " " + DateTime.Now);
                            transactionList.Add(transaction);
                            

                        }

                        else
                        {
                            userChecking.Withdraw();
                            userChecking.Overdraft();
                            transaction = ("- " + userChecking.AdjustmentAmount + " " + userChecking.AccountBalance + " " + DateTime.Now);
                            transactionList.Add(transaction);
                        }
                    }
                    break;

                    // Prints account info to the screen
                case 3:
                    userChecking.ViewInfo();
                    Console.ReadKey();
                    break;

                    // Creates a file with account information and recent transactions 
                case 4:
                    using (StreamWriter CheckingTransactions = new StreamWriter("CheckingTransactions.txt"))
                    {
                        CheckingTransactions.WriteLine(userChecking.UserName);
                        CheckingTransactions.WriteLine(userChecking.UserSocial);
                        CheckingTransactions.WriteLine(userChecking.AccountNumber);

                        foreach(string transactions in transactionList)
                        {
                            CheckingTransactions.WriteLine(transactions);
                        }
                        break;
                    }

                    // CLoses the application
                case 5:
                    Console.WriteLine("Thank you again for using CamCash! Good-Bye!");
                    Environment.Exit(0);
                    break;
            }

            // Allows the user to choose if they want a receipt
            Console.Clear();
            Console.WriteLine("Would you like a receipt?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");

            userChoice = int.Parse(Console.ReadLine());

            // Runs the options 
            switch(userChoice)
            {
                case 1:
                    // Creates a file with transaction information on it as a receipt
                    using (StreamWriter receipt = new StreamWriter("ReceiptChecking.txt"))
                    {
                        receipt.WriteLine(userChecking.UserName);
                        receipt.WriteLine(userChecking.UserSocial);
                        receipt.WriteLine(userChecking.AccountNumber);
                        receipt.WriteLine(transaction);
  
                    }
                    Menu();
                    break;

                    // Returns to the Main Menu
                case 2:
                    Menu();
                    break;
            }


        }

        // Savings Method and options 
        static void SavingsOptions()
        {
             Console.Clear();
            int userChoice = 0;


            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Deposit");
            Console.WriteLine("2: Withdraw");
            Console.WriteLine("3: Show Balance");
            Console.WriteLine("4: Show Recent Transactions");
            Console.WriteLine("5: Exit");
            userChoice = int.Parse(Console.ReadLine());

            // Options for the Savings Account 
            switch(userChoice)
            {
                case 1:
                    Console.WriteLine("How much are you depositing?");
                    userSavings.AdjustmentAmount = double.Parse(Console.ReadLine());
                    userSavings.Deposit();
                    transaction = ("+ " + userSavings.AdjustmentAmount + " " + userSavings.AccountBalance + " " + DateTime.Now);
                    userSavings.InterestGain();
                    transactionList.Add(transaction);
                    break;

                case 2:
                    Console.WriteLine("How much will you withdraw?");
                    userChecking.AdjustmentAmount = double.Parse(Console.ReadLine());
                    if(userChecking.AdjustmentAmount > userChecking.AccountBalance)
                    {
                        if (userChecking.AccountBalance > userSavings.AdjustmentAmount) 
                        {
                            userChecking.TransferFunds();
                            userChecking.Withdraw();
                            transaction = ("- " + userChecking.AdjustmentAmount + " " + userChecking.AccountBalance + " " + DateTime.Now);
                            transactionList.Add(transaction);
                            

                        }

                        else
                        {
                            userSavings.InsufficientFunds();
                        }
                    }
                    break;

                case 3:
                    userSavings.ViewInfo();
                    Console.ReadKey();
                    break;

                case 4:
                    using (StreamWriter SavingsTransactions = new StreamWriter("CheckingTransactions.txt"))
                    {
                        SavingsTransactions.WriteLine(userSavings.UserName);
                        SavingsTransactions.WriteLine(userSavings.UserSocial);
                        SavingsTransactions.WriteLine(userSavings.AccountNumber);

                        foreach (string transactions in transactionList)
                        {
                            SavingsTransactions.WriteLine(transactions);
                        }

                        break;
                    }

                case 5:
                    Console.WriteLine("Thank you again for using CamCash! Good-Bye!");
                    Environment.Exit(0);
                    break;
            }

            Console.Clear();
            Console.WriteLine("Would you like a receipt?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");

            userChoice = int.Parse(Console.ReadLine());

            // Allows the user to print a receipt for the savings transaction
            switch(userChoice)
            {
                case 1:
                    using (StreamWriter receipt = new StreamWriter("ReceiptSavings.txt", true))
                    {
                        receipt.WriteLine(userSavings.UserName);
                        receipt.WriteLine(userSavings.UserSocial);
                        receipt.WriteLine(userSavings.AccountNumber);
                        receipt.WriteLine(transaction);
   
                    }
                    Menu();
                    break;

                case 2:
                    Menu();
                    break;
            }
        }

        static void ReserveOptions()
        {
            Console.Clear();
            int userChoice = 0;

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Deposit");
            Console.WriteLine("2: Withdraw");
            Console.WriteLine("3: Show Balance");
            Console.WriteLine("4: Show Recent Transactions");
            Console.WriteLine("5: Exit");
            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("How much are you depositing?");
                    userReserve.AdjustmentAmount = double.Parse(Console.ReadLine());
                    userReserve.Deposit();
                    transaction = ("+ " + userReserve.AdjustmentAmount + " " + userReserve.AccountBalance + " " + DateTime.Now);
                    userReserve.InterestGain();
                    transactionList.Add(transaction);
                    break;

                case 2:
                    Console.WriteLine("How much will you withdraw?");
                    userReserve.AdjustmentAmount = double.Parse(Console.ReadLine());
                    if (userReserve.AdjustmentAmount > userReserve.AccountBalance)
                    {
                        userReserve.InsufficientFunds();
                    }

                    else
                    {
                        userReserve.Withdraw();
                        transaction = ("- " + userReserve.AdjustmentAmount + " " + userReserve.AccountBalance + " " + DateTime.Now);
                        transactionList.Add(transaction);
                    }
                    break;

                case 3:
                    userReserve.ViewInfo();
                    Console.ReadKey();
                    break;

                case 4:
                    using (StreamWriter ReserveTransactions = new StreamWriter("CheckingTransactions.txt"))
                    {
                        ReserveTransactions.WriteLine(userReserve.UserName);
                        ReserveTransactions.WriteLine(userReserve.UserSocial);
                        ReserveTransactions.WriteLine(userReserve.AccountNumber);

                        foreach (string transactions in transactionList)
                        {
                            ReserveTransactions.WriteLine(transactions);
                        }
                        break;
                    }

                case 5:
                    Console.WriteLine("Thank you again for using CamCash! Good-Bye!");
                    Environment.Exit(0);
                    break;
            }

            Console.Clear();
            Console.WriteLine("Would you like a receipt?");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");

            userChoice = int.Parse(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    using (StreamWriter receipt = new StreamWriter("ReceiptReserve.txt", true))
                    {
                        receipt.WriteLine(userReserve.UserName);
                        receipt.WriteLine(userReserve.UserSocial);
                        receipt.WriteLine(userReserve.AccountNumber);
                        receipt.WriteLine(transaction);

                    }
                    Menu();
                    break;

                case 2:
                    Menu();
                    break;
            }
        }

        

       
    }
}
