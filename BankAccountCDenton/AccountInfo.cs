using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCDenton
{
    public abstract class AccountInfo
    {
        protected string userName;
        protected string userSocial;
        protected double accountBalance;
        protected double adjustmentAmount;
        protected int userAccountNumber;
        
        
        public AccountInfo()
        {

        } 
        
        public AccountInfo(string userName, string userSocial, double accountBalance, double adjustmentAmount, int userAccountNumber)
        {
            this.userName = userName;
            this.userSocial = userSocial;
            this.accountBalance = accountBalance;
            this.adjustmentAmount = adjustmentAmount;
            this.userAccountNumber = userAccountNumber;
            
        }

       

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string UserSocial
        {
            get { return userSocial; }
            set { userSocial = value; }
        }

        public double AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
            
        }

        public double AdjustmentAmount
        {
            get { return adjustmentAmount; }
            set { adjustmentAmount = value; }
        }

        public int AccountNumber
        {
            get { return userAccountNumber; }
        }



        public abstract void Deposit();


        public abstract void Withdraw();

        public abstract void ViewInfo();


    }
}
