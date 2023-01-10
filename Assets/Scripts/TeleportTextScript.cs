using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTextScript : MonoBehaviour
{
    
        private Animator anim;
    // Start is called before the first frame update
    
        private void Awake() {
            anim = GetComponent<Animator>();
        }
        private void OnTriggerEnter2D(Collider2D other) {
            
            anim.SetBool("show", true);
        }
        private void OnTriggerExit2D(Collider2D other) {
            
            anim.SetBool("show", false);
        }
}
