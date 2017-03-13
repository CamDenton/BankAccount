using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCDenton
{
    class SavingsAccount : AccountInfo
    {
        private double interestAmount = 0.08;
        private int currentTransfers = 0;
        private int maxTransfers = 5; 

        public SavingsAccount() : base (string.Empty, string.Empty, 0.00, 0.00, 01293847)
        {
            
        }

        public double InterestAmount
        {
            get { return interestAmount; }
            
        }

        public int CurrentTransfers
        {
            get { return currentTransfers; }
            set { currentTransfers = value; }
        }

        public int MaxTransfers
        {
            get { return maxTransfers; }
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

        public void TransferFunds()
        {
            CheckingAccount checking = new CheckingAccount();
            checking.AccountBalance = checking.AccountBalance + AdjustmentAmount;
            AccountBalance = accountBalance - AdjustmentAmount;
        }

        public void InsufficientFunds()
        {
            Console.WriteLine("Insuffienct funds in the account.");
        }

        public void InterestGain()
        {
            AccountBalance = AccountBalance + (AccountBalance * InterestAmount);
        }

        

    }
}
