using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Suit
    {
        SPADES, //1
        HEARTS, //2
        DIAMONDS, // 3
        CLUBS // 4
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
