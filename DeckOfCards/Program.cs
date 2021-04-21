using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start of program. Program asks which deck of cards the user wants
            Console.WriteLine("Which deck of card would you like to see? \nPlease input Normal or Shuffled: ");
            string deckchoise = Console.ReadLine();
            do
            {
                if (deckchoise.Equals("Normal"))
                {
                    Console.WriteLine("Normal Deck: \n");
                    Console.WriteLine(
                    //Clubs
                    "Ace of Clubs\n" + "2 of Clubs\n" + "3 of Clubs\n" + "4 of Clubs\n" + "5 of Clubs\n" + "6 of Clubs\n" + "7 of Clubs\n" + "8 of Clubs\n" + "9 of Clubs\n" + "10 of Clubs\n" + "Jack of Clubs\n" + "Queen of Clubs\n" + "King of Clubs\n" +
                    //Diamonds
                    "Ace of Diamonds\n" + "2 of Diamonds\n" + "3 of Diamonds\n" + "4 of Diamonds\n" + "5 of Diamonds\n" + "6 of Diamonds\n" + "7 of Diamonds\n" + "8 of Diamonds\n" + "9 of Diamonds\n" + "10 of Diamonds\n" + "Jack of Diamonds\n" + "Queen of Diamonds\n" + "King of Diamonds\n" +
                    //Hearts      
                    "Ace of Hearts\n" + "2 of Hearts\n" + "3 of Hearts\n" + "4 of Hearts\n" + "5 of Hearts\n" + "6 of Hearts\n" + "7 of Hearts\n" + "8 of Hearts\n" + "9 of Hearts\n" + "10 of Hearts\n" + "Jack of Hearts\n" + "Queen of Hearts\n" + "King of Hearts\n" +
                    //Spades
                    "Ace of Spades\n" + "2 of Spades\n" + "3 of Spades\n" + "4 of Spades\n" + "5 of Spades\n" + "6 of Spades\n" + "7 of Spades\n" + "8 of Spades\n" + "9 of Spades\n" + "10 of Spades\n" + "Jack of Spades\n" + "Queen of Spades\n" + "King of Spades\n\n\n");

                    Console.WriteLine("Would you like to shuffle the deck? \nPlease input Yes or No: ");
                    string shufflechoise = Console.ReadLine();
                    do
                    {
                        if (shufflechoise.Equals("Yes"))
                        {
                            Console.WriteLine("Shuffled Deck: \n");
                            Deck deck1 = new Deck();
                            deck1.Shuffle();
                            for (int i = 0; i < 52; i++)
                            {
                                Console.Write("{0,-19}", deck1.DealCard());
                                if ((i + 1) % 1 == 0)
                                    Console.WriteLine();
                            }
                            Console.ReadLine();
                        }
                        else if (shufflechoise.Equals("No"))
                        {
                            //Console.WriteLine("The above deck is your deck");
                            Deck deck1 = new Deck();
                            Console.Write(deck1.DealCard());
                            Console.ReadLine();
                        }
                        else { Console.WriteLine("Sorry, I did not recognise your input. Please try again."); } //Program doesn't recognise valid input
                        Console.ReadLine();
                    } while (shufflechoise == "0");

                }
                else if (deckchoise.Equals("Shuffled"))
                {
                    Console.WriteLine("Shuffled Deck: \n");
                    Deck deck1 = new Deck();
                    deck1.Shuffle();
                    for (int i = 0; i < 52; i++)
                    {
                        Console.Write("{0,-19}", deck1.DealCard());
                        if ((i + 1) % 1 == 0)
                            Console.WriteLine();
                    }
                    Console.ReadLine();
                }
                else { Console.WriteLine("Sorry, I did not recognise your input. Please try again."); } //Program doesn't recognise valid input
                Console.ReadLine();
            } while (deckchoise == "0");
        }

        public class Deck
        {
            private Card[] deck;
            private int currentCard;
            private const int NUMBER_OF_CARDS = 52;
            private Random ranNum;

            public Deck()
            {
                string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King", };
                string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
                deck = new Card[NUMBER_OF_CARDS];
                currentCard = 0;
                ranNum = new Random();
                for (int count = 0; count < deck.Length; count++)
                    deck[count] = new Card(faces[count % 11], suits[count / 13]);
            }

            public void Shuffle()
            {
                currentCard = 0;
                for (int first = 0; first < deck.Length; first++)
                {
                    int second = ranNum.Next(NUMBER_OF_CARDS);
                    Card temp = deck[second];
                    deck[second] = temp;
                }
            }

            public Card DealCard()
            {
                if (currentCard < deck.Length)
                    return deck[currentCard++];
                else
                    return null;
            }

        }

        public class Card
        {
            private string face;
            private string suit;

            public Card(string cardFace, string cardSuit)
            {
                face = cardFace;
                suit = cardSuit;
            }

            public override string ToString()
            {
                return face + " of " + suit;
            }
        }
    }
}
