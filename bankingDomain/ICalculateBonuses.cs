using System;
using System.Collections.Generic;
using System.Text;

namespace bankingDomain
{
    public interface ICalculateBonuses
    {
        decimal GetDepositBonusFor(decimal amountToDeposit, decimal currentBalance);
    }
}
