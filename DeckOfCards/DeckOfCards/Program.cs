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
            HandOutCards();
        }

        private void HandOutCards()
        {
            const string ComandYes = "yes";
            const string ComandNo = "no";

            Player player = new Player();
            Deck deck = new Deck();

            string userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Кол-во карт в колоде = {deck.GetSize()}");
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

        public void ShowInfo()
        {
            Console.WriteLine($"Значение : {_meaning} - Масть : {_suit}\n");
        }
    }

    class Deck
    {
        private List<Card> _cards = new List<Card>();

        public Deck()
        {
            Create();
        }

        public int GetSize()
        {
            return _cards.Count;
        }

        public Card GiveCard()
        {
            ControlSize(out Card card);
            return card;
        }

        private void Create()
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

            Shuffle();
        }

        private bool ControlSize(out Card card)
        {
            if (_cards.Count > 0)
            {
                card = _cards[_cards.Count - 1];
                _cards.Remove(card);

                return true;
            }
            else
            {
                card = null;
                return false;
            }
        }

        private void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i >= 1; i--)
            {
                int randomIndex = random.Next(i, _cards.Count);

                Card temp = _cards[randomIndex];
                _cards[randomIndex] = _cards[i];
                _cards[i] = temp;
            }
        }
    }

    class Player
    {
        private List<Card> _cards = new List<Card>();

        public void AddCard(Card Card)
        {
            if (Card != null)
            {
                _cards.Add(Card);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Колода Пуста!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ShowCards()
        {
            for (int i = 0; i < _cards.Count; i++)
            {
                _cards[i].ShowInfo();
            }
        }
    }
}
