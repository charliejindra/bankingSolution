using bankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class BankAccountWithdrawal
    {

        private BankAccount _account;
        private decimal _openingBalance;

        public BankAccountWithdrawal()
        {
            _account = new BankAccount(new dummyBonusCalculator(), new Mock<INarcOnAccounts>().Object);
            _openingBalance = _account.getBalance();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        public void WithdrawingMoneyDecreasesTheBalance(decimal withdrawalAmount)
        {
            

            _account.Withdraw(withdrawalAmount);

            var expectedBalance = _openingBalance - withdrawalAmount;
            Assert.Equal(expectedBalance, _account.getBalance());
        }

        [Fact]
        public void youCanTakeAllYourMoney()
        {
            var account = new BankAccount(new dummyBonusCalculator(), new Mock<INarcOnAccounts>().Object);
            var openingBalance = account.getBalance();

            account.Withdraw(openingBalance);

            Assert.Equal(0, account.getBalance());
        }
    }
}
