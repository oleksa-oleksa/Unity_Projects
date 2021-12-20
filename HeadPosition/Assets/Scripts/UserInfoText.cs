using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInfoText : MonoBehaviour
{
    public GameObject textDisplay;
    public TextMeshPro textmeshPro;

    // Camera 
    public Vector3 headposition;
    public Quaternion orientation;

    // time variables for delay
    private float waitTime = 1.0f;
    private float timer = 0.0f;
    
    // test
    // private Vector3 hp = new Vector3(14.0f, 19.0f, 76.0f);


    void Start()
    {

    }

  
    void Update()
    {
        timer += Time.deltaTime;
        headposition = Camera.main.transform.position;
        orientation = Camera.main.transform.rotation;

        // Check if we have reached beyond 2 seconds.
        if (timer > waitTime)
        {
   
            textmeshPro = GetComponent<TextMeshPro>();

            textmeshPro.SetText("Position x: {0:3}, y: {1:3}, z: {2:3}; \r\n " +
                "Rotation w: {3:3}, x: {4:3}, y: {5:3}, z: {6:3}", 
                headposition.x, headposition.y, headposition.z,
                orientation.w, orientation.x, orientation.y, orientation.z);

            // reset timer
            timer = 0.0f;

        }
    }

}
