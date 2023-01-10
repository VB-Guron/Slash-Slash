using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : MonoBehaviour
{   
    bool canGoNextLevel;
    private void Awake() {
        canGoNextLevel = false;
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(canGoNextLevel){
                MainMenu();
                Destroy(GameObject.Find("GameManager"));
                Destroy(GameObject.Find("Player"));
                Destroy(GameObject.Find("UI"));
                Destroy(GameObject.Find("Main Camera"));
                Destroy(GameObject.Find("[Debug Updater]"));
                
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit(){
        Debug.Log("Quitting");
        Application.Quit();
    }





}
