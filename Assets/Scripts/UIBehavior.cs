using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehavior : MonoBehaviour
{

    [SerializeField] private Image weapon;

    private void Start() {
        weapon = GetComponent<Image>();
    }

    public void updateUIWeapon(Sprite currWeapon){
        weapon.sprite = currWeapon;
    }
    
}
