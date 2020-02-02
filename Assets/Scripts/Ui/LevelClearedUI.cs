using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class LevelClearedUI : MonoBehaviour
{
    public CharacterFaceManager characterFaceManager;
    public GameObject levelClearedCanvas;


    private void Start()
    {
        characterFaceManager = FindObjectOfType<CharacterFaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterFaceManager.allSidesColoured)
            levelClearedCanvas.SetActive(true);
        
    }
}
