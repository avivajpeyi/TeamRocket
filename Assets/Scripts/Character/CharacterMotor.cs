using System;
using System.Collections;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
    private Vector3 offset;

    private CharacterMaster myMaster;
    private CharacterInput myInput;

    public GameObject playerRenderer;
    public GameObject center;
    public GameObject up;
    private Vector3 upAxis = Vector3.right;
    public GameObject down;
    private Vector3 downAxis = Vector3.left;
    public GameObject left;
    private Vector3 leftAxis = Vector3.forward;
    public GameObject right;
    private Vector3 rightAxis = Vector3.back;
    private GameObject tileImOn;

    public int step = 9;
    public float speed = 0.01f;
    private bool input = true;
    private bool isMoving = false;


    private bool isGrounded = true;


    public Collider myCollider;

    void Start()
    {
        distToGround = myCollider.bounds.extents.y;
        myMaster = this.GetComponent<CharacterMaster>();
        myInput = this.GetComponent<CharacterInput>();
        RaycastHit hit;
        if (Physics.Raycast(origin: center.transform.position, direction: Vector3.down,
           out hit, maxDistance: GameManager.block_width,1<<8))
        // center.transform.position, direction: Vector3.down, out hit, GameManager.block_width)
        {
            Debug.Log("Hit "+hit.collider.name);
            if (hit.collider.GetComponent<TileController>() != null)
                tileImOn = hit.collider.GetComponent<TileController>().gameObject;
        }
    }

    float distToGround;

    private void OnDrawGizmos()
    {
        if (isMoving)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(this.transform.position + Vector3.up * 0.5f, 0.1f);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(this.transform.position + Vector3.up * 0.5f, 0.1f);;
        }
    }


    /// <summary>
    /// Checks if the tile in "direction" ahead of the cube is occupied or not.
    /// If occupied, returns false
    /// If not occupied, returns true
    /// If nothing present, returns false
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    bool CheckAndSetTileOccupied(Vector3 direction)
    {
        // cast a ray down from raycast start point
        Vector3 raycastStartPoint =
            myCollider.transform.position + direction * GameManager.block_width;

        RaycastHit hit;


        if (Physics.Raycast(raycastStartPoint, direction: Vector3.down, out hit,
            GameManager.block_width))
        {
            Debug.Log("Hit the following: " + hit.collider.gameObject.name);
            // from hit info see if already occupied
            if (hit.collider.GetComponent<TileController>() != null)
            {
                // if not occupied, set to occupied
                TileController tileController =
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
    

    bool IsGrounded()
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
    /// The cube gets offsetted when you start moving it.
    /// This was trying to fix this.
    /// not working yet...
    /// </summary>
    void SnapToTileIAmOn()
    {
        playerRenderer.transform.position = new Vector3(
            x: tileImOn.transform.position.x,
            y:playerRenderer.transform.position.y,
            z: tileImOn.transform.position.z
            );
        
        center.transform.position = playerRenderer.transform.position;
        transform.root.transform.position = playerRenderer.transform.position;
    }

    IEnumerator MoveUp()
    {
        myMaster.numberStepsTaken++;
        for (int i = 0; i < 90 / step; i++)
        {
            playerRenderer.transform.RotateAround(up.transform.position, upAxis,
                step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = playerRenderer.transform.position;
        myInput.SetReadyForInput();
        isMoving = false;
        
    }

    IEnumerator MoveDown()
    {
        myMaster.numberStepsTaken++;
        for (int i = 0; i < 90 / step; i++)
        {
            playerRenderer.transform.RotateAround(down.transform.position, downAxis,
                step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = playerRenderer.transform.position;
        myInput.SetReadyForInput();
        isMoving = false;
    }


    IEnumerator MoveLeft()
    {
        myMaster.numberStepsTaken++;
        for (int i = 0; i < 90 / step; i++)
        {
            playerRenderer.transform.RotateAround(left.transform.position,
                leftAxis, step);
            yield return new WaitForSeconds(speed);
        }

        center.transform.position = playerRenderer.transform.position;
        myInput.SetReadyForInput();
        isMoving = false;
    }


    IEnumerator MoveRight()
    {
        myMaster.numberStepsTaken++;
        for (int i = 0; i < 90 / step; i++)
        {
            playerRenderer.transform.RotateAround(right.transform.position, rightAxis,
                step);
            yield return new WaitForSeconds(speed);
        }

        transform.position = new Vector3(tileImOn.transform.position.x, this.transform
            .position.y, tileImOn.transform.position.z);

        center.transform.position = playerRenderer.transform.position;
        myInput.SetReadyForInput();
        isMoving = false;
    }
}