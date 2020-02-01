using Tile;
using UnityEngine;

namespace Character
{
    public class CharacterFaceInteraction : MonoBehaviour
    {
        private CharacterMaster characterMaster;
        private CharacterSoundManager characterSoundManager;
        private TileMaster m_TileMaster;
        private GameManager m_GameManager;
        public bool hasColour = false;


        private void Start()
        {
            characterMaster = gameObject.transform.root.gameObject
                .GetComponent<CharacterMaster>();
            characterSoundManager =
                gameObject.transform.GetComponent<CharacterSoundManager>();
            m_TileMaster = FindObjectOfType<TileMaster>();
            m_GameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!m_GameManager.singlePlayerGameMode &&
                other.gameObject.CompareTag(characterMaster.myGoalTag))
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