using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFaceManager : MonoBehaviour
{

    public Material offMaterial;
    public Material onMaterial;
    public GameObject[] faces;
    private int faceOn = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (faces.Length != 6)
            throw new Exception("Must have 6 faces.");
        ColorFaces();

    }


    void ColorFaces()
    {
        for (int i = 0; i < faces.Length; i++)
        {
            if (i == faceOn)
                faces[i].GetComponent<Renderer>().material = onMaterial;
            else
                faces[i].GetComponent<Renderer>().material = offMaterial;
        }
    }
}
