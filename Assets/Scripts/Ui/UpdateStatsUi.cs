using Character;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class UpdateStatsUi : MonoBehaviour
    {
        public TMP_Text pointsText;
        public TMP_Text numStepsText;
        public CharacterMaster characterMaster;

        private void Start()
        {
        
        
        }


        // Update is called once per frame
        void Update()
        {
            numStepsText.text = characterMaster.numberStepsTaken.ToString().PadLeft(4,'0');
            pointsText.text = characterMaster.numPoints.ToString().PadLeft(4,'0');
        }
    }
}
