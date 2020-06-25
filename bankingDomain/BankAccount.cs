using System;

namespace bankingDomain
{
    public class BankAccount
    {

        private ICalculateBonuses _bonusCalculator;
        private decimal _currentBalance = 5000;
        private INarcOnAccounts _feds;

        public BankAccount(ICalculateBonuses bonusCalculator, INarcOnAccounts feds)
        {
            _bonusCalculator = bonusCalculator;
            _feds = feds;
        }

        public decimal getBalance()
        {
            return _currentBalance;
        }

        public virtual void Deposit(decimal amountToDeposit)
        {
            decimal amtOfBonus = _bonusCalculator.GetDepositBonusFor(amountToDeposit, _currentBalance);

            this._currentBalance += amountToDeposit + amtOfBonus;
        }

        public void Withdraw(decimal withdrawalAmount)
        {
            if(withdrawalAmount <= _currentBalance)
            {
                _feds.NotifyOfWithdrawal(this, withdrawalAmount);
                _currentBalance -= withdrawalAmount;
            }
            else
            {
                throw new InsufficientFundsException();
            }
        }
                
    }
}