using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform trakingObject;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(trakingObject.position.x,
            transform.position.y,
            transform.position.z);
                          

    }
}
