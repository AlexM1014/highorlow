using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBox : MonoBehaviour
{
    public GameObject answerGraphic;
    public Image answerImage;
    public TextMeshProUGUI answerText;

    public void toggleBox(bool turnOn, Color inputColor)
    {
        answerGraphic.SetActive(turnOn);
        answerImage.color = inputColor;
    }

    public void disableBox()
    {
        answerGraphic.SetActive(false);
    }

    public void changeBoxText(string text)
    {
        answerText.text = text;
    }
}
