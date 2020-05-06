using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    
    public int damageToDeal;
    public float weaponSpeed;

    //private float attackTime = 2.0f;
    private void Update()
    {
        GetComponentInParent<Damage>().damageTimer -= Time.deltaTime;
    }
    //If cube comes into contact with player call takeDamage fun

    //void OnCollisionEnter(Collision col){

    /*if(col.gameObject.tag == "Enemy"){
        Debug.Log("Collision Occured");
        col.gameObject.
        //Cancel Enemys attack
        //create ragdoll effect
        //Delete the enemy after 10 seconds
        Destroy(col.gameObject);
    }*/

    //}

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponentInParent<Damage>().damageTimer <= 0)
        {
            other.GetComponentInParent<Animator>().SetBool("TookDamage", true);
            float multiplier = other.GetComponent<ReceiveDamage>().damageMultiplier;
            other.GetComponentInParent<EnemyController>().health -= multiplier * damageToDeal;
            GetComponentInParent<Damage>().damageTimer = 2 / weaponSpeed;//2x weapon speed = 1 second. / .5 weapon speed = 4 seconds
            
        }
    }


}
