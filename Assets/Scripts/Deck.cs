using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    public List<Card> cards;
    public List<string> cardNames;

    public List<Card> discardPile;
    public List<string> discardedCardNames;

    public Card returnedCard;


    //float[] cars = { "Volvo", "BMW", "Ford", "Mazda" };

    //public int randNumber;
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
                if(suits == 3  && value == 1)
                {
                    cards.Add(new Card(suits, value, 3));
                }
                else if(suits == 2)
                {
                    cards.Add(new Card(suits,value, 2));
                }
                else
                {
                    cards.Add(new Card(suits, value, 1));
                } 
            }
        }

        foreach (Card card in cards)
        {
            cardNames.Add(card.cardName);
        }
    }

        public void Draw(out Card CurrentCard)
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
        }

     public Card weightProb(List<Card> cardList)
    {
        float totalWeight = 0;

        foreach (Card card in cardList)
        {
            totalWeight += card.prob;
        }

        float whatCard = Random.value * totalWeight;

        for (int i = 0; i < cardList.Count; i++)
        {
            if (whatCard < cardList[i].prob)
            {
                returnedCard = cardList[i];

                //Check if the CurrentCard is already in the discardPile
                DuplicateCheck(cardList[i].cardName);
                currentCardName = cardList[i].cardName;

                //Add in drawn card to discardPile
                discardPile.Add(cardList[i]);
                discardedCardNames.Add(cardList[i].cardName);

                Debug.Log("Index: " + i + ", " + cardList[i].cardName);

                cards.RemoveAt(i);
                cardNames.RemoveAt(i);

                

                return returnedCard;
            }
            else
            {
                whatCard -= cardList[i].prob;
            }
        }
        return null;
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

    public void removeCards()
    {
       // cards.Remove()
    }

    public List<Card> getCardList()
    {
        return cards;
    }




}


