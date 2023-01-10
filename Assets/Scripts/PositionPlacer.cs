using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlacer : MonoBehaviour
{
    private void Start() {
        GameObject player = GameObject.Find("Player");

        player.transform.position = gameObject.transform.position;
    }
}
