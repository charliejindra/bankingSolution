using bankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class bankAcctOverdrafts
    {

        [Fact]
        public void overdraftDoesNotDecreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.getBalance();

            try
            {
                account.Withdraw(openingBalance + 1);
            }
            catch (InsufficientFundsException)
            {

                // swallow the exception
            }

            Assert.Equal(openingBalance, account.getBalance());
        }

        [Fact]
        public void overdraftThrowsException()
        {
            var account = new BankAccount();
            var openingBalance = account.getBalance();

            Assert.Throws<InsufficientFundsException>(() => account.Withdraw(openingBalance + 1));
        }

    }
}
