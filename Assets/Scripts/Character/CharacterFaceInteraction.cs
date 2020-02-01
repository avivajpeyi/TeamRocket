using System;
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
                        ResetCurrentTile(currentGoalTile: other.gameObject);
                    }
                }
                else // in multiplayer mode
                {
                    if (isActive)
                    {
                        Celebrate();
                        m_TileMaster.AssignSingleGoalTile(playerTag: m_Master.myTag);
                        ResetCurrentTile(currentGoalTile: other.gameObject);
                    }
                }
            }
        }

        private void Celebrate()
        {
            m_Sound.PlayChord();
            m_Master.numPoints++;
        }


        private void ResetCurrentTile(GameObject currentGoalTile)
        {
            // reset the currentGoal tile (no longer a goal)
            TileController currentTc = currentGoalTile.GetComponent<TileController>();
            currentTc.ResetTile();
        }


        private void StealColour(GameObject currentGoalTile)
        {
            // steal colour
            m_Renderer.material = currentGoalTile.GetComponent<Renderer>().material;
            hasColour = true;
        }
    }
}