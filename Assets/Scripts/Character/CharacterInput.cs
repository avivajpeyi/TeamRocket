using UnityEngine;

namespace Character
{
    public class CharacterInput : MonoBehaviour
    {
        public KeyCode downKey;
        public KeyCode leftKey;
        public KeyCode rightKey;
        public KeyCode upKey;

        public bool ReadyForInput { get; private set; } = true;

        public void PreventFurtherInput()
        {
            ReadyForInput = false;
        }

        public void SetReadyForInput()
        {
            ReadyForInput = true;
        }
    }
}