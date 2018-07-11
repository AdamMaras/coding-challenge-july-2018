namespace CardWalletInterest.Contracts
{
    using Model;
    
    public interface ICardIssuerService
    {
        CardIssuer GetCardIssuerById(string id);
    }
}