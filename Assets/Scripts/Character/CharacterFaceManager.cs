using System;
using UnityEngine;

namespace Character
{
    public class CharacterFaceManager : MonoBehaviour
    {
        private CharacterMaster m_CharacterMaster;
        private GameManager m_GameManager;
        private Material m_OffMaterial;
        private Material m_OnMaterial;
        public GameObject[] faces;
        private int faceOn = 0;
    

        // Start is called before the first frame update
        void Start()
        {
            m_CharacterMaster = GetComponent<CharacterMaster>();
            m_GameManager = FindObjectOfType<GameManager>();
            m_OffMaterial = m_GameManager.GetNormalColor(m_CharacterMaster.myTag);
            m_OnMaterial = m_GameManager.GetGoalColor(m_CharacterMaster.myTag);
        
            if (faces.Length != 6)
                throw new Exception("Must have 6 faces.");
            ColorFaces();

        }


        void ColorFaces()
        {
            for (int i = 0; i < faces.Length; i++)
            {
                if (i == faceOn)
                    faces[i].GetComponent<Renderer>().material = m_OnMaterial;
                else
                    faces[i].GetComponent<Renderer>().material = m_OffMaterial;
            }
        }
    }
}
