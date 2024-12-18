using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Suit
    {
        SPADES, //0
        HEARTS, //1
        DIAMONDS, // 2
        CLUBS // 3
    }

    public int numValue;
    public Sprite image;
    public Suit cardSuit;
    public int tieValue;

    public Card(int suit, int numValue)
    {
        cardSuit = (Suit)suit;
        this.numValue = numValue;
        tieValue = suit + numValue;
    }


}
