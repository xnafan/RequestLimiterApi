namespace RequestLimiterClassLibrary.CreditCheckers
{
    public class NoRequestsAllowedCreditChecker : ICreditChecker
    {
        public bool ChargeOneCredit(string accountKey) => false;
    }
}
