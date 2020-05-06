using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 20f;
    Transform target;
    NavMeshAgent agent;

    //static int totalEnemies;
    public float attackTime = 1;
    public float currTime = 0;
    public float health = 100f;
    private float time = 0f;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //totalEnemies++;
        time = 0f;
        target = Player.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        anim = GetComponentInChildren<Animator>();
        anim.SetBool("Alive", true);

        print(target);
        print(agent);
    }

    // Update is called once per frame
    void Update()
    {
    
        float distance = Vector3.Distance(target.position, transform.position);
        if (health > 0)
        {
            if (distance <= lookRadius)
            {
                Vector3 playerPosition = target.localPosition;
                //playerPosition.x += 180;
                playerPosition.y = 0;
                transform.LookAt(playerPosition);
                //transform.rotation = Quaternion.Euler(0, 180f, 0);
                //print("Player in Range!!!!!!!!");
                print("health is: " + health);
                if (distance < 1.9)
                {
                    anim.SetBool("InRange", true);
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
                    anim.SetBool("InRange", false);
                    anim.SetBool("IsWalking", true);
                    Vector3 targetPos = target.transform.position;
                    targetPos.y = .170f;
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.010f);
                }
            }
        }
        else
        {
            anim.SetBool("Alive", false);
            print("I am no longer alive");
            Destroy(this.gameObject, 3.0f);
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
