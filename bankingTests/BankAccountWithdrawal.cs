using bankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class BankAccountWithdrawal
    {
        [Fact]
        public void WithdrawingMoneyDecreasesTheBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.getBalance();
            var withdrawalAmount = 300M;

            account.Withdraw(withdrawalAmount);

            var expectedBalance = openingBalance - withdrawalAmount;
            Assert.Equal(expectedBalance, account.getBalance());
        }

        [Fact]
        public void youCanTakeAllYourMoney()
        {
            var account = new BankAccount();
            var openingBalance = account.getBalance();

            account.Withdraw(openingBalance);

            Assert.Equal(0, account.getBalance());
        }
    }
}
