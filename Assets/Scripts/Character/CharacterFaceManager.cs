using System;
using UnityEngine;

namespace Character
{
    public class CharacterFaceManager : MonoBehaviour
    {
        private readonly int faceOn = 0;
        public GameObject[] faces;
        private CharacterMaster m_CharacterMaster;
        private GameManager m_GameManager;
        private Material m_OffMaterial;
        private Material m_OnMaterial;


        // Start is called before the first frame update
        private void Start()
        {
            m_CharacterMaster = GetComponent<CharacterMaster>();
            m_GameManager = FindObjectOfType<GameManager>();
            m_OffMaterial = m_GameManager.GetNormalColor(m_CharacterMaster.myTag);
            m_OnMaterial = m_GameManager.GetGoalColor(m_CharacterMaster.myTag);

            if (faces.Length != 6)
                throw new Exception("Must have 6 faces.");
            ColorFaces();
        }


        private void ColorFaces()
        {
            for (var i = 0; i < faces.Length; i++)
                if (i == faceOn)
                    faces[i].GetComponent<Renderer>().material = m_OnMaterial;
                else
                    faces[i].GetComponent<Renderer>().material = m_OffMaterial;
        }
    }
}