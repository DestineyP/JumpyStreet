using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public static MovementScript MoveScript;
    bool movedbackwards = false;
    
    bool moveForward = false;
    
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
    private float moveTime;
    private float factor;
    private bool isMoving = false;
    public bool canMove;
    

    Vector3 sidemove;

    private void Start()
    {
        MoveScript = this;
        
        
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
            

            if (MoveDirection != Vector2.zero) ///if the player is trying to move in a direction start the move corutine
            {
                
                StartCoroutine(moveTowardPosition(transform));
                

                if (moveForward == true)
                {
                    
                    gameObject.transform.parent = null; // If attatched to a log, unattaching.
                    Debug.Log("Forward");
                    //transform.rotation = Quaternion.LookRotation(MoveDirection);
                    ScoreKeeper.ScoreScript.AddScore();
                    moveBackCounter = 0;
                    moveForward = false;
                    
                }
                if (movedbackwards == true)
                {
                    gameObject.transform.parent = null;
                    moveBackCounter++;
                   // transform.rotation = Quaternion.LookRotation(MoveDirection);
                    Debug.Log("back");
                    if (moveBackCounter > 3)
                    {
                        egg.SetActive(true);
                       
                    }
                    movedbackwards = false;
                  
                }
      
               
            }
          
        }
    }



    public IEnumerator moveTowardPosition(Transform transform)
    {
        canMove = true;
        isMoving = true;
        startPosition = transform.position;
        moveTime = 0;

        if (gridOrientation == Orientation.Horizontal)
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(MoveDirection.x) * gridSize, startPosition.y, startPosition.z + System.Math.Sign(MoveDirection.y) * -gridSize);
        }
        else
        {
            endPosition = new Vector3(startPosition.x + System.Math.Sign(MoveDirection.x) * gridSize, startPosition.y + System.Math.Sign(MoveDirection.y) * gridSize, startPosition.z);
        }

        factor = 1f;


       // checkForTrees();
        while (moveTime < 1f)
        {
            moveTime += Time.deltaTime * (moveSpeed / gridSize) * factor;
            checkForTrees();
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
          

            yield return null;

        }

        
       
        Invoke("endMovement", .2f);
       
        yield return 0;
    }



   void endMovement()
   {
        isMoving = false;
        
   }

    void checkForTrees()
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
