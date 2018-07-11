namespace CardWalletInterest.Logic
{
    using System.Collections.Generic;

    using Model;

    public interface IInterestCalculator
    {
        CalculateInterestResult CalculateInterest(Person person, IReadOnlyDictionary<string, CardIssuer> cardIssuers);
    }
}