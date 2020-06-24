using bankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class BankAccountDeposits
    {

        [Fact]
        public void DespositingMoneyIncreasesTheBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.getBalance();
            var amountToDeposit = 777M;

            account.Deposit(amountToDeposit);

            var expectedBalance = openingBalance + amountToDeposit;
            Assert.Equal(expectedBalance, account.getBalance());
        }

    }
}
