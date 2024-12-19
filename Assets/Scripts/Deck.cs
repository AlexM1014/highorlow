using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Deck : MonoBehaviour
{
    public List<Card> cards;
    public List<string> cardNames;

    public List<Card> discardPile;
    public List<string> discardedCardNames;


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
                //to do
                //add in a sprite the card needs
                cards.Add(new Card(suits, value));
            }
        }

        foreach (Card card in cards)
        {
            cardNames.Add(card.cardName);
        }
    }

    public void Draw(out Card CurrentCard)
    {
        //int randomNumber = UnityEngine.Random.Range(0, cards.Count);

        // = cards[randomNumber];
        //cards.RemoveAt(randomNumber);
        if (cards.Count >= 0)
        {
            //it is drawing the same card twice for some reason rather than deleting it??
            //int randCard = UnityEngine.Random.Range(0, cards.Count);
            int randNumber = UnityEngine.Random.Range(0, cards.Count);
            CurrentCard = cards[randNumber];

            //Check if the CurrentCard is already in the discardPile
            DuplicateCheck(CurrentCard.cardName);
            currentCardName = CurrentCard.cardName;

            //Add in drawn card to discardPile
            discardPile.Add(CurrentCard);
            discardedCardNames.Add(CurrentCard.cardName);


            cards.RemoveAt(randNumber);
            cardNames.Remove(cardNames[randNumber]);
        }

        else
        {
            Debug.Log("Deck is empty. Game Over");
            CurrentCard = null;
        }
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
}


