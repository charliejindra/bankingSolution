using bankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class bankaccountNotifiedFed
    {
        [Fact]
        public void NotifiedOnWithdrawals()
        {
            var mockedFed = new Mock<INarcOnAccounts>();
            var account = new BankAccount(new Mock<ICalculateBonuses>().Object, mockedFed.Object) ;


            account.Withdraw(108);

            mockedFed.Verify(m => m.NotifyOfWithdrawal(account, 108));
        }
    }
}
