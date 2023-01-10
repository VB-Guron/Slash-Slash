

using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
        GameObject place;
        public GameObject player;
        bool flag;
        private void Start() {
            player = GameObject.Find("Player");
        }
        private void Update() {
            if(Input.GetKeyDown(KeyCode.E)){
                if(flag){
                    player.transform.position = place.transform.position;
                }
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other) {
            flag = true;
            if(gameObject.tag == "passage1"){
                place = GameObject.FindWithTag("passage2");
            }else if(gameObject.tag == "passage2"){
                place = GameObject.FindWithTag("passage1");
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            flag=false;
        }
}
