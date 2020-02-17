using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    string[] TutorialText = new string[]
    {
        "Yo Gate!\n[SPACE]",
        "You look like a hep cat",
        "You got your boots on?",
        "Good, let me give you the hard spiel",
        "I ain't no bucket from Nantucket but I got fried last night...",
        "I need to get my groove back, ya dig?",
        "Roll me around this joint and collect my colors",
        "But only one color per side. Groovy?",
        "Groooovayyy"
    };
    private int index;

    public SpeechBubbleRunner SBR;
    public bool TextRunning { get; private set; }
    
    //todo lock input
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (TextRunning && Input.GetButtonDown("Jump"))
        {
            AdvanceStep();
        }
    }

    private void AdvanceStep()
    {
        if (index < TutorialText.Length)
        {
            SBR.ShowText(TutorialText[index]);
            index++;
        }
        else
        {
            SBR.Hide();
        }
    }

    public void StartRunningText()
    {
        TextRunning = true;
        AdvanceStep();
    }
}
