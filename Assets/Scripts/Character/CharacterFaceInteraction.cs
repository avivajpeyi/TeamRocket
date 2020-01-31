using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFaceInteraction : MonoBehaviour
{
    private string tile_tag = "Tile";
    private string goal_tag = "Goal";
    public CharacterMaster characterMaster;

    private TileMaster m_TileMaster;
    private void Start()
    {
        m_TileMaster = FindObjectOfType<TileMaster>();
    }

    void OnTriggerEnter(Collider other) {
        
        if (other.gameObject.CompareTag(goal_tag))
        {
            TileController tileController =other.GetComponent<TileController>();
            tileController.SetGoal(false);
            characterMaster.numPoints++;
            m_TileMaster.AssignNewGoal();
        }
    }
    
}
