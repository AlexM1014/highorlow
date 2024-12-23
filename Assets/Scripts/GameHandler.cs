using System;
using System.Diagnostics.Contracts;
using TMPro;
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
    public GameObject rightCardBack;

    public AnswerBox answerBox;
    public DeckAnimation deckAnimation;

    public bool leftCardHigher;
    public bool answer;
    public bool newDraw = true;

    public Button higher;
    public Button lower;

    public State gameState;

    public void Start()
    {
        gameState = State.START;
        higher.interactable = false;
        lower.interactable = false;
        gameDeck.generateDeck();
    }

    public void DrawPressed()
    {
        if (gameDeck.cards.Count > 0) 
        {
            if (newDraw)
            {
                newDraw = false;
                deckAnimation.animateDraw();
                answerBox.toggleBox(false, Color.white);

                leftCard = gameDeck.weightProb(gameDeck.cards);
                rightCard = gameDeck.weightProb(gameDeck.cards);

                gameDeck.GenerateCardImage(leftCard);
                gameDeck.GenerateCardImage(rightCard);

                DisplayCards();
                CompareValues();
                higher.interactable = true;
                lower.interactable = true;
            }
            else
            {
                answerBox.toggleAlert("You must answer this draw!");
            }
        }

        else
        {
            answerBox.toggleAlert("Deck empty!");
        }
    }

    public void DisplayCards()
    {
        leftCardSprite.sprite = leftCard.image;
        rightCardSprite.sprite = rightCard.image;
        rightCardBack.SetActive(true);
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
        rightCardBack.SetActive(false);
        newDraw = true;

        if(playerAnswer)
        {
            answerBox.toggleCorrect();
            higher.interactable = false;
            lower.interactable = false;
        }
        else
        {
            answerBox.toggleIncorrect();
            higher.interactable = false;
            lower.interactable = false;
        }

        deckAnimation.animateDiscard();

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

    public void QuitGame()
    {
        Application.Quit();
    }

}
