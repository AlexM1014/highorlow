using System;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public enum State
    {
        START,
        PLAYINGGAME,
        END
    }

    public Deck gameDeck;
    public Card leftCard;
    public Card rightCard;

    public Image leftCardSprite;
    public Image rightCardSprite;

    public bool leftCardHigher;
    public bool answer;

    public State gameState;

    public void Start()
    {
        gameState = State.START;
    }

    public void DrawPressed()
    {
        if(gameDeck.cards.Count > 0) 
        {
            gameDeck.Draw(out leftCard);
            gameDeck.Draw(out rightCard);

            gameDeck.GenerateCardImage(leftCard);
            gameDeck.GenerateCardImage(rightCard);

            DisplayCards();
            CompareValues();
        }

        else
        {

        }
    }



    public void DisplayCards()
    {
        leftCardSprite.sprite = leftCard.image;
        rightCardSprite.sprite = rightCard.image;
    }

    public void RightHigherPressed()
    {
        if(leftCardHigher)
        {
            answer = false;
        }

        else
        {
            answer = true;
        }

        ApplyPoints(answer);
    }

    public void RightLowerPressed()
    {
        if(leftCardHigher)
        {
            answer = true;
        }
        else
        {
            answer = false;
        }

        ApplyPoints(answer);
    }

    private void ApplyPoints(bool playerAnswer)
    {
        if(playerAnswer)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }
    }

    public void CompareValues()
    {
        if (leftCard.numValue > rightCard.numValue)
        {
            leftCardHigher = true;
        }
        else if(leftCard.numValue == rightCard.numValue)
        {
            if(leftCard.tieValue > rightCard.tieValue)
            {
                leftCardHigher = true;
            }
            else
            {
                leftCardHigher = false;
            }
        }
        else
        {
            leftCardHigher = false;
        }

    }

}
