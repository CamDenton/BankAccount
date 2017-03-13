using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCDenton
{
    public class ReserveAccount : AccountInfo
    {
        private double interestAmount = 0.30;
        private double marketOffset; 

        public ReserveAccount() : base (string.Empty, string.Empty, 0.00, 0.00, 01293847)
        {

        }

        public double InterestAmount
        {
            get { return interestAmount; }
        }

        public double MarketOffset
        {
            get { return marketOffset; }

            set { marketOffset = value; }
        }

        public double MarketChange
        {
            get { return interestAmount * marketOffset; }

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


        public void InterestGain()
        {
            AccountBalance = AccountBalance + (AccountBalance * InterestAmount);
        }

        public void InsufficientFunds()
        {
            Console.WriteLine("Insuffienct funds in the account.");
        }


    }
}
