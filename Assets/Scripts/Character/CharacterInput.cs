using UnityEngine;

namespace Character
{
    public class CharacterInput : MonoBehaviour
    {
        public KeyCode downKey;
        private bool input = true;
        public KeyCode leftKey;
        public KeyCode rightKey;

        public KeyCode upKey;


        public bool AmIReadyForInput()
        {
            return input;
        }

        public void PreventFurthurInput()
        {
            input = false;
        }

        public void SetReadyForInput()
        {
            input = true;
        }
    }
}