using UnityEngine;

public class GameAudio : MonoBehaviour
{

    public AudioSource drawSound;
    public AudioSource flipSound;
    public AudioSource correct;
    public AudioSource incorrect;

    public void playDrawSound()
    {
        drawSound.Play();
    }

    public void playFlipSound()
    {
        flipSound.Play();
    }

    public void playResultSound(bool correctAnswer)
    {
        if(correctAnswer)
        {
           correct.Play();
        }

        else
        {
            incorrect.Play();
        }
    }
}
