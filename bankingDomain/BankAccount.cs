using System;

namespace bankingDomain
{
    public class BankAccount
    {

        private decimal _currentBalance = 5000;

        public BankAccount()
        {

        }

        public decimal getBalance()
        {
            return _currentBalance;
        }

        public void Deposit(decimal amountToDeposit)
        {
            this._currentBalance += amountToDeposit;
        }

        public void Withdraw(decimal withdrawalAmount)
        {
            if(withdrawalAmount <= _currentBalance)
            {
                this._currentBalance -= withdrawalAmount;
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
                
    }
}