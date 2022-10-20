namespace RequestLimiterClassLibrary.CreditCheckers
{
    public class InfiniteRequestsAllowedCreditChecker : ICreditChecker
    {
        public bool ChargeOneCredit(string accountKey) => true;
    }
}
