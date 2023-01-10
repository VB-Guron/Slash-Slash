using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinaleCutScene : MonoBehaviour
{
    
    public bool readyForCutscene;
    public bool withInRange;
    GameObject theCamera;
    public GameObject FinalCutscene;


    private void Awake() {
        readyForCutscene = false;
        theCamera = GameObject.FindWithTag("MainCamera");
        
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(readyForCutscene){
                if(withInRange){
                    //START FINAL CUTSCENE
                    theCamera.SetActive(false);
                    GameObject.FindWithTag("Player").SetActive(false);
                    GameObject.Find("UI").SetActive(false);
                    FinalCutscene.SetActive(true);
                }
            }
        }
    }


    public void readyForCutSceneMethod(){
        readyForCutscene = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        withInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        withInRange = false;
    }
}
