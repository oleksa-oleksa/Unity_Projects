using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserTransform : MonoBehaviour
{

    // This script obtains data from Main Camera in the Scene
    // that is attached to user head's center in HoloLens application

    public Vector3 headposition_t;
    public Quaternion orientation_t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        headposition_t = Camera.main.transform.position;
        orientation_t = Camera.main.transform.rotation;

    }
}
