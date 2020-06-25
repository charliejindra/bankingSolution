using bankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class bankAcctBonusCalculation
    {
        [Fact]
        public void BonusCalculatorIsUsedProperly()
        {
            var account = new BankAccount(new StubbedBonusCalculator(), new Mock<INarcOnAccounts>().Object);
            var fakeBonusCalculator = new Mock<ICalculateBonuses>();

            //if it doesnt have these parameters, it returns the default value of the return type
            fakeBonusCalculator.Setup(m => m.GetDepositBonusFor(100, account.getBalance())).Returns(42);


           

            account.Deposit(100);

            Assert.Equal(5142, account.getBalance());
        }
    }

    public class StubbedBonusCalculator : ICalculateBonuses
    {
        
        public decimal GetDepositBonusFor(decimal amountToDeposit, decimal currentBalance)
        {
            if (amountToDeposit == 100 && currentBalance == 5000)
            {
                return 42;
            }
            else
            {
                return 0;
            }
        }
    }
}
