using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountCDenton
{
    // Base class for all accounts 
    public abstract class AccountInfo
    {
        // Fields for the base class 
        protected string userName;
        protected string userSocial;
        protected double accountBalance;
        protected double adjustmentAmount;
        protected int userAccountNumber;
        
        // Default constructor 
        public AccountInfo()
        {

        } 
        
        // Constructor that assigns the fields to their paramete counterparts 
        public AccountInfo(string userName, string userSocial, double accountBalance, double adjustmentAmount, int userAccountNumber)
        {
            this.userName = userName;
            this.userSocial = userSocial;
            this.accountBalance = accountBalance;
            this.adjustmentAmount = adjustmentAmount;
            this.userAccountNumber = userAccountNumber;
            
        }

       
        // Users name property 
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        // Users social property 
        public string UserSocial
        {
            get { return userSocial; }
            set { userSocial = value; }
        }

        // Account Balance property 
        public double AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
            
        }

        // Property which is used for either depositing or withdrawing 
        public double AdjustmentAmount
        {
            get { return adjustmentAmount; }
            set { adjustmentAmount = value; }
        }

        // Property of the account number 
        public int AccountNumber
        {
            get { return userAccountNumber; }
        }


        // Abstract method of deposit shared by all accounts 
        public abstract void Deposit();

        // Abstract method of withdraw shared by all accounts 
        public abstract void Withdraw();

        // abstract method of view info shared by all accounts 
        public abstract void ViewInfo();


    }
}
