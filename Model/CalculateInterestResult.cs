namespace CardWalletInterest.Model
{
    using System.Collections.Generic;

    public class CalculateInterestResult
    {
        public CalculateInterestResult(
            decimal personInterest, IReadOnlyDictionary<Wallet, decimal> walletInterest,
            IReadOnlyDictionary<Card, decimal> cardInterest
        )
        {
            this.PersonInterest = personInterest;
            this.WalletInterest = walletInterest;
            this.CardInterest = cardInterest;
        }

        public decimal PersonInterest { get; }
        public IReadOnlyDictionary<Wallet, decimal> WalletInterest { get; }
        public IReadOnlyDictionary<Card, decimal> CardInterest { get; }
    }

}