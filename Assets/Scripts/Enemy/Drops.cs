using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
      [SerializeField] private GameObject Potion;

    public void DropPotions()
    {
        Instantiate(Potion, transform.position, transform.rotation);
    }  
}
