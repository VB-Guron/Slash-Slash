
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   public GameObject UI;

   private void Awake() {
       if(GameManager.instance != null){
           Destroy(gameObject);
           return;
       }
       instance = this;

        //Uncomment if you want a clean start every start of the game
       //PlayerPrefs.DeleteAll();

       /* A class that is used to manage the scenes in the game. */
       SceneManager.sceneLoaded += LoadState;

    
       DontDestroyOnLoad(gameObject);


   }


   //Resources
   public List<Sprite> playerSprites;
   public List<GameObject> weaponSprites;
   public List<GameObject> weaponReference;
   public List<Sprite> UIWeaponsSprites;
   public List<GameObject> uiInventorySprites;
   public List<int> weaponPrices;
   public List<int> xpTable;


   //Reference
   public Player player;
   //public weapon weapon
   public FloatingTextManager floatingTextManager;


   //Logic
   public int pesos;
   public int experience;


   //update UI
   private GameObject uiWeapon;
   private GameObject uiInventory;

   public GameObject player2;

   

    private void Start() {
        uiInventorySprites.Add(GameObject.Find("item1"));
        uiInventorySprites.Add(GameObject.Find("item2"));
        uiInventorySprites.Add(GameObject.Find("item3"));
        uiInventorySprites.Add(GameObject.Find("item4"));
        uiInventorySprites.Add(GameObject.Find("item5"));
        uiInventorySprites.Add(GameObject.Find("item6"));
        uiInventorySprites.Add(GameObject.Find("item7"));
        
         player2 = GameObject.Find("Player");

         
       //UI.SetActive(false);

    }
   private void Update() {
       uiWeapon = GameObject.Find("charCurrentWeapon");
       uiInventory = GameObject.Find("Inventory");
   }


    public void SaveState(){
        //Debug.Log("Saved");
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";
        PlayerPrefs.SetString("SaveState",s);
    }
    public void LoadState(Scene e, LoadSceneMode mode){
        //Debug.Log("Loaded");

        if(!PlayerPrefs.HasKey("SaveState"))
            return;


        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change player skin
        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change Weapon

    }

    //floating text    
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
        
    }


    public void checkWeapon(){
        for (int i = 0; i < weaponSprites.Count ; i++)
        {
            //Debug.Log(weaponSprites[i]);
        }
    }

    public void acquireWeapon(GameObject theWeapon){
        UnityEngine.Debug.Log("Weapon Acquired");
        UIInventoryUpdate(theWeapon.GetComponent<SpriteRenderer>().sprite);
        weaponSprites.Add(GetWeaponReference(theWeapon));
    }

    public GameObject GetWeaponReference(GameObject theWeapon){
        for (int i = 0; i < weaponReference.Count; i++)
        {
            if(theWeapon.name == weaponReference[i].name){
                return weaponReference[i];
            }
        }
        return null;
    }

    public GameObject changeWeapon(int requestedWeapon){
        if(weaponSprites.Count == 0 || weaponSprites.Count-1 < requestedWeapon){
            return null;
        }else{
        uiWeapon.GetComponent<Image>().sprite = weaponSprites[requestedWeapon].GetComponent<SpriteRenderer>().sprite;
        uiWeapon.GetComponent<Image>().color = new Color32(255,255,225,255); 
        return weaponSprites[requestedWeapon];
        }
    }

    public void UIInventoryUpdate(Sprite theWeapon){
        UnityEngine.Debug.Log("Updating Inventory");
        for(int i = 0; i < uiInventorySprites.Count; i++){
        UnityEngine.Debug.Log("Checking if inventory slot if empty");
            
            if(uiInventorySprites[i].GetComponent<Image>().sprite == null){
                UnityEngine.Debug.Log("Open slot found");

                uiInventorySprites[i].GetComponent<Image>().sprite = checkCorrespondingUIImage(theWeapon);
                break;
            }
        }
    }

    public Sprite checkCorrespondingUIImage(Sprite weapon){
        UnityEngine.Debug.Log("Checking Weapon");

        if(weapon.name.ToString() == "weapon_0"){
            return UIWeaponsSprites[0];
        }else if(weapon.name.ToString() == "weapon_1"){
            return UIWeaponsSprites[1];
        }else if(weapon.name.ToString() == "weapon_2"){
            return UIWeaponsSprites[2];
        }else if(weapon.name.ToString() == "weapon_3"){
            return UIWeaponsSprites[3];
        }else if(weapon.name.ToString() == "weapon_4"){
            return UIWeaponsSprites[4];
        }else if(weapon.name.ToString() == "weapon_5"){
            return UIWeaponsSprites[5];
        }else if(weapon.name.ToString() == "weapon_6"){
            return UIWeaponsSprites[6];
        }
        return null;

    }
    public void SavedLocation(){
        Vector3 playerPosition = player2.transform.position;
        PlayerPrefs.SetFloat("positionx", playerPosition.x);
        PlayerPrefs.SetFloat("positiony", playerPosition.y);
    }

    public void Respawn(){
        player2.transform.position = new Vector3(PlayerPrefs.GetFloat("positionx"), PlayerPrefs.GetFloat("positiony"),0 ) ;
        player2.GetComponent<Health>().FullHealth();
    }

}
