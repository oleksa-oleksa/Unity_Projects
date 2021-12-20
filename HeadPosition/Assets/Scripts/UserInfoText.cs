using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UserInfoText : MonoBehaviour
{
    public GameObject textDisplay;
    public TextMeshPro textmeshPro;

    // Camera 
    public Vector3 headposition;
    public Quaternion orientation;
    public Vector3 orientationEulerAngles;
    public Vector3 velocity;
    public double speed;

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
        //orientation = Camera.main.transform.rotation;
        orientationEulerAngles = Camera.main.transform.eulerAngles;
        velocity = Camera.main.velocity;
        speed = Math.Sqrt(Math.Pow(velocity[0], 2) + Math.Pow(velocity[1], 2) + Math.Pow(velocity[2], 2));


        // Check if we have reached the time limit
        if (timer > waitTime)
        {
   
            textmeshPro = GetComponent<TextMeshPro>();

            /*
            textmeshPro.SetText("Position x: {0:3}, y: {1:3}, z: {2:3}; \r\n " +
                "Rotation x: {3:3}, y: {4:3}, z: {5:3} \r\n ", 
                headposition.x, headposition.y, headposition.z,
                orientationEulerAngles.x, orientationEulerAngles.y, orientationEulerAngles.z);
            */

            textmeshPro.SetText("Position x: {0:3}, y: {1:3}, z: {2:3}; \r\n " +
                "Velocity x: {3:3}, y: {4:3}, z: {5:3}; \r\n" +
                "Speed: {6:3}",
                headposition.x, headposition.y, headposition.z,
                velocity[0], velocity[1], velocity[2], (float)speed);

            // reset timer
            timer = 0.0f;

        }
    }

}
