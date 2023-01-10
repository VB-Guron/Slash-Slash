using System.Numerics;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierHolder : MonoBehaviour
{   
    [SerializeField] private GameObject[] barrier_mid;
    [SerializeField] private GameObject[] barrier_left;
    [SerializeField] private GameObject[] barrier_right;
    [SerializeField] private GameObject[] barrier_full;

    public Sprite mid;
    public Sprite left;
    public Sprite right;
    public Sprite full;
    public Sprite unlocked;
    public Sprite health3;
    public Sprite health2;
    public Sprite health1;
    public bool isUnlocked;



    public void activateBarriers(){
        isUnlocked = false;
        traverse(barrier_mid, mid);
        traverse(barrier_left, left);
        traverse(barrier_right, right);
        traverse(barrier_full, full);
        //barrier_mid.GetComponent<SpriteRenderer>().sprite = mid;
        //barrier_left.GetComponent<SpriteRenderer>().sprite = left;
        //barrier_right.GetComponent<SpriteRenderer>().sprite = right;
        collidersOn(barrier_mid, true);
        collidersOn(barrier_left, true);
        collidersOn(barrier_right, true);
        collidersOn(barrier_full, true);
        //barrier_mid.GetComponent<BoxCollider2D>().enabled = true;
        //barrier_left.GetComponent<BoxCollider2D>().enabled = true;
        //barrier_right.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void unlockBarrier(){
        isUnlocked = true;
        traverse(barrier_mid, unlocked);
        traverse(barrier_left, unlocked);
        traverse(barrier_right, unlocked);
        traverse(barrier_full, unlocked);
        //barrier_mid.GetComponent<SpriteRenderer>().sprite = unlocked;
        //barrier_left.GetComponent<SpriteRenderer>().sprite = unlocked;
        //barrier_right.GetComponent<SpriteRenderer>().sprite = unlocked;
    }

    public void traverse(GameObject[] objective, Sprite skin){
        for (int i = 0; i < objective.Length; i++)
        {
            objective[i].GetComponent<SpriteRenderer>().sprite = skin;
        }
    }

    public void collidersOn(GameObject[] objective, bool orders){
        for (int i = 0; i < objective.Length; i++)
        {
            objective[i].GetComponent<BoxCollider2D>().enabled = orders;
        }
    }

    public Sprite reskinBarriers(float health){
        if(health == 3){
            return health3;
        }else if (health ==  2){
            return health2;
        }else if (health == 1){
            return health1;
        }
        return null;
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    
}
