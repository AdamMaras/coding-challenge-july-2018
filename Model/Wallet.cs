namespace CardWalletInterest.Model
{
    using System.Collections.Generic;

    public class Wallet
    {
        public Wallet(IReadOnlyCollection<Card> cards)
        {
            this.Cards = cards;
        }

        public IReadOnlyCollection<Card> Cards { get; }
    }
}