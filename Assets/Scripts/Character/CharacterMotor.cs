using System;
using System.Collections;
using System.Collections.Generic;
using Tile;
using UnityEngine;

namespace Character
{
    public class CharacterMotor : MonoBehaviour
    {
        public GameObject down;
        public GameObject left;
        public GameObject up;
        public GameObject right;
        public GameObject center;
        public GameObject playerRenderer;
        public Collider myCollider;

        private CharacterSoundManager _sounds;
        private CharacterInput _input;
        private CharacterMaster _master;
        private TileController _currentTile;
        private Dictionary<Direction, Key> _keys;

        public int Speed;
        
        private void Start()
        {
            _master = GetComponent<CharacterMaster>();
            _input = GetComponent<CharacterInput>();
            _sounds = GetComponent<CharacterSoundManager>();
            _keys = new Dictionary<Direction, Key>
            {
                [Direction.Up] = new Key(_input.upKey, Direction.Up, Vector3.forward, Vector3.right, () => up.transform.position),
                [Direction.Down] = new Key(_input.downKey, Direction.Down, Vector3.back, Vector3.left, () => down.transform.position),
                [Direction.Left] = new Key(_input.leftKey, Direction.Left, Vector3.left, Vector3.forward, () => left.transform.position),
                [Direction.Right] = new Key(_input.rightKey, Direction.Right, Vector3.right, Vector3.back, () => right.transform.position),
            };
            _currentTile = getTile();
            _currentTile.isOccupied = true;
        }

        private void Update()
        {
            if (!_input.ReadyForInput) return;

            // TODO: how to handle 2 keys pressed? up/down has priority over left/right
            foreach (var keyValuePair in _keys)
            {
                if (Input.GetKey(keyValuePair.Value.Code))
                {
                    StartCoroutine(Move(keyValuePair.Value.Direction));
                    break;
                }
            }
        }

        private TileController getTile(Direction? direction = null)
        {
            Vector3 vector = direction == null ? Vector3.zero : _keys[(Direction) direction].Tile;
            // cast a ray down from raycast start point
            var raycastStartPoint = myCollider.transform.position + vector * GameManager.block_width;
            var didHit = Physics.Raycast(raycastStartPoint, Vector3.down, out var hit,
                GameManager.block_width, 1 << 8 /* floor layer */);

            return didHit ? hit.collider.GetComponent<TileController>() : null;
        }

        private IEnumerator Move(Direction direction)
        {
            var nextTile = getTile(direction);
            if (nextTile == null || nextTile.isOccupied) yield break;
            _sounds.PlayNote();
            _input.PreventFurtherInput();
            nextTile.isOccupied = true;
            _master.numberStepsTaken++;
            
            float angleRotated = 0;
            while (angleRotated < 90)
            {
                var angleDelta = Speed * Time.deltaTime;
                if (angleRotated + angleDelta > 90) angleDelta = 90 - angleRotated; //Make sure we don't rotate over 90
                playerRenderer.transform.RotateAround(_keys[direction].RotateAxis(), _keys[direction].Move, angleDelta);
                angleRotated += angleDelta;
                yield return null;
            }

            center.transform.position = playerRenderer.transform.position;
            _currentTile.isOccupied = false;
            _currentTile = nextTile;
            _input.SetReadyForInput();
        }
    }

    internal enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    internal class Key
    {
        public readonly KeyCode Code;
        public readonly Direction Direction;
        public readonly Vector3 Tile;
        public readonly Vector3 Move;
        public readonly Func<Vector3> RotateAxis;

        public Key(KeyCode code, Direction direction, Vector3 tile, Vector3 move, Func<Vector3> rotateAxis)
        {
            Code = code;
            Direction = direction;
            Tile = tile;
            Move = move;
            RotateAxis = rotateAxis;
        }
    }
}