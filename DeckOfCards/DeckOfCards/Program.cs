using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkProgram workProgram = new WorkProgram();
        }
    }

    class WorkProgram
    {
        private Player _player = new Player();
        private Deck _deck = new Deck();

        private string _userInput;
        private bool _isWork = true;

        public WorkProgram()
        {
            const string ComandYes = "yes";
            const string ComandNo = "no";

            _deck.Shuffle();

            while (_isWork)
            {
                Console.WriteLine($"Кол-во карт в колоде = {_deck.GetSizeDeck()}");
                Console.WriteLine($"Хотите взять карту ? {ComandYes} или {ComandNo}");
                _userInput = Console.ReadLine();

                if (_userInput == ComandYes)
                {
                    TookСard();
                }
                else if (_userInput == ComandNo)
                {
                    _isWork = false;
                }

                if (_deck.GetSizeDeck() == 0)
                {
                    _isWork = false;
                }
            }

            _player.ShowCards();
        }

        private void TookСard()
        {
            Card getСard = _deck.TakeCard();

            _player.AddCard(getСard);
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

        public int GetSizeDeck()
        {
            return _cards.Count;
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i, _cards.Count);

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
