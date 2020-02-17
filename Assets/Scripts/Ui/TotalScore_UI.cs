using Character;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class TotalScore_UI : MonoBehaviour
    {
        
        public TMP_Text totalScore;
        public CharacterMaster character;
        public CharacterFaceManager cmf;
        private bool UpdatedUI = false;


        void Update()
        {
            if (!UpdatedUI && cmf.allSidesColoured && cmf.updatedScore )
                SetUpdatedScore();
        }



        // Update is called once per frame
        void SetUpdatedScore()
        {
            UpdatedUI = true;
            totalScore.text = "Total turns = " + character.totalNumberStepsTaken.ToString();
        }
    }
}