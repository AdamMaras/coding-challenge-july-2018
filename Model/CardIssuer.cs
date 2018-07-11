namespace CardWalletInterest.Model
{
    public class CardIssuer
    {
        public CardIssuer(string id, decimal interestRate)
        {
            this.Id = id;
            this.InterestRate = interestRate;
        }

        public string Id { get; }
        public decimal InterestRate { get; }
    }
}