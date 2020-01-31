using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Material normalMaterial;
    
    public Material player1GoalMaterial;
    public Material player1NormalMaterial;
    
    public Material player2GoalMaterial;
    public Material player2NormalMaterial;

    public static readonly string player1Tag = "Player1";
    public static readonly string player2Tag = "Player2";
    public static readonly string tile_tag = "Tile";
    public static readonly string goal_player1_tag = "Goal1";
    public static readonly string goal_player2_tag = "Goal2";
    
    public Material GetNormalColor(string tag)
    {
        if (tag.Equals(player1Tag))
            return player1NormalMaterial;
        if (tag.Equals(player2Tag))
            return player2NormalMaterial;
        throw new Exception("Invalid tag passed: "+ tag);
    }
    
    public Material GetGoalColor(string tag)
    {
        if (tag.Equals(player1Tag))
            return player1GoalMaterial;
        if (tag.Equals(player2Tag))
            return player2GoalMaterial;
        throw new Exception("Invalid tag passed: "+ tag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
