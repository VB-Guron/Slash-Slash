using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{   
    private Animator transitions;
    public float transitionTime = 1f;
    bool canGoNextLevel;
    GameObject loader; 
    private void Awake() {
        canGoNextLevel = false;
        loader = GameObject.Find("gameLoader");
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(canGoNextLevel){
                NextLevel();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name == "Player"){
            canGoNextLevel = true;
        }
    }


    private void OnTriggerExit(Collider other) {
        if(other.name == "Player"){
            canGoNextLevel = false;
        }
    }
    // Start is called before the first frame update

    public void PlayGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reset(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void Level1(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        
    }
    
    public void Level2(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
    
    public void Level3(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }

    public void MainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel(){
        loader.GetComponent<gameLoader>().NextLevel();
    }

    public void Quit(){
        Debug.Log("Quitting");
        Application.Quit();
    }

    



}
