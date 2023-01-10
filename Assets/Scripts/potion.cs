using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    public bool canbePickedUp;

    public Animator anim;

    public AudioSource audio;
    private void Awake() {
        canbePickedUp = false;
        
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        anim.SetTrigger("loot");

    }

    public void playSound(){
        audio.Play();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(canbePickedUp){
                GameObject.FindWithTag("Player").GetComponent<Health>().addHealth(1);
                GetComponentInParent<Destroy>().destroy();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            canbePickedUp = true;
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            canbePickedUp = false;
        }
    }
}
