using System.Collections.Generic;
using System;

namespace deckofcards
{
	public enum Suit {
		Club, 
		Diamond,
		Heart,
		Spade
	}

	public abstract class Card {

		private bool _isAvailable;

		protected int faceValue;
		protected Suit suit;

		public Suit Suit {
			get {
				return suit;
			} set {
				suit = value;
			}
		}

		public abstract int GetValue();

		public Card(Suit suit, int val) {
			this.suit = suit;
			this.faceValue = val;
		}

		public bool IsAvailable() {
			return _isAvailable;
		}

		public void MarkAvailable() {
			_isAvailable = true;
		}

		public void MarkUnavailable() {
			_isAvailable = false;
		}
	}


	public class Deck<T> {
		private List<T> _cards;
		private int dealtIndex = 0;

		public void SetDeckOfCards(List<T> cards) {
			this._cards = cards;
		}

		public void Shuffle() {
		}

		public int RemainingCards() {
			return this._cards.Count - dealtIndex;
		}

		//Return the cards
		public T[] DealHand(int number) {
			var arr = new T[]{};
			return arr;
		}
		//Return card
		public T DealCard() {
			return _cards[0];
		}
	}


	public class Hand<T> where T: Card {
		protected List<T> _cards = new List<T>();

		public Hand() {
		}

		public Hand(IList<T> cards) {
			_cards = new List<T>(cards);
		}

		public int Score() {
			int score = 0;
			foreach(var c in _cards) {
				score += c.GetValue();
			}
			return score;
		}

		public void AddCard(T c) {
			this._cards.Add(c);
		}
	}


	public class BlackjackCard : Card {

		public BlackjackCard(Suit s, int v) : base(s, v) {
		}

		public override int GetValue() {
			if(isFaceCard()) {
				return 10;
			}
			if(isAce()) {
				return 1;
			}
			return faceValue;
		}


		private bool isAce() {
			return this.faceValue == 1;
		}

		private bool isFaceCard() {
			return this.faceValue >= 11 && this.faceValue <= 13;
		}
	}


	public class BlackjackHand : Hand<BlackjackCard> {

		private IList<int> allPossibleScores() {
			var result = new List<int>();
			return result;
		}


		public new int Score() {
			
			var scores = allPossibleScores();

			//the maximum score that's under 21
			var maxUnder = Int32.MinValue;
			//the minimum score that's over 21.
			var minOver = Int32.MaxValue;

			foreach(var score in scores) {

				if (score > 21 && score < minOver) {
					minOver = score;
				} else if(score < 21 && score > maxUnder) {
					maxUnder = score;
				}
			}

			return minOver != Int32.MaxValue ? minOver : maxUnder;
		}

	}


	class Program
	{
		static void Main(string[] args)
		{	
			var hand = new BlackjackHand();

			var card1 = new BlackjackCard(Suit.Club, 1);
			var card2 = new BlackjackCard(Suit.Diamond, 5);
			hand.AddCard(card1);
			hand.AddCard(card2);
			var score = hand.Score();

			Console.WriteLine($"the score is {score}");
		}
	}

}






























