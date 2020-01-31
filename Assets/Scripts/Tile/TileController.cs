using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public Material goalMaterial;
    public Material normalMaterial;

    private string tile_tag = "Tile";
    private string goal_tag = "Goal";

    public Renderer myRender;

    private Material myMaterial;
    private bool goalTile = false;

    // Start is called before the first frame update
    void Start()
    {
        myMaterial = myRender.material;
        myRender.material = normalMaterial;
        this.gameObject.tag=tile_tag;
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    public void SetGoal(bool goal)
    {
        goalTile = goal;
        
        if (goalTile)
        {
            myRender.material = goalMaterial;
            this.gameObject.tag=goal_tag;
        }
        else
        {
            myRender.material = normalMaterial;
            this.gameObject.tag=tile_tag;
        }

        Debug.Log("Set " + this.name + " as " +gameObject.tag +" and color to "+ myRender
        .material );
    }
}