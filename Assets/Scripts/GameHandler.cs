using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

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
        if(gameDeck.cards.Count > 0) 
        {
            gameDeck.Draw(out leftCard);
            gameDeck.Draw(out rightCard);
        }
      
        leftSuit = leftCard.cardSuit.ToString();
        leftValue = leftCard.numValue;

        
        rightSuit = rightCard.cardSuit.ToString();
        rightValue = rightCard.numValue;

        gameDeck.GenerateCardImage(leftCard);
        gameDeck.GenerateCardImage(rightCard);

        DisplayCards();
    }



    public void DisplayCards()
    {
        leftCardSprite.sprite = leftCard.image;
        rightCardSprite.sprite = rightCard.image;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
