using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserPosition : MonoBehaviour
{

    // This script obtains data from Main Camera in the Scene
    // that is attached to user head's center in HoloLens application

    public Vector3 headposition;
    public Quaternion orientation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        headposition = Camera.main.transform.position;
        orientation = Camera.main.transform.rotation;

    }
}
