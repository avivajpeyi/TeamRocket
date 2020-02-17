using System;
using System.Collections;
using System.Collections.Generic;
using Character;
using UnityEngine;

public class ChangeLightingOnPickup : MonoBehaviour
{
    public CharacterFaceManager CFM;
    private Light light;
    
    // Start is called before the first frame update
    void Start()
    {
        CFM = FindObjectOfType<CharacterFaceManager>();
        CFM.OnPlayerPickedupTile += OnTilePickedUp;
        light = GetComponent<Light>();
    }

    private void OnTilePickedUp(object sender, EventArgs e)
    {
        GameObject go = sender as GameObject;
        light.color = go.GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
