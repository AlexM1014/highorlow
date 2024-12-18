using System.Diagnostics;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GameHandler : MonoBehaviour
{

    public Deck gameDeck;
    public Card leftCard;
    public Card rightCard;

    public Image leftCardSprite;
    public Image rightCardSprite;

    //visualize cards in inspector
    //left
    public string leftSuit;
    public int leftValue;

    //righnt
    public string rightSuit;
    public int rightValue;

    public void DrawPressed()
    {
        gameDeck.Draw(out leftCard, out rightCard);
        leftSuit = leftCard.cardSuit.ToString();
        leftValue = leftCard.numValue;

        rightSuit = rightCard.cardSuit.ToString();
        rightValue = rightCard.numValue;

        Debug.Log(leftCard.cardSuit + " " + leftCard.numValue);
        Debug.Log(rightCard.cardSuit + " " + rightCard.numValue);

        gameDeck.GenerateCardImage(leftCard);
        gameDeck.GenerateCardImage(rightCard);

        DisplayCards();
    }

    public void DisplayCards()
    {
        leftCardSprite.sprite = leftCard.image;
        rightCardSprite.sprite = rightCard.image;
    }
}
