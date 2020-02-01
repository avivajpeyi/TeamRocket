using Tile;
using UnityEngine;

namespace Character
{
    public class CharacterFaceInteraction : MonoBehaviour
    {
        public CharacterMaster characterMaster;

        private TileMaster m_TileMaster;

        private void Start()
        {
            m_TileMaster = FindObjectOfType<TileMaster>();
        }

        private void OnTriggerEnter(Collider other)
        {
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