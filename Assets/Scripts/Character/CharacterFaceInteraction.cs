using Tile;
using UnityEngine;

namespace Character
{
    public class CharacterFaceInteraction : MonoBehaviour
    {
        public CharacterMaster characterMaster;

        private TileMaster m_TileMaster;
        private GameManager m_GameManager;
        public bool hasColour = false;


        private void Start()
        {
            m_TileMaster = FindObjectOfType<TileMaster>();
            m_GameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (m_GameManager.singlePlayerGameMode){
                //CharacterFaceManager.SetFaceColour()
            }
            else{
                if (other.gameObject.CompareTag(characterMaster.myGoalTag))
                {
                    var tileController = other.GetComponent<TileController>();
                    tileController.SetGoal(false, characterMaster.myTag);
                    characterMaster.numPoints++;
                    m_TileMaster.AssignNewGoal(characterMaster.myTag);
                }
            }
        }
    }
}