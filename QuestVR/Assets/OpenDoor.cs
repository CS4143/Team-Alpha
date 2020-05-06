using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    GameObject player;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInParent<Animator>();
        anim.SetBool("OpenDoor", false);//will be true first, for player to enter
        anim.SetBool("OpenDoor", false);//will be true after open, keep player in arena
    }

    // Update is called once per frame
    void Update()
    {
        float PlayerDistance = Vector3.Distance(player.transform.position, transform.position);
        print(PlayerDistance);
        if (PlayerDistance < 3)
        {
            anim.SetBool("OpenDoor", true);
        }

        if(anim.GetBool("OpenDoor") == true)
        {
            if (PlayerDistance > 2 && player.transform.position.z > -1)
            {
                anim.SetBool("CloseDoor", true);
            }
        }
    }
}
