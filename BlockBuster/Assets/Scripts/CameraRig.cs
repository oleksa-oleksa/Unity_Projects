using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{

    public float moveSpeed;
    public GameObject target;

    private Transform rigTransform;

    // Start is called before the first frame update
    void Start()
    {
        //  gets a reference to the parent Camera object's transform in the scene hierarchy. 
        rigTransform = this.transform.parent;
    }

    void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        rigTransform.position = Vector3.Lerp(rigTransform.position, target.transform.position,
          Time.deltaTime * moveSpeed);
    }
}
