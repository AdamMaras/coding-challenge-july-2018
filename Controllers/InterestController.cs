namespace CardWalletInterest.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Logic;
    using Model;

    public class InterestController
    {
        private readonly IPersonService personService;
        private readonly ICardIssuerService cardIssuerService;

        private readonly IInterestCalculator interestCalculator;

        public InterestController(
            IPersonService personService, ICardIssuerService cardIssuerService, IInterestCalculator interestCalculator
        )
        {
            this.personService = personService;
            this.cardIssuerService = cardIssuerService;

            this.interestCalculator = interestCalculator;
        }

        public CalculateInterestResult CalculateInterest(string personId)
        {
            var person = this.personService.GetPersonById(personId);
            var cardIssuerIds = person.Wallets.SelectMany(wallet => wallet.Cards)
                .Select(card => card.CardIssuerId).Distinct();
            var cardIssuers = cardIssuerIds.ToDictionary(id => id, this.cardIssuerService.GetCardIssuerById);

            return this.interestCalculator.CalculateInterest(person, cardIssuers);
        }
    }
}