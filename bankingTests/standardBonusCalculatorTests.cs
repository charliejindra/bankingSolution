using bankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace bankingTests
{
    public class StandardBonusCalculatorTests
    {
        [Theory]
        [InlineData(100,9999,0)]
        [InlineData(100,10000,10)]
        public void CanCalculateBonusesBeforeCutoff(decimal deposit, decimal balance, decimal expected)
        {
            ICalculateBonuses bonusCalculator = new TestingStandingBonusBonusCalculator(true);
            var bonus = bonusCalculator.GetDepositBonusFor(deposit, balance);

            Assert.Equal(expected, bonus);
        }

        [Theory]
        [InlineData(100, 9999, 0)]
        [InlineData(100, 10000, 5)]
        public void CanCalculateBonusesAfterCutoff(decimal deposit, decimal balance, decimal expected)
        {
            ICalculateBonuses bonusCalculator = new TestingStandingBonusBonusCalculator(false);
            var bonus = bonusCalculator.GetDepositBonusFor(deposit, balance);

            Assert.Equal(expected, bonus);
        }
    }

    public class TestingStandingBonusBonusCalculator : standardBonusCalculator
    {
        private bool isBeforeCutoff;
        public TestingStandingBonusBonusCalculator(bool isBeforeCutoff)
        {
            this.isBeforeCutoff = isBeforeCutoff;
        }

        protected override bool BeforeCutoff()
        {
            return isBeforeCutoff;
        }
    }
}
