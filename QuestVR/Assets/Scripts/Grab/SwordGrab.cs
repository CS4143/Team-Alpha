/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGrab : MonoBehaviour
{
    public GameObject CollidingObject;
    public GameObject objectInHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") > 0.2f && CollidingObject)
        {
            GrabObject();
        }
        
        if (Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger") < 0.2f && objectInHand)
        {

            ReleaseObject();

        }
    }

    public void GrabObject()
    {
        objectInHand = CollidingObject;
        objectInHand.transform.SetParent(this.transform);
        objectInHand.GetComponent<RigidBody>().isKinematic = true;
    }

    public void ReleaseObject()
    {
        objectInHand.GetComponent<RigidBody>().isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent())
        {
            CollidingObject = other.gameObject;
        }
    }
}*/
