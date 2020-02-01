using System;
using UnityEngine;

namespace Tile
{
    public class TileController : MonoBehaviour
    {
        private bool goalTile;

        public bool isOccupied;
        private GameManager m_GameManager;
        private Material m_NormalMaterial;
        private Material m_Player1GoalMaterial;
        private Material m_Player2GoalMaterial;
        public Renderer myRender;

        private void OnDrawGizmos()
        {
            if (isOccupied)
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;

            Gizmos.DrawSphere(transform.position + Vector3.up * 0.2f, 0.1f);
        }

        // Start is called before the first frame update
        private void Start()
        {
            m_GameManager = FindObjectOfType<GameManager>();
            m_NormalMaterial = m_GameManager.tileNormalMaterial;
            ResetTile();
        }

        public void ResetTile()
        {
            myRender.material = m_NormalMaterial;
            gameObject.tag = GameManager.tile_tag;
        }

        public void SetGoal(Material tileMaterial, string newTileTag)
        {
            if (!String.Equals(GameManager.goal_player1_tag, newTileTag) &&
                !String.Equals(GameManager.goal_player2_tag, newTileTag) &&
                !String.Equals(GameManager.tile_tag, newTileTag))
            {
                throw new ArgumentException("Invalid tag passed");
            }
            goalTile = true;
            myRender.material = tileMaterial;
            gameObject.tag = newTileTag;
        }
    }
}