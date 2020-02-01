﻿using System;
using Tile;
using UnityEngine;

namespace Character
{
    public class CharacterFaceInteraction : MonoBehaviour
    {
        private CharacterMaster m_Master;
        private CharacterSoundManager m_Sound;
        private TileMaster m_TileMaster;
        private GameManager m_GameManager;
        private Renderer m_Renderer;

        private string myTag;
        public bool hasColour = false;
        public bool isActive = true; // not all faces activated in multiplayer mode! 


        private void Start()
        {
            // external finds
            m_TileMaster = FindObjectOfType<TileMaster>();
            m_GameManager = FindObjectOfType<GameManager>();

            // things that belong to me
            m_Master = transform.root.GetComponent<CharacterMaster>();
            m_Sound = transform.root.GetComponent<CharacterSoundManager>();
            m_Renderer = GetComponent<Renderer>();
            myTag = transform.root.tag;
        }

        private void OnTriggerEnter(Collider other)
        {
            
            if (other.gameObject.CompareTag(m_Master.myGoalTag))
            {
                Debug.Log("Character Collision!");
                // yayyy! I have gotten to my target!
                if (m_GameManager.singlePlayerGameMode)
                {
                    if (!hasColour)
                    {
                        Celebrate();
                        StealColour(currentGoalTile: other.gameObject);
                    }
                }
                else // in multiplayer mode
                {
                    if (isActive)
                    {
                        Celebrate();
                        SetNewGoalTile(currentGoalTile: other.gameObject);
                    }
                }
            }
        }

        private void Celebrate()
        {
            m_Sound.PlayChord();
            m_Master.numPoints++;
        }


        private void SetNewGoalTile(GameObject currentGoalTile)
        {
            
            currentGoalTile.GetComponent<TileController>().SetGoal(
                m_GameManager.GetGoalColor(myTag), 
                newTileTag: myTag
                );
            m_TileMaster.AssignSingleGoalTile(m_Master.myTag);
        }


        private void StealColour(GameObject currentGoalTile)
        {
            m_Renderer.material = currentGoalTile.GetComponent<Renderer>().material;
            hasColour = true;
        }
    }
}