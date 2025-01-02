using Unity.VisualScripting;
using UnityEngine;

public class DeckAnimation : MonoBehaviour
{
    public Animator drawAnimator;

    public bool draw;
    public bool discard;
    public GameObject discardBack;

    public AudioSource drawCard;

    public void drawSound()
    {
        drawCard.Play();
    }

    public void animateDraw()
    {
        drawAnimator.SetBool("Draw", true);
        drawAnimator.SetBool("Discard", false);
    }

    public void animateDiscard()
    {
        drawAnimator.SetBool("Discard", true);
        drawAnimator.SetBool("Flip", false);
        
    }

    public void ResetAnimation()
    {
        drawAnimator.SetBool("Draw", false);
        drawAnimator.SetBool("Discard", false);
        drawAnimator.SetBool("Flip", false);
    }

    public void animateRightFlip()
    {
        drawAnimator.SetBool("Flip", true);
        drawAnimator.SetBool("Draw", false);
    }

    public void discardGraphic()
    {
        discardBack.SetActive(true);
    }
}
