namespace bankingDomain
{
    public interface INarcOnAccounts
    {
        void NotifyOfWithdrawal(BankAccount bankAccount, decimal withdrawalAmount);
    }
}