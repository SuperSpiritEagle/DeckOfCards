using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ComandYes = "yes";
            const string ComandNo = "no";

            Player player = new Player();
            Deck deck = new Deck();

            int numberCards = 52;
            string userInput;
            bool isWork = true;

            deck.CreateDeck();
            deck.Shuffle();

            while (isWork)
            {
                Console.WriteLine($"Кол-во карт в колоде = {numberCards}");
                Console.WriteLine($"Хотите взять карту ? {ComandYes} или {ComandNo}");
                userInput = Console.ReadLine();

                if (userInput == ComandYes)
                {
                    TookСard(player, deck, ref numberCards);
                }
                else if (userInput == ComandNo)
                {
                    isWork = false;
                }
                if (numberCards == 0)
                {
                    isWork = false; ;
                }
            }

            player.ShowCards();
        }

        static public void TookСard(Player player, Deck deck, ref int count)
        {
            Card card = deck.TakeCard();

            player.AddCard(card);

            count--;
        }
    }

    class Card
    {
        private string _meaning;
        private string _suit;

        public Card(string meaning, string suit)
        {
            _meaning = meaning;
            _suit = suit;
        }

        public void ShowCard()
        {
            Console.WriteLine($"Значение : {_meaning} Масть : {_suit}\n");
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public void CreateDeck()
        {
            string[] _meaning = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] _suits = new string[] { "Трефы", "Пики", "Червы", "Бубны" };

            for (int i = 0; i < _meaning.Length; i++)
            {
                for (int j = 0; j < _suits.Length; j++)
                {
                    _cards.Add(new Card(_meaning[i], _suits[j]));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                Card temp = _cards[j];
                _cards[j] = _cards[i];
                _cards[i] = temp;
            }
        }

        public Card TakeCard()
        {
            Card randomCard = _cards[_cards.Count - 1];
            _cards.Remove(randomCard);

            return randomCard;
        }
    }

    class Player
    {
        private List<Card> _playerСards = new List<Card>();

        public void AddCard(Card card)
        {
            _playerСards.Add(card);
        }

        public void ShowCards()
        {
            for (int i = 0; i < _playerСards.Count; i++)
            {
                _playerСards[i].ShowCard();
            }
        }
    }
}
