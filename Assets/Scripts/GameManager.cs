using System;
using Character;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static readonly string player1Tag = "Player1";
    public static readonly string player2Tag = "Player2";
    public static readonly string tile_tag = "Tile";
    public static readonly string goal_player1_tag = "Goal1";
    public static readonly string goal_player2_tag = "Goal2";

    public static readonly float block_width = 1f;

    public static readonly LayerMask floor_layer_mask = ~(1 << 8);
    public Material normalMaterial;

    public Material player1GoalMaterial;
    public Material player1NormalMaterial;

    public Material player2GoalMaterial;
    public Material player2NormalMaterial;
    public bool singlePlayerGameMode = true;

    public CharacterMotor[] Players;

    public static GameManager instance;

    private void Awake()
    {
        if(!instance) instance = this;
        else
        {
            Debug.Log("you done ducked up");
        }
    }

    private void Start()
    {
        
        
        TogglePlayersActive(false);
    }

    public Material GetNormalColor(string tag)
    {
        if (tag.Equals(player1Tag))
            return player1NormalMaterial;
        if (tag.Equals(player2Tag))
            return player2NormalMaterial;
        throw new Exception("Invalid tag passed: " + tag);
    }

    public Material GetGoalColor(string tag)
    {
        if (tag.Equals(player1Tag))
            return player1GoalMaterial;
        if (tag.Equals(player2Tag))
            return player2GoalMaterial;
        throw new Exception("Invalid tag passed: " + tag);
    }

    public void TogglePlayersActive(bool enabled)
    {
        foreach (CharacterMotor player in Players)
        {
            player.enabled = enabled;
        }
    }
    

    // Update is called once per frame
    private void Update()
    {
    }
}