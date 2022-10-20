namespace RequestLimiterClassLibrary.CreditCheckers
{
    public interface ICreditChecker
    {
        bool ChargeOneCredit(string accountKey);
    }
}