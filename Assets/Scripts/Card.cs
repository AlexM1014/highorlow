using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Suit
    {
        CLUBS, //1
        DIAMONDS, //2
        HEARTS, // 3
        SPADES // 4
    }

    public Suit cardSuit;
    public Sprite image;
    public int numValue;
    public int tieValue;
    public string cardName;

    public Card(int suit, int numValue)
    {
        cardSuit = (Suit)suit;
        this.numValue = numValue;
        tieValue = suit + numValue;
        cardName = cardSuit.ToString() + numValue;
    }


}
