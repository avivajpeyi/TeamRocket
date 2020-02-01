using Character;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class UpdateStatsUi : MonoBehaviour
    {
        public CharacterMaster characterMaster;
        public TMP_Text numStepsText;
        public TMP_Text pointsText;

        private void Start()
        {
        }


        // Update is called once per frame
        private void Update()
        {
            numStepsText.text = characterMaster.numberStepsTaken.ToString().PadLeft(4, '0');
            pointsText.text = characterMaster.numPoints.ToString().PadLeft(4, '0');
        }
    }
}