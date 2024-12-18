using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards;
    public List<String> cardNames;
    public List<int> cardValues;
    public List<Card> discardPile;

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
        for (int suits = 0; suits < 4; suits++)
        {
            for (int value = 1; value <= 13; value++)
            {
                //to do
                //add in a sprite the card needs
                Card tempCard = new Card(suits, value);
                cards.Add(tempCard);

                cardNames.Add(tempCard.cardSuit + " " + value);
                //cards.Add(new Card(suits, value));
                
            }
        }
    }

    public void Draw(out Card LeftCard, out Card RightCard)
    {
        if (cards.Count > 0)
        {

            int randomCard = UnityEngine.Random.Range(0, cards.Count);

            //Left Card
            LeftCard = cards[randomCard];
            discardPile.Add(LeftCard);
            cards.Remove(cards[randomCard]);

            //Right Card
            randomCard = UnityEngine.Random.Range(0, cards.Count);

            RightCard = cards[randomCard];
            discardPile.Add(RightCard);
            cards.Remove(cards[randomCard]);
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
                card.image = spadeSprites[card.numValue];
                break;
            case Card.Suit.HEARTS:
                card.image = heartSprites[card.numValue];
                break;
            case Card.Suit.DIAMONDS:
                card.image = diamondSprites[card.numValue];
                break;
            case Card.Suit.CLUBS:
                card.image = clubSprites[card.numValue];
                break;
            default:
                break;
        }
    }
}


