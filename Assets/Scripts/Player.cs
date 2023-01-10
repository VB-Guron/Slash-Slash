
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private KeyCode[] keyCodes = new KeyCode []{ KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };
    public float speed;

    public AudioSource audio;
    public Animator anim;
    protected override void Awake() {
            base.Awake();
            anim = GetComponent<Animator>();
            audio = GetComponent<AudioSource>();
        }
        private void Update() {
            for( int i = 0 ; i < keyCodes.Length ; ++i )
            {
                if( Input.GetKeyDown( keyCodes[i] ))
                {
                    gameObject.GetComponentInChildren<Equipped>().changeWeapon(i-1);
                }
            }

            if(Input.GetKeyDown(KeyCode.Escape)){
                GameObject.Find("Pause Button").GetComponent<PauseFunctions>().Pause();
            }
        }
    private void FixedUpdate() {
        
       
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        
            if(x == 0 && y == 0){
                anim.SetBool("isRunning", false);
            }else{
                anim.SetBool("isRunning",true);
            }

        UpdatedMover(new Vector3(x * speed,y * speed,0));

        

        
    }
    public void PlaySound(){
        audio = GetComponent<AudioSource>();
                audio.Play();
    }
}
