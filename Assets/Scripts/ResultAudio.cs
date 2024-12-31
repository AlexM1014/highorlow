using UnityEngine;

public class ResultAudio : MonoBehaviour
{
    public AudioClip draw;  
    public AudioClip flip;
    public AudioClip correct;
    public AudioClip incorrect;

    public AudioSource audioPlayer;


    public void playResultSound(bool correctAnswer)
    {
        if(correctAnswer)
        {
            audioPlayer.clip = correct;
            audioPlayer.Play();
        }

        else
        {
            audioPlayer.clip = incorrect;
            audioPlayer.Play();
        }
    }
}
