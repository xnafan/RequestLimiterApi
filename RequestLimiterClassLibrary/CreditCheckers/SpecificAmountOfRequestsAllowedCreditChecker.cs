namespace RequestLimiterClassLibrary.CreditCheckers
{
    public class SpecificAmountOfRequestsAllowedCreditChecker : ICreditChecker
    {
        public int CreditsLeft { get; set; }

        public SpecificAmountOfRequestsAllowedCreditChecker(int creditsLeft = 10)
        {
            CreditsLeft = creditsLeft;
        }

        public bool ChargeOneCredit(string accountKey)
        {
            CreditsLeft--;
            return CreditsLeft >= 0;
        }
    }
}