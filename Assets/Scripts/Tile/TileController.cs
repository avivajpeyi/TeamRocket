using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private GameManager m_GameManager;
    private Material m_Player2GoalMaterial;
    private Material m_Player1GoalMaterial;
    private Material m_NormalMaterial;


    
    public Renderer myRender;

    private Material myMaterial;
    private bool goalTile = false;

    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        m_Player1GoalMaterial = m_GameManager.GetGoalColor(GameManager.player1Tag);
        m_Player2GoalMaterial = m_GameManager.GetGoalColor(GameManager.player2Tag);
        m_NormalMaterial = m_GameManager.normalMaterial;
        
        myMaterial = myRender.material;
        myRender.material = m_NormalMaterial;
        this.gameObject.tag=GameManager.tile_tag;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    public void SetGoal(bool goal, string playerTag)
    {
        goalTile = goal;
        
        if (goalTile)
        {
            if (playerTag.Equals(GameManager.player1Tag))
            {
                myRender.material = m_Player1GoalMaterial;
                this.gameObject.tag=GameManager.goal_player1_tag;
            }
            else if (playerTag.Equals(GameManager.player2Tag))
            {
                myRender.material = m_Player2GoalMaterial;
                this.gameObject.tag=GameManager.goal_player2_tag;
            }

        }
        else
        {
            myRender.material = m_NormalMaterial;
            this.gameObject.tag=GameManager.tile_tag;
        }

        Debug.Log("Set " + this.name + " as " +gameObject.tag +" and color to "+ myRender
        .material );
    }
}