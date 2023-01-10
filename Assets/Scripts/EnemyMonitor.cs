
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonitor : MonoBehaviour
{
    public GameObject[] Enemies;

    private void Start() {
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].SetActive(false);
        }
    }
    public void activateEnemies(){
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i].SetActive(true);
        }
    }

    public void MonitorEnemies(){
        bool allDead = true;
        int countEnemy = 0;
        for (int i = 0; i < Enemies.Length; i++)
        {
            if(!Enemies[i].activeInHierarchy){
                countEnemy++;
            }
            else 
                countEnemy--;
        }
        if (countEnemy == Enemies.Length){
            allDead = true;
        } 
        else{
            allDead = false;
        }
         
        gameObject.GetComponentInParent<RoomMonitor>().UnlockBarrier(allDead);
    }



}
