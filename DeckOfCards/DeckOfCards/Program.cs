using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Croupier сroupier = new Croupier();
        }
    }

    class Croupier
    {
        public Croupier()
        {
            const string ComandYes = "yes";
            const string ComandNo = "no";

            Player player = new Player();
            Deck deck = new Deck();

            string userInput;
            bool isWork = true;

            deck.Shuffle();

            while (isWork)
            {
                Console.WriteLine($"Кол-во карт в колоде = {deck.GetSizeDeck()}");
                Console.WriteLine($"Хотите взять карту ? {ComandYes} или {ComandNo}");
                userInput = Console.ReadLine();

                if (userInput == ComandYes)
                {
                    player.AddCard(deck.GiveCard());
                }
                else if (userInput == ComandNo)
                {
                    isWork = false;
                }

                if (deck.GetSizeDeck() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Колода Пуста!!!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            player.ShowCards();
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

        public Deck()
        {
            CreateDeck();
        }

        public int GetSizeDeck()
        {
            return _cards.Count;
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i >= 1; i--)
            {
                int RandomIndex = random.Next(i, _cards.Count);

                Card temp = _cards[RandomIndex];
                _cards[RandomIndex] = _cards[i];
                _cards[i] = temp;
            }
        }

        public Card GiveCard()
        {
            ControlSizeDeck();

            Card randomCard = _cards[_cards.Count - 1];

            _cards.Remove(randomCard);

            return randomCard;
        }

        private void CreateDeck()
        {
            string[] meaning = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
            string[] suits = new string[] { "Трефы", "Пики", "Червы", "Бубны" };

            for (int i = 0; i < meaning.Length; i++)
            {
                for (int j = 0; j < suits.Length; j++)
                {
                    _cards.Add(new Card(meaning[i], suits[j]));
                }
            }
        }

        private void ControlSizeDeck()
        {
            if (_cards.Count <= 0)
            {
                _cards.Add(new Card("NULL", "NULL"));
            }
        }
    }

    class Player
    {
        private List<Card> _playerСards = new List<Card>();

        public void AddCard(Card forCard)
        {
            _playerСards.Add(forCard);
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
