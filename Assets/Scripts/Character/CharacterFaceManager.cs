using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<CharacterFaceInteraction> faceInteractionScripts;
        public bool allSidesColoured = false;

        public EventHandler OnPlayerPickedupTile;

        // Start is called before the first frame update
        private void Start()
        {
            m_CharacterMaster = GetComponent<CharacterMaster>();
            m_GameManager = FindObjectOfType<GameManager>();
            if (!m_GameManager.singlePlayerGameMode){
                Debug.Log("My character's tag: "+ m_CharacterMaster.myTag);
                m_OffMaterial = m_GameManager.GetNormalColor(m_CharacterMaster.myTag);
                m_OnMaterial = m_GameManager.GetGoalColor(m_CharacterMaster.myTag);
            }

            if (faces.Length != 6)
                throw new Exception("Must have 6 faces.");
            ColorFaces();
            faceInteractionScripts = faces.Select(f => f.GetComponent<CharacterFaceInteraction>()).ToList();

            //Passthrough all pickup events into one single event
            foreach (CharacterFaceInteraction face in faceInteractionScripts)
            {
                face.OnTilePickedUp += (sender, args) => OnPlayerPickedupTile?.Invoke(sender, args);
            }
        }

        void Update()
        {
            if (faceInteractionScripts.All(f => f.hasColour)){
                allSidesColoured = true;
            }
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