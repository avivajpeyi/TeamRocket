using UnityEngine;

namespace Character
{
    public class CharacterMaster : MonoBehaviour
    {
        public int numberStepsTaken;
        public int numPoints;
    
        public string myTag;
        public string myGoalTag;

        void Start()
        {
            myTag = gameObject.tag;
        }
    }
}
