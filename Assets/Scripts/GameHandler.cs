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
        Debug.Log("Probability");
        gameDeck.generateProbability();
    }

    public void DrawPressed()
    {
        if (gameDeck.cards.Count > 0) 
        {
            if (newDraw)
            {
                newDraw = false;
                answerBox.toggleBox(false, Color.white);
                //gameDeck.Draw(out leftCard);
                //gameDeck.Draw(out rightCard);

                gameDeck.GenerateCardImage(leftCard);
                gameDeck.GenerateCardImage(rightCard);

                DisplayCards();
                CompareValues();
                higher.interactable = true;
                lower.interactable = true;

            }
            else
            {
                answerBox.toggleBox(true, Color.red);
                answerBox.changeBoxText("Need to answer this draw");
            }
        }

        else
        {
            answerBox.toggleBox(true, Color.red);
            answerBox.changeBoxText("Deck is empty");
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
            answerBox.toggleBox(true, Color.green);
            answerBox.changeBoxText("Correct!");
            higher.interactable = false;
            lower.interactable = false;
            //Debug.Log("Correct!");
        }
        else
        {
            answerBox.toggleBox(true, Color.red);
            answerBox.changeBoxText("Incorrect!");
            higher.interactable = false;
            lower.interactable = false;
            //Debug.Log("Wrong!");
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

    public void QuitGame()
    {
        Application.Quit();
    }

}
