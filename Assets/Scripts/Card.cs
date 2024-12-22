using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Suit
    {
        CLUBS, //0
        DIAMONDS, //1
        HEARTS, // 2
        SPADES // 3
    }

    public Suit cardSuit;
    public Sprite image;
    public int numValue;
    public int tieValue;
    public string cardName;
    public float drawChance;

    public Card(int suit, int numValue)
    {
        cardSuit = (Suit)suit;
        this.numValue = numValue;
        tieValue = suit + numValue;
        cardName = cardSuit.ToString() + numValue;
    }


}
