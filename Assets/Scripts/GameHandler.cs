using System;
using System.Diagnostics.Contracts;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Deck gameDeck;
    Card leftCard;
    Card rightCard;


    [Header("Game Buttons")]
    public Button higher;
    public Button lower;

    [Header("UI Components")]
    public GameObject rightCardBack;
    public Image rightCardSprite;
    public Image leftCardSprite;
    public AnswerBox answerBox;
    public TextMeshProUGUI pointsUI;
    public int points;

    [Header("Animation")]
    public DeckAnimation deckAnimation;

    [Header("Audio")]
    public GameAudio gameAudioHandler;

    bool leftCardHigher;
    bool answer;
    bool newDraw = true;




    public void Start()
    {
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
        }

        else
        {
            answerBox.toggleReset();
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
            points++;
            updatePointUI();
            gameAudioHandler.playResultSound(true);
            answerBox.toggleCorrect();
            higher.interactable = false;
            lower.interactable = false;
        }
        else
        {
            gameAudioHandler.playResultSound(false);
            answerBox.toggleIncorrect();
            higher.interactable = false;
            lower.interactable = false;
        }

        deckAnimation.animateRightFlip();
    }

    public void updatePointUI()
    {
        pointsUI.text = "Score: " + points;
    }

    public void CompareValues()
    {
        if(leftCard.numValue == rightCard.numValue)
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

        else if (leftCard.numValue > rightCard.numValue)
        {
            leftCardHigher = true;
        }

        else
        {
            leftCardHigher = false;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
