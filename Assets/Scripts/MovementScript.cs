using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{


    bool movedbackwards = false;
    public int moveBackCounter = 0;
    

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


    public void Update()
    {
       
        if (!isMoving)
        {
            MoveDirection = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
            
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
                if (movedbackwards == false)
                {
                    ScoreKeeper.ScoreScript.AddScore();
                    moveBackCounter = 0;
                }
                else
                {
                    moveBackCounter++;
                    if(moveBackCounter > 3)
                    {
                        Debug.Log("SpawnTheEagle");
                    }
                  
                }
            }
        }
    }

    public IEnumerator moveTowardPosition(Transform transform)
    {

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

        while (moveTime < 1f)
        {
            moveTime += Time.deltaTime * (moveSpeed / gridSize) * factor;

            if(startPosition.x - endPosition.x > 0)
            {
                Debug.Log("MovingBackwards");
                movedbackwards = true;
            }
            else
            {
                movedbackwards = false;
            }
            transform.position = Vector3.Lerp(startPosition, endPosition, moveTime);
            yield return null;
        }

        
       
        Invoke("endMovement", .3f);
       
        yield return 0;
    }



   void endMovement()
   {
        isMoving = false;
   }



}
