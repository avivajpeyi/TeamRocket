using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{

    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    private bool input = true;


    public bool AmIReadyForInput()
    {
        return input;
    }

    public void PreventFurthurInput()
    {
        input = false;
    }

    public void SetReadyForInput()
    {
        input = true;
    }
    
}
