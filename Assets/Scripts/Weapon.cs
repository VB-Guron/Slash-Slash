using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    
    //Animation
    private Animator anim;
    //Monitoring of positions
    private float swingMovement;



    //Weapon position
    private Vector3 mousePos;
    private GameObject characterPosition;
    private Camera cam;
    public float speed;



    //Damage struct

    //Upgrade
    private SpriteRenderer spriteRenderer;

    //Swing
    private float cooldown = 0.5f;
    private float lastSwing;
    private bool swinged;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        swinged = true;
        anim = GameObject.Find("swing").GetComponent<Animator>();
        cam = Camera.main;
        characterPosition = GameObject.Find("Player");
    }


     private void Update()
    {

        mousePos =cam.ScreenToWorldPoint(Input.mousePosition);


        if(Input.GetKeyDown(KeyCode.Space)){
            
        anim = GameObject.Find("swing").GetComponent<Animator>();
            if(swinged){
                swingMovement = -160;
                swinged = false;
                anim.SetTrigger("attack");
            }else if(!swinged){
                anim.SetTrigger("attack");
                swingMovement = 0;
                swinged = true;
            }
        }
        

        //CALCULATES THE ANGLE!
        transform.position = new Vector2(characterPosition.transform.position.x, characterPosition.transform.position.y);
        Vector2 direction = mousePos - transform.position;
        float angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg) + swingMovement;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

    }

    private void Swing(){
        Debug.Log("Swing");
    }

    




}
