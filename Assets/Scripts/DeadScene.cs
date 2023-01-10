using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScene : MonoBehaviour
{   
    public GameObject player;
    public GameObject camera;

    public void DestroyPlayer(){
        player.SetActive(true);
        Destroy(player);
    }

    public void DestroyCamera(){
        Destroy(camera);
    }
}
