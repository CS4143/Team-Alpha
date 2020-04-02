using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;

    public float attackTime = 1;
    public float currTime = 0;
    public float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        target = Player.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        print(target);
        print(agent);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(health > 0)
        {
            if (distance <= lookRadius)
            {
                Vector3 playerPosition = target.localPosition;
                //playerPosition.x += 180;
                playerPosition.y = 0;
                transform.LookAt(playerPosition);
                //transform.rotation = Quaternion.Euler(0, 180f, 0);
                print("Player in Range!!!!!!!!");
                if (distance < 1.5)
                {
                    print("Attacking Player");

                    currTime += Time.deltaTime;
                    print(currTime);
                    //if()
                    if (currTime >= attackTime)
                    {
                        Attack();
                    }

                }
                else
                {
                    Vector3 targetPos = target.transform.position;
                    targetPos.y = 0;
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.015f);
                }
            }
        }
        else
        {
            print("I am no longer alive");
        }
        
        //else do death
    }

    void OnDrawGizmosSelected(){

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }

    private void OnTriggerEnter(Collider other)
    {
        currTime = -1;
    }

    void Attack(){
        print("Player took damage");
        currTime = 0;
    }

    //Return true if enemy still has health
    bool hasHealth()
    {
        bool health = false;
        if(GetComponent<EnemyController>().health > 0)
        {
            health = true;
        }
        return health;
    }
}
