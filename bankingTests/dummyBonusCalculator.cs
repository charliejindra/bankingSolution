using bankingDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace bankingTests
{
    public class dummyBonusCalculator : ICalculateBonuses
    {
        public decimal GetDepositBonusFor(decimal amountToDeposit, decimal currentBalance)
        {
            return 0;
        }
    }
}
