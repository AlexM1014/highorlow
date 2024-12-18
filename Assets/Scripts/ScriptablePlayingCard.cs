using UnityEngine;

[CreateAssetMenu(fileName = "ScriptablePlayingCard", menuName = "Scriptable Objects/PlayingCard")]
public class ScriptabledPlayingCard : ScriptableObject
{
    public new string name;
    public int numericalValue;
    public Sprite cardImage;
    //Suit Values
    //1 Clubs|2 Diamonds|3 Hearts|4 Spades
    public int suit;

    public int drawChance;
    //random.range
    //check if value is > 0.5 its the correct card
}
