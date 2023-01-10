using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    
    public float damage;
    public AudioSource audio;
    
    private BoxCollider2D collider;
    public bool golden;

    private void Awake() {
        collider = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boss" && golden){
            audio.Play();
            other.GetComponent<Health>().TakeDamageEnemy(damage + 1);
            other.GetComponent<Health>().ApplyKnockback(transform.position);
        }else if(other.tag == "Barrier"){
            audio.Play();
            other.GetComponent<Health>().TakeDamageBarrier(1);
            other.GetComponent<Health>().ApplyKnockback(transform.position);
        }else if(other.tag == "Enemy" || other.tag == "Boss"){
            audio.Play();
            other.GetComponent<Health>().TakeDamageEnemy(damage);
            other.GetComponent<Health>().ApplyKnockback(transform.position);
        }
    }
}
