
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipped : MonoBehaviour
{
        //Manipulates weapons of player
        public GameObject[] weaponsMonitor;
        public GameObject prev;
        public AudioSource audio;

        private void Start() {
            weaponsMonitor = GameObject.FindGameObjectsWithTag("weapon");
            turnedOFF();
            audio = GetComponent<AudioSource>();
        }



        public void turnedOFF(){
            for (int i = 0; i < weaponsMonitor.Length; i++)
            {
                weaponsMonitor[i].SetActive(false);
            }
        }

        public void changeWeapon(int inventoryNumber){
            if(GameManager.instance.weaponSprites.Count == 0 || GameManager.instance.weaponSprites.Count-1 < inventoryNumber ){

            }else{
                
            GameObject weapon = GameManager.instance.changeWeapon(inventoryNumber);
            audio.Play();
            lookInventory(weapon);
            }


    }

    public void lookInventory(GameObject weapon){
        for (int i = 0; i < weaponsMonitor.Length; i++)
        {
            if(weaponsMonitor[i].name == weapon.name){
                if(prev != null){
                    
                    prev.SetActive(false);
                }
                turnOn(weaponsMonitor[i]);
                prev = weaponsMonitor[i];
            }           
        }
    }

    public void turnOn(GameObject weapon){
        weapon.SetActive(true);
    }
}
