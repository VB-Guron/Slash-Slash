using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWorldSwords : MonoBehaviour
{   
    private BoxCollider2D boxCollider;



    private void Awake() {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            GameObject weapon = gameObject;
            Debug.Log("Acquired " + weapon );
            GameManager.instance.acquireWeapon(weapon);
            GameManager.instance.checkWeapon();
            gameObject.SetActive(false);

        }
    }
   
}
