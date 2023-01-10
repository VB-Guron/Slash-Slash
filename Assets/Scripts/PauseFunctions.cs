using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;



    public void Pause(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

    }


    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Home(){
        Time.timeScale = 1f;
    }
}
