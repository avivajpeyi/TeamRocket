using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Character
{
    public class CharacterMotor : MonoBehaviour
    {
        private Vector3 _offset;

        private CharacterMaster _master;
        private CharacterInput _input;

        public GameObject playerRenderer;
        public GameObject center;
        public GameObject up;
        public GameObject down;
        public GameObject left;
        public GameObject right;

        public int step = 9;
        public float speed = 0.01f;

        private Dictionary<KeyCode, Func<IEnumerator>> _keyMap;

        void Start()
        {
            _master = GetComponent<CharacterMaster>();
            _input = GetComponent<CharacterInput>();
            _keyMap = new Dictionary<KeyCode, Func<IEnumerator>>
            {
                [_input.upKey] = MoveUp,
                [_input.downKey] = MoveDown,
                [_input.leftKey] = MoveLeft,
                [_input.rightKey] = MoveRight
            };
        }

        private void Update()
        {
            if (!_input.AmIReadyForInput()) return;

            // TODO: how to handle 2 keys pressed? up/down has priority over left/right
            var key = _keyMap.FirstOrDefault(keyValuePair => Input.GetKey(keyValuePair.Key));
            if (key.Value != null)
            {
                StartCoroutine(key.Value());
                _input.PreventFurthurInput();
            }
        }

        IEnumerator MoveUp()
        {
            _master.numberStepsTaken++;
            for (int i = 0; i < 90 / step; i++)
            {
                playerRenderer.transform.RotateAround(up.transform.position, Vector3.right, step);
                yield return new WaitForSeconds(speed);
            }

            center.transform.position = playerRenderer.transform.position;
            _input.SetReadyForInput();
        }

        IEnumerator MoveDown()
        {
            _master.numberStepsTaken++;
            for (int i = 0; i < 90 / step; i++)
            {
                playerRenderer.transform.RotateAround(down.transform.position, Vector3.left, step);
                yield return new WaitForSeconds(speed);
            }

            center.transform.position = playerRenderer.transform.position;
            _input.SetReadyForInput();
        }


        IEnumerator MoveLeft()
        {
            _master.numberStepsTaken++;
            for (int i = 0; i < 90 / step; i++)
            {
                playerRenderer.transform.RotateAround(left.transform.position, Vector3.forward, step);
                yield return new WaitForSeconds(speed);
            }

            center.transform.position = playerRenderer.transform.position;
            _input.SetReadyForInput();
        }


        IEnumerator MoveRight()
        {
            _master.numberStepsTaken++;
            for (int i = 0; i < 90 / step; i++)
            {
                playerRenderer.transform.RotateAround(right.transform.position, Vector3.back, step);
                yield return new WaitForSeconds(speed);
            }

            center.transform.position = playerRenderer.transform.position;
            _input.SetReadyForInput();
        }
    }
}