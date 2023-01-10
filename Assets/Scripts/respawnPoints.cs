
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        GameManager.instance.SavedLocation();
    }

}
