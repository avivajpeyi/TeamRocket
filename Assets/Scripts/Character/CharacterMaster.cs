
using UnityEngine;

namespace Character
{
    public class CharacterMaster : MonoBehaviour
    {
        public string myGoalTag;

        public string myTag;
        public int numberStepsTaken;
        public int numPoints;
        public int totalNumberStepsTaken;

        private void Start()
        {
            myTag = gameObject.tag;
            totalNumberStepsTaken = PlayerPrefs.GetInt("totalscore");
            Debug.Log("Total score " + totalNumberStepsTaken);
        }

        public void UpdateScore()
        {
            totalNumberStepsTaken = PlayerPrefs.GetInt("totalscore");
            totalNumberStepsTaken = totalNumberStepsTaken + numberStepsTaken;
            PlayerPrefs.SetInt("totalscore", totalNumberStepsTaken);
            
        }
    }
}