namespace CardWalletInterest.Logic
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Model;

    public class StandardInterestCalculator : IInterestCalculator
    {
        public CalculateInterestResult CalculateInterest(
            Person person, IReadOnlyDictionary<string, CardIssuer> cardIssuers
        )
        {
            var cardInterest = person.Wallets.SelectMany(wallet => wallet.Cards).ToDictionary(card => card, card =>
                card.Balance * cardIssuers[card.CardIssuerId].InterestRate
            );

            var walletInterest = person.Wallets.ToDictionary(wallet => wallet, wallet =>
                wallet.Cards.Sum(card => cardInterest[card])
            );

            var personInterest = person.Wallets.Sum(wallet => walletInterest[wallet]);

            return new CalculateInterestResult(personInterest, walletInterest, cardInterest);
        }
    }
}