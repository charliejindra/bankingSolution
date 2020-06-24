using bankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class newAccountTests
    {
        [Fact]
        public void newAccountsHaveCorrectBalance()
        {
            var account = new BankAccount();
            decimal balance = account.getBalance();
            Assert.Equal(5000M, balance);
        }
    }
}
