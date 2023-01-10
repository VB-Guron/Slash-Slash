using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name=="Player"){
            GameObject weapon = gameObject;
            Debug.Log("Acquired " + weapon );
            GameManager.instance.acquireWeapon(weapon);
            GameManager.instance.checkWeapon();
            gameObject.SetActive(false);
        }
    }
}
