using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRunner : MonoBehaviour
{
    public string[] TutorialText;
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
        if (TextRunning && Input.anyKeyDown)
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
