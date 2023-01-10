
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPopOut : MonoBehaviour
{
    public Animator anim;
    public BoxCollider2D collider;

    private void Awake() {
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Entered");
        if(other.tag == "Player"){
            anim.SetBool("show", true);
        }
    }


    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player"){
            anim.SetBool("show", false);
        }
    }
}
