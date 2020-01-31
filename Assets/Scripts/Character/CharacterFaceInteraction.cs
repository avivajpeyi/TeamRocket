using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFaceInteraction : MonoBehaviour
{

    public CharacterMaster characterMaster;

    private TileMaster m_TileMaster;
    private void Start()
    {
        m_TileMaster = FindObjectOfType<TileMaster>();
    }

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag(characterMaster.myGoalTag))
        {
            TileController tileController =other.GetComponent<TileController>();
            tileController.SetGoal(false, characterMaster.myTag);
            characterMaster.numPoints++;
            m_TileMaster.AssignNewGoal(characterMaster.myTag);
        }
    }
    
}
