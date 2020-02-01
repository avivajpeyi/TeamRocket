using System.Collections.Generic;
using UnityEngine;

namespace Tile
{
    public class TileMaster : MonoBehaviour
    {
        protected int goalTileIdx;
        protected List<GameObject> myTiles = new List<GameObject>();

        // Start is called before the first frame update
        private void Start()
        {
            foreach (Transform child in transform) myTiles.Add(child.gameObject);

            AssignNewGoal(GameManager.player1Tag);
            AssignNewGoal(GameManager.player2Tag);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        public void AssignNewGoal(string playerTag)
        {
            goalTileIdx = Random.Range(0, myTiles.Count);
            myTiles[goalTileIdx].GetComponent<TileController>().SetGoal(true, playerTag);
        }
    }
}