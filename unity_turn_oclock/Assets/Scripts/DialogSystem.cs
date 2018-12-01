using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    string[] namesLose;
    string[] namesWin;

    private Text text;

    private string lastWin, lastLose;

    void Start()
    {
        text = GetComponent<Text>();
        namesLose = new string[]
        {
            "Waste of time", "Could make a tea", "Slowpoke", "What time is it?", "Do something useful",
            "Set alarm next time", "Too late", "Count to 60", "Time's up", "Not so fast", "Next time", "Past hurts",
            "Millenium!", "Time is money, so...", "Try to lose again", "Already predicted", "Not so fast",
            "Ah, another loss", "Wasted", "Loss is your fate", "Just end this", "1 more time?", "Bad luck",
            "As planned", "Try again?", "As foretold"
        };
        namesWin = new string[]
        {
            "Good timing", "From AM to PM", "Satisfied?", "Tick-Tock, next clock", "Time flows...", "Wow",
            "Switching to next level", "As scheduled", "New start"
        };
    }

    public void RandomWin()
    {
        string newWin;
        do
        {
            newWin = namesWin[Random.Range(0, namesWin.Length)];
        } while (newWin == lastWin);

        lastWin = newWin;
        text.text = lastWin;
    }
    
    public void RandomLose()
    {
        string newLose;
        do
        {
            newLose = namesLose[Random.Range(0, namesLose.Length)];
        } while (newLose == lastLose);

        lastLose = newLose;
        text.text = lastLose;
    }
}