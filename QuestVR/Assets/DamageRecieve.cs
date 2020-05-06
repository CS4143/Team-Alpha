using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagaReceive : MonoBehaviour
{
    public float damageMultiplier;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<DealDamage>() != null)
        {
            //get the weapon damage from the sword
            int damageToGive = collision.collider.GetComponent<DealDamage>().damageToDeal;
            //multiply damage by the multiplier (i.e. legs < head)
            GetComponentInParent<EnemyController>().health -= damageToGive * damageMultiplier;
        }
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
