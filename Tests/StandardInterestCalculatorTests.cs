namespace CardWalletInterest.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Logic;
    using Model;

    [TestClass]
    public class StandardInterestCalculatorTests
    {
        private readonly Dictionary<string, CardIssuer> mockCardIssuers = new Dictionary<string, CardIssuer>
        {
            { "visa", new CardIssuer("visa", 0.1M) },
            { "mastercard", new CardIssuer("mastercard", 0.05M) },
            { "discover", new CardIssuer("discover", 0.01M) },
        };

        [TestMethod]
        public void TestCase1()
        {
            var card1 = new Card("visa", 100);
            var card2 = new Card("mastercard", 100);
            var card3 = new Card("discover", 100);

            var wallet = new Wallet(new [] { card1, card2, card3 });

            var person = new Person("person", new [] { wallet });

            var calculator = new StandardInterestCalculator();
            var result = calculator.CalculateInterest(person, mockCardIssuers);

            Assert.AreEqual(result.PersonInterest, 16);

            Assert.AreEqual(result.CardInterest[card1], 10);
            Assert.AreEqual(result.CardInterest[card2], 5);
            Assert.AreEqual(result.CardInterest[card3], 1);
        }

        [TestMethod]
        public void TestCase2()
        {
            var card1 = new Card("visa", 100);
            var card2 = new Card("discover", 100);

            var wallet1 = new Wallet(new [] { card1, card2 });

            var card3 = new Card("mastercard", 100);

            var wallet2 = new Wallet(new [] { card3 });

            var person = new Person("person", new [] { wallet1, wallet2 });

            var calculator = new StandardInterestCalculator();
            var result = calculator.CalculateInterest(person, mockCardIssuers);

            Assert.AreEqual(result.PersonInterest, 16);

            Assert.AreEqual(result.WalletInterest[wallet1], 11);
            Assert.AreEqual(result.WalletInterest[wallet2], 5);            

            Assert.AreEqual(result.CardInterest[card1], 10);
            Assert.AreEqual(result.CardInterest[card2], 1);
            Assert.AreEqual(result.CardInterest[card3], 5);
        }

        [TestMethod]
        public void TestCase3()
        {
            var card1 = new Card("mastercard", 100);
            var card2 = new Card("mastercard", 100);

            var wallet1 = new Wallet(new [] { card1, card2 });

            var person1 = new Person("person1", new [] { wallet1 });

            var card3 = new Card("visa", 100);
            var card4 = new Card("mastercard", 100);

            var wallet2 = new Wallet(new [] { card3, card4 });

            var person2 = new Person("person2", new [] { wallet2 });

            var calculator = new StandardInterestCalculator();
            var result1 = calculator.CalculateInterest(person1, mockCardIssuers);
            var result2 = calculator.CalculateInterest(person2, mockCardIssuers);

            Assert.AreEqual(result1.PersonInterest, 10);

            Assert.AreEqual(result1.WalletInterest[wallet1], 10);

            Assert.AreEqual(result1.CardInterest[card1], 5);
            Assert.AreEqual(result1.CardInterest[card2], 5);

            Assert.AreEqual(result2.PersonInterest, 15);

            Assert.AreEqual(result2.WalletInterest[wallet2], 15);

            Assert.AreEqual(result2.CardInterest[card3], 10);
            Assert.AreEqual(result2.CardInterest[card4], 5);
        }
    }
}