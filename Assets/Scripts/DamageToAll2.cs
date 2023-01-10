using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToAll2 : MonoBehaviour
{
    
    public float damage;
    
    private BoxCollider2D collider;
    public bool golden;

    private void Awake() {
        collider = GetComponent<BoxCollider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag== "Player"){
            other.GetComponent<Health>().TakeDamagePlayer(damage);
            other.GetComponent<Health>().ApplyKnockback(transform.position);
        }
    }
}
