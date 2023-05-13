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

            string userInput;
            bool isWork = true;
            int count = deck.GetCountDeck();

            deck.CreateDeck();

            while (isWork)
            {
                Console.WriteLine($"Хотите взять карту ? {ComandYes} или {ComandNo}");
                userInput = Console.ReadLine();

                if (userInput == ComandYes)
                {
                    List<Card> cards = deck.TakeCard();

                    player.AddCard(cards);
                    count -= 1;

                    if (count == 0)
                    {
                        isWork = false;
                    }
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

        public void ShowCard()
        {
            Console.WriteLine($"Значение : {_meaning} Масть : {_suit}\n");
        }
    }

    class Deck
    {
        private string[] _meaning = new string[] { "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", "Ace" };
        private string[] _suits = new string[] { "Трефы", "Пики", "Червы", "Бубны" };

        private List<Card> _cards = new List<Card>();

        public void CreateDeck()
        {
            for (int i = 0; i < _meaning.Length; i++)
            {
                for (int j = 0; j < _suits.Length; j++)
                {
                    _cards.Add(new Card(_meaning[i], _suits[j]));
                }
            }
        }

        public int GetCountDeck()
        {
            return _cards.Count;
        }

        public List<Card> TakeCard()
        {
            Random random = new Random();
            List<Card> card = new List<Card>();

            int count = _cards.Count;
            int index = random.Next(0, count);

            card.Add(_cards[index]);
            _cards.RemoveAt(index);

            return card;
        }
    }

    class Player
    {
        private List<Card> _myСards = new List<Card>();

        public void AddCard(List<Card> card)
        {
            _myСards.Add(card[0]);
        }

        public void ShowCards()
        {
            for (int i = 0; i < _myСards.Count; i++)
            {
                _myСards[i].ShowCard();
            }
        }
    }
}
