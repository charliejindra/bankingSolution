﻿using System;
using System.Collections.Generic;
using System.Text;

namespace bankingDomain
{
    public class standardBonusCalculator : ICalculateBonuses
    {

        ISystemTime _systemTime;

        public standardBonusCalculator(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        decimal ICalculateBonuses.GetDepositBonusFor(decimal amountToDeposit, decimal currentBalance)
        {
            //return currentBalance >= 10000 ? amountToDeposit * .1M : 0;
            if(currentBalance >= 10000)
            {
                if (BeforeCutoff())
                {
                    return amountToDeposit * .1M;
                }
                else
                {
                    return amountToDeposit * .05M;
                }
            }
            else
            {
                return 0;
            }
        }

        protected virtual bool BeforeCutoff()
        {
            return _systemTime.GetCurrent().Hour < 17;
        }
    }
}
