using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class LevelClearedUI : MonoBehaviour
{
    public CharacterFaceManager m_CharacterFaceManager;
    public GameObject LevelClearedPanel;
    
    // Update is called once per frame
    void Update()
    {
        if (m_CharacterFaceManager.allSidesColoured)
            LevelClearedPanel.SetActive(true);
        
    }
}
