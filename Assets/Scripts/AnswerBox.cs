using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBox : MonoBehaviour
{
    public GameObject answerGraphic;
    public GameObject resetGraphic;
    public Image answerImage;
    public TextMeshProUGUI answerText;

    public Color correctColor;
    public Color incorrectColor;
    public Color alertColor;

    public void toggleCorrect()
    {
        answerGraphic.SetActive(true);
        answerImage.color = correctColor;
        changeBoxText("Correct");
    }

    public void toggleIncorrect()
    {
        answerGraphic.SetActive(true);
        answerImage.color = incorrectColor;
        changeBoxText("Incorrect");
    }

    public void toggleAlert(string alertMessage)
    {
        answerGraphic.SetActive(true);
        answerImage.color = alertColor;
        changeBoxText(alertMessage);
    }

    public void toggleReset()
    {
        resetGraphic.SetActive(true);
    }

    public void changeBoxText(string text)
    {
        answerText.text = text;
    }

    public void toggleBox(bool turnOn, Color inputColor)
    {
        answerGraphic.SetActive(turnOn);
        answerImage.color = inputColor;
    }

    public void disableBox()
    {
        answerGraphic.SetActive(false);
    }
}
