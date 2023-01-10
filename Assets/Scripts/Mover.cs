using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Health
{
     // Start is called before the first frame update
    protected BoxCollider2D boxCollider;

    protected Vector3 moveDelta;
    protected Vector3 mousePos;

    protected RaycastHit2D hit;
    protected float ySpeed = 0.50f;
    protected float xSpeed = 0.50f;

    public Camera cam;


    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

 

    public virtual void UpdatedMover(Vector3 input){

        // Reset MoveDelta
        moveDelta = new Vector3(input.x * xSpeed, input.y*ySpeed,0);


        if(gameObject.name == "Player"){

            //FOllow mouse movement to flip
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            Vector3 lookDir = mousePos - transform.position;


            //Swap Sprite Direction, whether you're going right or left
            if(lookDir.x >0 )
                transform.localScale = Vector3.one;
            else if(lookDir.x < 0)
                transform.localScale = new Vector3(-1,1,1);


        }else{
                
            //Swap Sprite Direction, whether you're going right or left
            if(moveDelta.x >0 )
                transform.localScale = Vector3.one;
            else if(moveDelta.x < 0)
                transform.localScale = new Vector3(-1,1,1);
        }


        // add push vector if any
        moveDelta += pushDirection;

        //Reduce the push force every frame, based off the recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //Make sure we can move in the direction by casting a ray cast, if box is null we can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime) ,LayerMask.GetMask("Actor","Blocking"));

        if (hit.collider == null){
            //Move
            transform.Translate(moveDelta.x * Time.deltaTime,0 ,0); 
        }
        //Make sure we can move in the direction by casting a ray cast, if box is null we can move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime),LayerMask.GetMask("Actor","Blocking"));

        if (hit.collider == null){
            //Move
            transform.Translate(0,moveDelta.y * Time.deltaTime,0); 
        }
        


    }
}
