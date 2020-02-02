using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public TutorialRunner TR;
    public GameObject GameUI;
    public GameObject StartUI;
    public GameObject FinishUI;
    
    private Camera myCam;
    
    // Start is called before the first frame update
    void Start()
    {
        myCam = FindObjectOfType<Camera>();
        GameUI.GetComponent<Canvas>().worldCamera = myCam;
        StartUI.GetComponent<Canvas>().worldCamera = myCam;
        FinishUI.GetComponent<Canvas>().worldCamera = myCam;
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
        GameManager.instance.TogglePlayersActive(true);
        yield return new WaitForSeconds(1);
        TR.StartRunningText();
    }
    
}
