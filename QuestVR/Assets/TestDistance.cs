using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDistance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] testsObjects = GameObject.FindGameObjectsWithTag("test");
        foreach(GameObject testObject in testsObjects)
        {
            print(Vector3.Distance(this.transform.position, testObject.transform.position));
            print(testsObjects.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
