
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //public fields

    [Header ("Health")]
    [SerializeField] private float startingHealth, knockbackForce;
    public float currentHealth {get; private set;}
    public float pushRecoverySpeed = 0.2f;

    //Immunity 
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    //Push
    protected Vector3 pushDirection;
    protected virtual void Awake() {
        currentHealth = startingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }
    //PLAYER DAMAGE DETAILS
    public void TakeDamagePlayer(float _damage){
        UnityEngine.Debug.Log(gameObject.name);

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if(currentHealth > 0 ){
            //Damage
            UnityEngine.Debug.Log("Decrease Health: " + _damage + " Health: " + currentHealth);

            //Invulnerability
            StartCoroutine(Invulnerability());
        }else if(currentHealth <= 0 ){
            //DEAD
            UnityEngine.Debug.Log("Dead: " + _damage + " Health " + currentHealth);
            gameObject.SetActive(false);
            GameObject.Find("DeadScene").GetComponent<Animator>().SetTrigger("start");
            //FullHealth();
            //GameObject.Find("Portal").GetComponent<Portal>().Reset();
        }
    }
    
    //ENEMY DAMAGE DETAILS
    public void TakeDamageEnemy(float _damage){
        UnityEngine.Debug.Log(gameObject.name);

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        if(currentHealth > 0 ){
            //Damage
            UnityEngine.Debug.Log("Decrease Health: " + _damage + " Health: " + currentHealth);

            //Invulnerability
            StartCoroutine(Invulnerability());
        }else if(currentHealth <= 0 ){
            //DEAD
            UnityEngine.Debug.Log("Dead: " + _damage + " Health " + currentHealth);
            if(Random.Range(1,4) == 1){
                UnityEngine.Debug.Log(gameObject.transform.position);
                gameObject.GetComponent<Drops>().DropPotions();
            }
            gameObject.SetActive(false);
            
            if(!gameObject.name.Contains("Clone")){
                UnityEngine.Debug.Log(gameObject.name);
                UnityEngine.Debug.Log(gameObject.name.Contains("Clone"));
                gameObject.GetComponentInParent<EnemyMonitor>().MonitorEnemies();
               
            }
        }
    }public void TakeDamageBarrier(float _damage){
        UnityEngine.Debug.Log("Is Unlocked: " + GetComponentInParent<BarrierHolder>().isUnlocked);

        if(GetComponentInParent<BarrierHolder>().isUnlocked){
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
            if(currentHealth > 0 ){
                //Damage
                UnityEngine.Debug.Log("Decrease Health: " + _damage + " Health: " + currentHealth);
                //Change Appearance
                GetComponent<SpriteRenderer>().sprite = GetComponentInParent<BarrierHolder>().reskinBarriers(currentHealth);
                //Play Animation
            }else if(currentHealth <= 0 ){
                //Destoyed
                gameObject.SetActive(false);
            }
        }
        

        //ENEMY DAMAGE DETAILS
    }

    public void ApplyKnockback(Vector3 attackPosition) {
        Vector3 dirFromAttack = (transform.position - attackPosition).normalized;
        transform.position += dirFromAttack * knockbackForce;
    }
   
    private IEnumerator Invulnerability(){
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for(int i = 0; i <numberOfFlashes;i++){
            spriteRend.color = new Color(1,0,0, 0.5f);
            yield return new WaitForSeconds(invulnerabilityDuration/(numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invulnerabilityDuration/(numberOfFlashes * 2));
        }
        //invulnerability duration
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    //All fighters can ReceiveDamage / Die
    /*
    protected virtual void ReceiveDamage(Damage dmg){
        if(Time.time - lastImmune > immuneTime){
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.up * 20, 0.5f);


            if(hitpoint <= 0){
                hitpoint=0;
                Death();
            }
        }
    }*/

    protected virtual void Death(){

    }

    public void FullHealth(){
        currentHealth = 5;
    }

    public void addHealth(float potion){
        
        currentHealth = Mathf.Clamp(currentHealth + potion, 0 , startingHealth);
        UnityEngine.Debug.Log("Increase Health: " + potion + " Health: " + currentHealth);

    }
}
