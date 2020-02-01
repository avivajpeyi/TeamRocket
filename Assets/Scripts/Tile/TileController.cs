using UnityEngine;

namespace Tile
{
    public class TileController : MonoBehaviour
    {
        public bool characterMovingOn;
        private bool goalTile;

        public bool isOccupied;
        private GameManager m_GameManager;
        private Material m_NormalMaterial;
        private Material m_Player1GoalMaterial;
        private Material m_Player2GoalMaterial;

        private Material myMaterial;


        public Renderer myRender;

        private void OnDrawGizmos()
        {
            if (isOccupied)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.position + Vector3.up * 0.2f, 0.1f);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(transform.position + Vector3.up * 0.2f, 0.1f);
                ;
            }
        }


        // Start is called before the first frame update
        private void Start()
        {
            m_GameManager = FindObjectOfType<GameManager>();
            if (m_GameManager == null)
                Debug.Log("No GM Found");

            if (!m_GameManager.singlePlayerGameMode){
                m_Player1GoalMaterial = m_GameManager.GetGoalColor(GameManager.player1Tag);
                m_Player2GoalMaterial = m_GameManager.GetGoalColor(GameManager.player2Tag);
            }
            if (this.GetComponent<GoalTile>() != null)
                m_NormalMaterial = m_GameManager.normalMaterial;

            myMaterial = myRender.material;
            myRender.material = m_NormalMaterial;
            gameObject.tag = GameManager.tile_tag;
        }

        // Update is called once per frame
        private void Update()
        {
            checkIfOccupied();
        }

        private void checkIfOccupied()
        {
            if (Physics.Raycast(
                transform.position,
                Vector3.up,
                1)
            )
            {
                if (characterMovingOn) 
                    characterMovingOn = false;
            }
            else
            {
                if (!characterMovingOn)
                    isOccupied = false;
            }
        }

        //Old - original goal logic for moving coloured tile 
        public void SetGoal(bool goal, string playerTag)
        {
            goalTile = goal;

            if (goalTile)
            {
                if (playerTag.Equals(GameManager.player1Tag))
                {
                    myRender.material = m_Player1GoalMaterial;
                    gameObject.tag = GameManager.goal_player1_tag;
                }
                else if (playerTag.Equals(GameManager.player2Tag))
                {
                    myRender.material = m_Player2GoalMaterial;
                    gameObject.tag = GameManager.goal_player2_tag;
                }
            }
            else
            {
                myRender.material = m_NormalMaterial;
                gameObject.tag = GameManager.tile_tag;
            }

            Debug.Log("Set " + name + " as " + gameObject.tag + " and color to " + myRender
                          .material);
        }
    }
}