namespace CardWalletInterest.Model
{
    public class Card
    {
        public Card(string cardIssuerId, decimal balance)
        {
            this.CardIssuerId = cardIssuerId;
            this.Balance = balance;
        }

        public string CardIssuerId { get; }
        public decimal Balance { get; }
    }
}