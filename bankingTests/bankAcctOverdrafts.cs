using bankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class bankAcctOverdrafts
    {

        private decimal _openingBalance;
        private BankAccount _account;
        public bankAcctOverdrafts()
        {
            _account = new BankAccount(new Mock<ICalculateBonuses>().Object, new Mock<INarcOnAccounts>().Object);
            _openingBalance = _account.getBalance();
        }

        [Fact]
        public void overdraftDoesNotDecreaseBalance()
        {
            try
            {
                _account.Withdraw(_openingBalance + 1);
            }
            catch (InsufficientFundsException)
            {

                // swallow the exception
            }

            Assert.Equal(_openingBalance, _account.getBalance());
        }

        [Fact]
        public void overdraftThrowsException()
        {
            Assert.Throws<InsufficientFundsException>(() => _account.Withdraw(_openingBalance + 1));
        }

    }
}
