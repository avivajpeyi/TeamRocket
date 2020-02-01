using Tile;
using UnityEngine;

namespace Character
{
    public class CharacterFaceInteraction : MonoBehaviour
    {
        private CharacterMaster characterMaster;
        private CharacterSoundManager characterSoundManager;
        private TileMaster m_TileMaster;

        private void Start()
        {
            characterMaster = gameObject.transform.root.gameObject.GetComponent<CharacterMaster>();
            characterSoundManager = gameObject.transform.GetComponent<CharacterSoundManager>();
            m_TileMaster = FindObjectOfType<TileMaster>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(characterMaster.myGoalTag))
            {
                characterSoundManager.PlayChord();
                var tileController = other.GetComponent<TileController>();
                tileController.SetGoal(false, characterMaster.myTag);
                characterMaster.numPoints++;
                m_TileMaster.AssignNewGoal(characterMaster.myTag);
            }
        }
    }
}