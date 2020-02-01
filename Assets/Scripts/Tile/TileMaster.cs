using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

namespace Tile
{
    public class TileMaster : MonoBehaviour
    {
        private GameManager m_GameManager;
        private int m_GoalTileIdx;
        private List<GameObject> myTiles = new List<GameObject>();

        // the target tiles that will be coloured for the single player puzzle
        // if not populated, will be populated randomly with tiles from myTiles 
        public List<GameObject> myTargetTiles;

        // Start is called before the first frame update
        private void Start()
        {
            m_GameManager = FindObjectOfType<GameManager>();
            InitialiseChildTiles();
            AssignGoalsBasedOnGameMode();
        }

        private void InitialiseChildTiles()
        {
            // set the child tiles initial materials
            foreach (Transform child in transform)
            {
                GameObject tile = child.gameObject;
                Renderer tileRenderer = tile.GetComponent<Renderer>();
                tileRenderer.material = m_GameManager.tileNormalMaterial;
                myTiles.Add(tile);
            }
        }

        private void AssignGoalsBasedOnGameMode()
        {
            if (m_GameManager.singlePlayerGameMode)
            {
                AssignSixGoalTiles();
            }
            else
            {
                AssignSingleGoalTile(GameManager.player1Tag);
                AssignSingleGoalTile(GameManager.player2Tag);
            }
        }


        public void AssignSixGoalTiles()
        {
            if (myTargetTiles.Count == 0)
            {
                myTargetTiles = GenerateSixRandomTileList();
            }

            for (int i =0; i < 6; i ++ ) 
            {
                TileController tileController = myTargetTiles[i].GetComponent<TileController>();
                tileController.SetGoal(
                    tileMaterial:m_GameManager.playerGoalMaterials[i],
                    newTileTag:GameManager.goal_player1_tag
                    );
            }
        }

        public void AssignSingleGoalTile(string playerTag)
        {
            m_GoalTileIdx = Random.Range(0, myTiles.Count);
            TileController tileController = myTiles[m_GoalTileIdx].GetComponent<TileController>();
            tileController.SetGoal(
                tileMaterial: m_GameManager.GetGoalColor(playerTag),
                newTileTag: m_GameManager.GetGoalTag(playerTag)
                );
        }


        private List<GameObject> GenerateSixRandomTileList()
        {
            List<int> uniqueNumbers = new List<int>();
            List<GameObject> randomTiles = new List<GameObject>();

            // generates a list with unique numbers
            for (int i = 0; i < myTiles.Count; i++)
            {
                uniqueNumbers.Add(i);
            }

            // randomly selects a unique number, adds its corresponding tile 
            for (int i = 0; i < 6; i++)
            {
                int ranNum = uniqueNumbers[Random.Range(0, uniqueNumbers.Count)];
                randomTiles.Add(myTiles[ranNum]);
                uniqueNumbers.Remove(ranNum);
            }

            return randomTiles;
        }
    }
}