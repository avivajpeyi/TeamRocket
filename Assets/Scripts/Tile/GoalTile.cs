//*
//  THIS IS UNUSED IN THE WORKING VERSION OF THE GAME
//
//*//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

public class GoalTile : MonoBehaviour
{      
    private GameManager m_GameManager;
    private CharacterFaceManager m_CharacterFaceManager;
    void Start()
    {
        m_CharacterFaceManager = FindObjectOfType<CharacterFaceManager>();
        m_GameManager = FindObjectOfType<GameManager>();
        //set 6 goal tiles from available tiles
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collision: other name {other.name}");
        // RaycastHit hit;
        // if (Physics.Raycast(this.transform.position, Vector3.up, out hit, GameManager.block_width/4))
        // {
        // Debug.Log("Found object");
        //var faceGameObject = hit.transform.gameObject;
        if (!other.GetComponent<CharacterFaceInteraction>().hasColour)
        {
            Debug.Log("Needs colour");
            var meshRenderer = this.GetComponent<MeshRenderer>();
            other.GetComponent<MeshRenderer>().material.color = meshRenderer.material.color;
            other.GetComponent<CharacterFaceInteraction>().hasColour = true;
            //this.isGoalTile = false;
            meshRenderer.material.color = Color.grey;
        }
    }
}

