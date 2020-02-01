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

    public bool singlePlayerGameMode = true;

    // materials 
    public Material[] playerGoalMaterials = new Material[6];
    public Material tileNormalMaterial;
    public Material player1GoalMaterial;
    public Material player1NormalMaterial;
    public Material player2GoalMaterial;
    public Material player2NormalMaterial;


    public CharacterMotor[] playerMotors;

    public static GameManager instance;

    private void Awake()
    {
        playerMotors =
            (CharacterMotor[]) GameObject.FindObjectsOfType(typeof(CharacterMotor));

        if (!instance) instance = this;
        else
        {
            Debug.Log("you done ducked up");
        }
    }

    private void Start()
    {
        if (playerGoalMaterials[0] == null ||
            player1GoalMaterial == null ||
            player1NormalMaterial == null ||
            player2GoalMaterial == null ||
            player2NormalMaterial == null ||
            tileNormalMaterial == null ||
            playerMotors[0] == null)
            throw new Exception("The materials are not set for the game manager.");

        TogglePlayersActive(false);
    }

    public Material GetNormalColor(string playerTag)
    {
        if (playerTag.Equals(player1Tag))
            return player1NormalMaterial;
        if (playerTag.Equals(player2Tag))
            return player2NormalMaterial;
        throw new Exception("Invalid tag passed: " + playerTag);
    }

    public Material GetGoalColor(string playerTag)
    {
        if (playerTag.Equals(player1Tag))
            return player1GoalMaterial;
        if (playerTag.Equals(player2Tag))
            return player2GoalMaterial;
        throw new Exception(
            "Invalid tag passed: " + playerTag + ". Expected tags: " +
            player1Tag + " " + player2Tag);
    }


    public string GetGoalTag(string playerTag)
    {
        if (playerTag.Equals(player1Tag))
            return goal_player1_tag;
        if (playerTag.Equals(player2Tag))
            return goal_player2_tag;
        throw new Exception("Invalid tag passed: " + playerTag);
    }

    public void TogglePlayersActive(bool enabled)
    {
        foreach (CharacterMotor player in playerMotors)
        {
            player.enabled = enabled;
        }
    }
}