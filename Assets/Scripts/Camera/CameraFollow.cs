using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool followPlayer = false;
    public GameObject m_Player;
    public Vector3 locationOffset;
    void Start()
    {
        m_Player = GameObject.Find("Mesh");
        locationOffset = new Vector3(
            this.transform.position.x - m_Player.transform.position.x,
            this.transform.position.y - m_Player.transform.position.y,
            this.transform.position.z - m_Player.transform.position.z);

    }


    void FixedUpdate()
    {
        if(followPlayer){
            //Debug.Log($"player transform position iss {m_Player.transform.position}");
            this.transform.position = new Vector3 ( m_Player.transform.position.x + locationOffset.x,
            this.transform.position.y,// = m_Player.transform.position + locationOffset;
             m_Player.transform.position.z + locationOffset.z);
            //this.transform.position = Vector3.SmoothDamp(transform.position, newLocation, ref refV3, 0.1f);
            //Debug.Log($"is now {this.transform.position}");
        }
    }
}
