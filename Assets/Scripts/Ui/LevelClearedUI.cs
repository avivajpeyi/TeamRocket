
using Character;
using UnityEngine;

public class LevelClearedUI : MonoBehaviour
{
    public CharacterFaceManager characterFaceManager;
    public GameObject levelClearedCanvas;

    private bool LevelCLearUiBeingDisplayed = false;
    
    private void Start()
    {
        characterFaceManager = FindObjectOfType<CharacterFaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterFaceManager.allSidesColoured && !LevelCLearUiBeingDisplayed)
        {
            TriggerLevelCompleteSequence();

        }
    }

    void TriggerLevelCompleteSequence()
    {
        LevelCLearUiBeingDisplayed = true;
        levelClearedCanvas.SetActive(true);
    }
}
