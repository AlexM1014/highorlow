using Unity.VisualScripting;
using UnityEngine;

public class DeckAnimation : MonoBehaviour
{
    public Animator drawAnimator;

    public bool draw;
    public bool discard;

    public void animateDraw()
    {
        drawAnimator.SetBool("Draw", true);
        drawAnimator.SetBool("Discard", false);
    }

    public void animateDiscard()
    {
        drawAnimator.SetBool("Discard", true);
        drawAnimator.SetBool("Draw", false);
    }

}
