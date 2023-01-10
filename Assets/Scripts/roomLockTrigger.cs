using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLockTrigger : MonoBehaviour
{
    //Finished
    bool finished = false;
    
    public GameObject RoomMonitor;

    private void Start() {
    }

    //Player Entered The Room
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !finished){
            RoomMonitor.GetComponent<RoomMonitor>().lockRoom();
            finished = true;
        }
    }
}
