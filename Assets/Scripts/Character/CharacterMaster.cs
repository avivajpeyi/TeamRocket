﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMaster : MonoBehaviour
{
    public int numberStepsTaken=0;
    public int numPoints = 0;
    
    public string myTag;
    public string myGoalTag;

    void Start()
    {
        myTag = this.gameObject.tag;
    }
}
