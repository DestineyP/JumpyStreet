using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public int moveBackCounter = 0;
    public Animator anim;
   
    public  GameObject egg;
    
    private float moveSpeed = 3f;
    private float gridSize = 1f;
    private enum Orientation
    {
        Horizontal,
        Vertical
    }
    private Orientation gridOrientation = Orientation.Horizontal;

    private Vector2 MoveDirection;
    private Vector3 startPosition;
    private Vector3 endPosition;
    bool isMoving = false;
    bool canMove;
    bool movedbackwards = false;
    bool moveForward = false;
    bool sideMove = false;

    private void Start()
    {
       canMove = true;
    }
    public void Update()
    {

        if (!isMoving)
        {
            
            MoveDirection = new Vector3(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0);
            
                if (Mathf.Abs(MoveDirection.x) > Mathf.Abs(MoveDirection.y))   ///making sure the player cannot move diagnal
                {
                    MoveDirection.y = 0;
                }
                else
                {
                    MoveDirection.x = 0;
                }
            

            if (MoveDirection != Vector2.zero) ///if the player is trying to move in a direction start moving
            {
                
                StartCoroutine(moveTowardPosition(transform));
                

                if (moveForward == true)
                {
                    
                    gameObject.transform.parent = null; // If attatched to a log, unattaching.
                    Debug.Log("Forward");
                    ScoreKeeper.ScoreScript.AddScore();
                    moveBackCounter = 0;
                    moveForward = false;
                    
                }
                if (movedbackwards == true)
                {
                    gameObject.transform.parent = null;
                    moveBackCounter++;
                    Debug.Log("back");
                    if (moveBackCounter > 3)
                    {
                        egg.SetActive(true);

                    }
                    movedbackwards = false;
                   
                }
                if(sideMove == true)
                {
                    sideMove = false;
                    ScoreKeeper.ScoreScript.AddScore();
                }
      
               
            }
          
        }
    }



    public IEnumerator moveTowardPosition(Transform transform)
    {

        canMove = true;
        isMoving = true;
        startPosition = transform.position;
       float moveTime = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(MoveDirection.x) * gridSize, startPosition.y, startPosition.z + System.Math.Sign(MoveDirection.y) * -gridSize);
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(MoveDirection.x) * gridSize, startPosition.y + System.Math.Sign(MoveDirection.y) * gridSize, startPosition.z);
        }

      float  factor = 1f;


        checkForTrees();
        while (moveTime < 1f && canMove)
        {
            moveTime += Time.deltaTime * (moveSpeed / gridSize) * factor;

            if (canMove)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, moveTime);
            }
           
            
            if (startPosition.x - endPosition.x > 0)
            { 
                movedbackwards = true;
            }
            if (startPosition.x - endPosition.x < 0)
            {
                moveForward = true;
            }
            if(startPosition.z - endPosition.z > 0 || startPosition.z - endPosition.z < 0)
            {
                sideMove = true;
            }
          

            yield return null;

        }

        
       
        Invoke("endMovement", .2f);
       
        yield return 0;
    }



   void endMovement() // Signaling the end of the movment time so the player can move again.
   {
        isMoving = false;
        
   }

    void checkForTrees() // Checking if the ray hits a tree and stoping movement in that direction if it does.
    {

        RaycastHit hit;
        Vector3 direction = (endPosition - startPosition);
        Ray ray = new Ray(startPosition, direction);

        if (!Physics.Raycast(ray, out hit, direction.magnitude))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

        }
        else if (hit.collider.tag == "Tree")
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.blue);
            canMove = false;

        }
    }

}
