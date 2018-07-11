namespace CardWalletInterest.Contracts
{
    using Model;

    public interface IPersonService
    {
        Person GetPersonById(string id);
    }
}