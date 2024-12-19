using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards;
    public List<string> cardNames;

    public List<Card> discardPile;
    public List<string> discardedCardNames;


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

        foreach(Card card in cards)
        {
            cardNames.Add(card.cardSuit.ToString() + card.numValue);
        }
    }

    public void Draw(out Card LeftCard, out Card RightCard)
    {
        if (cards.Count > 0)
        {

            int randomCard = UnityEngine.Random.Range(0, cards.Count);

            //Left Card
            LeftCard = cards[randomCard];
            discardedCardNames.Add(LeftCard.cardName);
            discardPile.Add(LeftCard);
            cards.Remove(LeftCard);
            cardNames.Remove(LeftCard.cardName);


            //Right Card
            randomCard = UnityEngine.Random.Range(0, cards.Count);
            RightCard = cards[randomCard];
            discardedCardNames.Add(RightCard.cardName);
            discardPile.Add(RightCard);
            cards.Remove(RightCard);
            cardNames.Remove(RightCard.cardName);
        }

        else
        {
            LeftCard = null;
            RightCard = null;
        }
    }

    public void GenerateCardImage(Card card)
    {
        switch (card.cardSuit)
        {
            case Card.Suit.SPADES:
                card.image = spadeSprites[card.numValue-1];
                break;
            case Card.Suit.HEARTS:
                card.image = heartSprites[card.numValue-1];
                break;
            case Card.Suit.DIAMONDS:
                card.image = diamondSprites[card.numValue-1];
                break;
            case Card.Suit.CLUBS:
                card.image = clubSprites[card.numValue-1];
                break;
            default:
                break;
        }
    }

    public List<Card> getCardList()
    {
        return cards;
    }
}


