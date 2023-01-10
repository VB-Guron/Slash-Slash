using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMonitor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject BarrierHolder;
    
    public GameObject EnemyMonitor;

    public bool isThisBossRoom;
    public bool isThisLastLevel;
    public GameObject Portal;

    public void lockRoom(){
        //Locked
        Debug.Log("Room Locked");
        BarrierHolder.GetComponent<BarrierHolder>().activateBarriers();
        EnemyMonitor.GetComponent<EnemyMonitor>().activateEnemies();
        if(isThisBossRoom)
            Portal.SetActive(false);
        
    }

    public void UnlockBarrier(bool orders){
        if(orders){
            BarrierHolder.GetComponent<BarrierHolder>().unlockBarrier();
            if(isThisBossRoom){
                OpenPortal();
            }

            if(isThisLastLevel){
                gameObject.GetComponent<FinaleCutScene>().readyForCutSceneMethod();
            }
        }
    }

    public void OpenPortal(){
        Portal.SetActive(true);
    }
}
