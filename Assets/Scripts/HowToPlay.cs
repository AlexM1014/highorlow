using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class HowToPlay : MonoBehaviour
{

    public GameObject howToPlayPanel;
    public List<GameObject> instructionPanels;
    public Button howToPlayButton;

    public int scrollInt = 0;

    public void openHowToPlay()
    {
        if(!howToPlayPanel.activeSelf)
        {
            howToPlayPanel.SetActive(true);
            scrollInt = 0;
            instructionDisplay(scrollInt);
            howToPlayButton.enabled = false;
        }
    }

    public void closeHowToPlay()
    {
        howToPlayPanel.SetActive(false);
        howToPlayButton.enabled = true;
    }

    public void Scroll(bool forward)
    {
        instructionPanels[scrollInt].SetActive(false);

        if(forward)
        {
            if(scrollInt + 1 == instructionPanels.Count)
            {
                scrollInt = 0;
            }
            else
            {
                scrollInt += 1;
            }

            instructionPanels[scrollInt].SetActive(true);
        }

        else
        {
            if (scrollInt - 1 < 0)
            {
                scrollInt = instructionPanels.Count-1;
            }
            else
            {
                scrollInt -= 1;
            }

            instructionPanels[scrollInt].SetActive(true);
        }
    }

    public void instructionDisplay(int scrollIndex)
    {
        instructionPanels[scrollIndex].SetActive(true);
    }

}
