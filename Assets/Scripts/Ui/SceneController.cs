using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
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
        if (GameUI != null)
        {
            GameUI.GetComponent<Canvas>().worldCamera = myCam;
        }
        if (StartUI != null)
        {
            StartUI.GetComponent<Canvas>().worldCamera = myCam;
        }
        if (FinishUI != null)
        {
            FinishUI.GetComponent<Canvas>().worldCamera = myCam;
        }
    }


    /// <summary>
    /// Called via unity button
    /// </summary>
    public void Play()
    {
        StartCoroutine(StartPlay());
    }

    public void Update()
    {
        if (Input.GetKeyDown("r")) { //If you press R
            RestartScene();
        }
        else if (Input.GetKeyDown("`")) { 
            LoadStartScene();
        }
    }

    IEnumerator StartPlay()
    {
        GameUI.SetActive(true);
        StartUI.SetActive(false);
        GameManager.instance.TogglePlayersActive(true);
        yield return new WaitForSeconds(1);
        if (TR !=null &&  TR.isActiveAndEnabled) 
            TR.StartRunningText();
    }

    public void NextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }

    public void LoadSinglePlayerScene()
    {
        PlayerPrefs.SetInt("totalscore", 0);
        SceneManager.LoadScene("Level1");
    }

    public void LoadMultiplayerScene()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Load scene called Game
    }

}
