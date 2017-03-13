using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCDenton
{
    public class CheckingAccount : AccountInfo
    {
        // Fields specific for checking account
        private double interestAmount = 0.05;
        private double overDraftFee = 10.00;

        // constructor for the checking account that inherits from AccountInfo
        public CheckingAccount() : base (string.Empty, string.Empty, 0.00, 0.00, 01293847)
        {
            
        }

        // Property for the Interest Amount 
        public double InterestAmount
        {
            get { return interestAmount; }
        }

        // Property for the Overdraft Fee 
        public double OverDraftFee
        {
            get { return overDraftFee;  }

        }

        // Method that prints the users info to the screen 
        public override void ViewInfo()
        {
            UserSocial.ToCharArray();


            Console.WriteLine(UserName);
            Console.WriteLine("xxx-xx- " + UserSocial[5] + UserSocial[6] + UserSocial[7] + UserSocial[8]);
            Console.WriteLine(AccountBalance);
        }

        // Method that allos funds to be deposited to the account
        public override void Deposit()
        {
            AccountBalance = AccountBalance + AdjustmentAmount;
        }

        // Method that allows funds to be withdrawn from the account
        public override void Withdraw()
        {
            AccountBalance = AccountBalance - AdjustmentAmount;
        }

        // Method tohandle if the account is overdrawn 
        public void Overdraft()
        {
            AccountBalance = AccountBalance - OverDraftFee;
        }

        // Method to add interest to the account 
        public void InterestGain()
        {
            AccountBalance = AccountBalance + (AccountBalance * InterestAmount);
        }

        // Method to send funds from checking to savings 
        public void TransferFunds()
        {
            SavingsAccount savings = new SavingsAccount();
            savings.AccountBalance = savings.AccountBalance + AdjustmentAmount;
            AccountBalance = accountBalance - AdjustmentAmount;
        }

        // Method that handles if the account has insufficient funds 
        public void InsufficientFunds()
        {
            Console.WriteLine("Insuffienct funds in the account.");
        }


    }
}
