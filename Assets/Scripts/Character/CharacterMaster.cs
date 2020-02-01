using UnityEngine;

namespace Character
{
    public class CharacterMaster : MonoBehaviour
    {
        public string myGoalTag;

        public string myTag;
        public int numberStepsTaken;
        public int numPoints;

        private void Start()
        {
            myTag = gameObject.tag;
        }
    }
}