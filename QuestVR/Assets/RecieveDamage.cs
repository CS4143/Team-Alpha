using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamage : MonoBehaviour
{
    GameObject[] weapons;

    public float damageMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        weapons = GameObject.FindGameObjectsWithTag("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.FindWithTag("Weapon");
        //GameObject[] weapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach(GameObject blade in weapons)
        {
            if (Vector3.Distance(blade.transform.position, this.transform.position) < .03)
            {
                damageRecieve(blade.GetComponentInParent<DealDamage>().damageToDeal);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<DealDamage>() != null){ 
            //get the weapon damage from the sword
            int damageToGive = collision.collider.GetComponent<DealDamage>().damageToDeal;
            //multiply damage by the multiplier (i.e. legs < head)
            GetComponentInParent<EnemyController>().health -= damageToGive * damageMultiplier;
        }
    }

    void damageRecieve(int damage)
    {
        //get the weapon damage from the sword
        //int damageToGive = collision.collider.GetComponent<DealDamage>().damageToDeal;
        //multiply damage by the multiplier (i.e. legs < head)
        GetComponentInParent<EnemyController>().health -= damage * damageMultiplier;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<DealDamage>())
        {
            //get the weapon damage from the sword
            int damageToGive = other.GetComponent<DealDamage>().damageToDeal;
            //multiply damage by the multiplier (i.e. legs < head)
            GetComponentInParent<EnemyController>().health -= damageToGive * damageMultiplier;
        }
    }*/
}
