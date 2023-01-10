using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameLoader : MonoBehaviour
{   
    bool canGoNextLevel;
    private Animator transitions;
    public float transitionTime = 1.3f;

    public GameObject UI;
    private void Awake() {
        canGoNextLevel = false;
        UI = GameObject.Find("UI");
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)){
            if(gameObject.name == "princess"){
                if(canGoNextLevel){
                    Destroy(GameObject.Find("GameManager"));
                    Destroy(GameObject.Find("Player"));
                    Destroy(GameObject.Find("UI"));
                    Destroy(GameObject.Find("Main Camera"));
                    Destroy(GameObject.Find("[Debug Updater]"));
                    Destroy(GameObject.Find("gameLoader"));
                    
                    MainMenu();
                    
                }
            }else if(gameObject.name == "portal"){
                if(canGoNextLevel){
                    Destroy(GameObject.Find("GameManager"));
                    Destroy(GameObject.Find("Player"));
                    Destroy(GameObject.Find("UI"));
                    Destroy(GameObject.Find("Main Camera"));
                    Destroy(GameObject.Find("[Debug Updater]"));
                    Destroy(GameObject.Find("gameLoader"));

                    
                    NextLevel();
                }
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
        
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("UI"));
        Destroy(GameObject.Find("[Debug Updater]"));
        Destroy(GameObject.Find("gameLoader"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        Destroy(GameObject.Find("Main Camera"));
    }
    
    public void Level2(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
    public void controls(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Controls");
    }
    public void credits(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credits");
    } 
    public void back(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    
    public void Level3(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3");
    }

    public void MainMenu(){
        Destroy(GameObject.Find("GameManager"));
        Destroy(GameObject.Find("Player"));
        Destroy(GameObject.Find("UI"));
        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameObject.Find("[Debug Updater]"));
        Destroy(GameObject.Find("gameLoader"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel(){
        StartCoroutine(transitioning());
    }

    public void Quit(){
        Debug.Log("Quitting");
        Application.Quit();
    }



    IEnumerator transitioning(){
        transitions = GetComponent<Animator>();
        transitions.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime); 
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void HIdeUI(){
        UI = GameObject.Find("UI");
        UI.SetActive(false);
    }


    public void ShowUI(){
        UI.SetActive(true);
    }

}
