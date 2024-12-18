using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards;
    int index = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            makeDeck();
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
           GoDownDeck();
        }
    }

    public void makeDeck()
    {
        for (int s = 0; s < 4; s++)
        {
            for (int n = 1; n <= 13; n++)
            {
                cards.Add(new Card(s, n));
            }
        }

        Debug.Log("Test Grab: " + cards[24].cardSuit + " Value:" + cards[24].numValue);
        Debug.Log("Test Grab: " + cards[12].cardSuit + " Value:" + cards[12].numValue);
        Debug.Log("Test Grab: " + cards[3].cardSuit + " Value:" + cards[3].numValue);
    }

    public void GoDownDeck()
    {

        Debug.Log("Test Grab: " + cards[index].cardSuit + " Value:" + cards[index].numValue);
        index++;
    }


}
