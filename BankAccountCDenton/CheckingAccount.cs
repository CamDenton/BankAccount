using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCDenton
{
    public class CheckingAccount : AccountInfo
    {
        private double interestAmount = 0.05;
        private double overDraftFee = 10.00;

        public CheckingAccount() : base (string.Empty, string.Empty, 0.00, 0.00, 01293847)
        {
            
        }

        public double InterestAmount
        {
            get { return interestAmount; }
        }

        public double OverDraftFee
        {
            get { return overDraftFee;  }

        }

        public override void ViewInfo()
        {
            UserSocial.ToCharArray();


            Console.WriteLine(UserName);
            Console.WriteLine("xxx-xx- " + UserSocial[5] + UserSocial[6] + UserSocial[7] + UserSocial[8]);
            Console.WriteLine(AccountBalance);
        }

        public override void Deposit()
        {
            AccountBalance = AccountBalance + AdjustmentAmount;
        }

        public override void Withdraw()
        {
            AccountBalance = AccountBalance - AdjustmentAmount;
        }

        public void Overdraft()
        {
            AccountBalance = AccountBalance - OverDraftFee;
        }

        public void InterestGain()
        {
            AccountBalance = AccountBalance + (AccountBalance * InterestAmount);
        }

        public void TransferFunds()
        {
            SavingsAccount savings = new SavingsAccount();
            savings.AccountBalance = savings.AccountBalance + AdjustmentAmount;
            AccountBalance = accountBalance - AdjustmentAmount;
        }

        public void InsufficientFunds()
        {
            Console.WriteLine("Insuffienct funds in the account.");
        }


    }
}
