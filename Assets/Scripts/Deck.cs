using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    public List<Card> aceOfSpade;
    public List<Card> hearts;
    public List<Card> cards;
    public List<string> cardNames;

    public List<Card> discardPile;
    public List<string> discardedCardNames;


    //float[] cars = { "Volvo", "BMW", "Ford", "Mazda" };

    public int randNumber;
    public string currentCardName;

    public List<Sprite> spadeSprites;
    public List<Sprite> clubSprites;
    public List<Sprite> heartSprites;
    public List<Sprite> diamondSprites;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            generateDeck();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {

        }
    }

    public void generateDeck()
    {
        for (int suits = 0; suits <= 3; suits++)
        {
            for (int value = 1; value <= 13; value++)
            {
                if(suits == 1 && value == 1)
                {
                    aceOfSpade.Add(new Card(suits, value));
                }
                if(suits == 3)
                {
                    hearts.Add(new Card(suits,value));
                }
                else
                {
                    cards.Add(new Card(suits, value));
                }     
            }
        }
    }

    public float[] generateProbability()
    {
        float[] probabilityNums = new float[52];
        string output = "";

        for (int i = 0; i < 52; i++)
        {
            if(i < 38)
            {
                probabilityNums[i] = 1;
            }

            else if(i >= 38 && i < 51)
            {
                probabilityNums[i] = 2;
            }

            else
            {
                probabilityNums[i] = 3;
            }

        }
        
        foreach(float val in probabilityNums)
        {
            

            output += ", " + val;
        }

        Debug.Log(output);
        return probabilityNums;
    }

    /*    public void Draw(out Card CurrentCard)
        {

            if (cards.Count >= 0)
            {
                int randNumber = UnityEngine.Random.Range(0, cards.Count);
                CurrentCard = cards[randNumber];

                //Check if the CurrentCard is already in the discardPile
                DuplicateCheck(CurrentCard.cardName);
                currentCardName = CurrentCard.cardName;

                //Add in drawn card to discardPile
                discardPile.Add(CurrentCard);
                discardedCardNames.Add(CurrentCard.cardName);

                cards.RemoveAt(randNumber);
                cardNames.RemoveAt(randNumber);
            }

            else
            {
                Debug.Log("Deck is empty. Game Over");
                CurrentCard = null;
            }
        }*/

    float weightedDraw(float[] drawType)
    {
        //3 different draw types
        //spade
        //heart
        //standard

        float total = 0;

        foreach (float drawProb in drawType)
        {
            total += drawProb;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < drawType.Length; i++)
        {
            if (randomPoint < drawType[i])
            {
                Debug.Log("Grab " + i);
                return i;
            }
            else
            {
                randomPoint -= drawType[i];
            }
        }
        return drawType.Length - 1;
    }

    public void GenerateCardImage(Card card)
    {
        switch (card.cardSuit)
        {
            case Card.Suit.SPADES:
                card.image = spadeSprites[card.numValue - 1];
                break;
            case Card.Suit.HEARTS:
                card.image = heartSprites[card.numValue - 1];
                break;
            case Card.Suit.DIAMONDS:
                card.image = diamondSprites[card.numValue - 1];
                break;
            case Card.Suit.CLUBS:
                card.image = clubSprites[card.numValue - 1];
                break;
            default:
                break;
        }
    }

    public void DuplicateCheck(string nameBeingChecked)
    {
        foreach (Card card in discardPile)
        {
            if (nameBeingChecked.Equals(card.cardName))
            {
                Debug.Log("Duplicate Found!");
            }
        }
    }

    public List<Card> getCardList()
    {
        return cards;
    }


    float Choose(float[] probs)
    {
        float total = 0;

        foreach (float cardValue in probs)
        {
            total += cardValue;
        }

        float randomPoint = Random.value * total;
         
        for (int i = 0; i < probs.Length; i++)
        {
           
            if (randomPoint < probs[i])
            {
                return i;
            }
            //
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }
}


