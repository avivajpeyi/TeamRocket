using System.Collections;
using Tile;
using UnityEngine;

namespace Character
{
    public class CharacterMotor : MonoBehaviour
    {
        public GameObject center;

        private float distToGround;
        public GameObject down;
        private readonly Vector3 downAxis = Vector3.left;
        private bool isGrounded = true;
        private bool isMoving;
        public GameObject left;
        private readonly Vector3 leftAxis = Vector3.forward;
        public Collider myCollider;
        private CharacterInput myInput;

        private CharacterMaster myMaster;
        private Vector3 offset;

        public GameObject playerRenderer;
        public GameObject right;
        private readonly Vector3 rightAxis = Vector3.back;
        public float speed = 0.01f;

        public int step = 9;
        private GameObject tileImOn;
        public GameObject up;
        private readonly Vector3 upAxis = Vector3.right;

        private void Start()
        {
            distToGround = myCollider.bounds.extents.y;
            myMaster = GetComponent<CharacterMaster>();
            myInput = GetComponent<CharacterInput>();
            RaycastHit hit;
            if (Physics.Raycast(center.transform.position, Vector3.down,
                    out hit, GameManager.block_width, 1 << 8))
                // center.transform.position, direction: Vector3.down, out hit, GameManager.block_width)
            {
                Debug.Log("Hit " + hit.collider.name);
                if (hit.collider.GetComponent<TileController>() != null)
                    tileImOn = hit.collider.GetComponent<TileController>().gameObject;
            }
        }

        private void OnDrawGizmos()
        {
            if (isMoving)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f, 0.1f);
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.position + Vector3.up * 0.5f, 0.1f);
                ;
            }
        }


        /// <summary>
        ///     Checks if the tile in "direction" ahead of the cube is occupied or not.
        ///     If occupied, returns false
        ///     If not occupied, returns true
        ///     If nothing present, returns false
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private bool CheckAndSetTileOccupied(Vector3 direction)
        {
            // cast a ray down from raycast start point
            var raycastStartPoint =
                myCollider.transform.position + direction * GameManager.block_width;

            RaycastHit hit;


            if (Physics.Raycast(raycastStartPoint, Vector3.down, out hit,
                GameManager.block_width))
            {
                Debug.Log("Hit the following: " + hit.collider.gameObject.name);
                // from hit info see if already occupied
                if (hit.collider.GetComponent<TileController>() != null)
                {
                    // if not occupied, set to occupied
                    var tileController =
                        hit.collider.GetComponent<TileController>();
                    Debug.Log("tile occupied: " + tileController.isOccupied);
                    if (tileController.isOccupied)
                        return false;
                    tileController.isOccupied = true;
                    tileController.characterMovingOn = true;
                    tileImOn = hit.collider.gameObject;
                    return true;
                }
            }

            return false;
        }


        private bool IsGrounded()
        {
            if (myCollider.gameObject.transform.position.y < distToGround)
                isGrounded = false;
            else
                isGrounded = true;
            return isGrounded;
        }


        private void Update()
        {
            if (myInput.AmIReadyForInput() && IsGrounded())
            {
                if (Input.GetKey(myInput.upKey) && CheckAndSetTileOccupied(Vector3.forward))
                {
                    isMoving = true;
                    StartCoroutine(nameof(MoveUp));
                    myInput.PreventFurthurInput();
                }
                else if (Input.GetKey(myInput.downKey) &&
                         CheckAndSetTileOccupied(Vector3.back))
                {
                    isMoving = true;
                    StartCoroutine(nameof(MoveDown));
                    myInput.PreventFurthurInput();
                }
                else if (Input.GetKey(myInput.leftKey) &&
                         CheckAndSetTileOccupied(Vector3.left))
                {
                    isMoving = true;
                    StartCoroutine(nameof(MoveLeft));
                    myInput.PreventFurthurInput();
                }
                else if (Input.GetKey(myInput.rightKey) &&
                         CheckAndSetTileOccupied(Vector3.right))
                {
                    isMoving = true;
                    StartCoroutine(nameof(MoveRight));
                    myInput.PreventFurthurInput();
                }
            }
        }


        /// <summary>
        ///     The cube gets offsetted when you start moving it.
        ///     This was trying to fix this.
        ///     not working yet...
        /// </summary>
        private void SnapToTileIAmOn()
        {
            playerRenderer.transform.position = new Vector3(
                tileImOn.transform.position.x,
                playerRenderer.transform.position.y,
                tileImOn.transform.position.z
            );

            center.transform.position = playerRenderer.transform.position;
            transform.root.transform.position = playerRenderer.transform.position;
        }

        private IEnumerator MoveUp()
        {
            myMaster.numberStepsTaken++;
            for (var i = 0; i < 90 / step; i++)
            {
                playerRenderer.transform.RotateAround(up.transform.position, upAxis,
                    step);
                yield return new WaitForSeconds(speed);
            }

            center.transform.position = playerRenderer.transform.position;
            myInput.SetReadyForInput();
            isMoving = false;
        }

        private IEnumerator MoveDown()
        {
            myMaster.numberStepsTaken++;
            for (var i = 0; i < 90 / step; i++)
            {
                playerRenderer.transform.RotateAround(down.transform.position, downAxis,
                    step);
                yield return new WaitForSeconds(speed);
            }

            center.transform.position = playerRenderer.transform.position;
            myInput.SetReadyForInput();
            isMoving = false;
        }


        private IEnumerator MoveLeft()
        {
            myMaster.numberStepsTaken++;
            for (var i = 0; i < 90 / step; i++)
            {
                playerRenderer.transform.RotateAround(left.transform.position,
                    leftAxis, step);
                yield return new WaitForSeconds(speed);
            }

            center.transform.position = playerRenderer.transform.position;
            myInput.SetReadyForInput();
            isMoving = false;
        }


        private IEnumerator MoveRight()
        {
            myMaster.numberStepsTaken++;
            for (var i = 0; i < 90 / step; i++)
            {
                playerRenderer.transform.RotateAround(right.transform.position, rightAxis,
                    step);
                yield return new WaitForSeconds(speed);
            }

            transform.position = new Vector3(tileImOn.transform.position.x, transform
                .position.y, tileImOn.transform.position.z);

            center.transform.position = playerRenderer.transform.position;
            myInput.SetReadyForInput();
            isMoving = false;
        }
    }
}