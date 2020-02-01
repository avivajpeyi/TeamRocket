using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public TutorialRunner TR;
    public GameObject GameUI;
    public GameObject StartUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Called via unity button
    /// </summary>
    public void Play()
    {
        StartCoroutine(StartPlay());
    }

    IEnumerator StartPlay()
    {
        GameUI.SetActive(true);
        StartUI.SetActive(false);
        yield return new WaitForSeconds(1);
        TR.StartRunningText();
    }
    
}
