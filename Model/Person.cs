namespace CardWalletInterest.Model
{
    using System.Collections.Generic;

    public class Person
    {
        public Person(string id, IReadOnlyCollection<Wallet> wallets)
        {
            this.Id = id;
            this.Wallets = wallets;
        }

        public string Id { get; }
        public IReadOnlyCollection<Wallet> Wallets { get; }
    }
}