using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInfoText : MonoBehaviour
{
    public GameObject textDisplay;

    public GameObject detectedTransform;
    // script to access
    private UserTransform userTransform;

    // time variables for delay
    private float waitTime = 2.0f;
    private float timer = 0.0f;
    private float value = 10.0f;


    void Start()
    {
        userTransform = detectedTransform.GetComponent<UserTransform>();
    }

  
    void Update()
    {
        timer += Time.deltaTime;

        // Check if we have reached beyond 2 seconds.
        if (timer > waitTime)
        {
            // display user transform information on text dislay
            //ShowUserTransformData(userTransform);
            textDisplay.GetComponent<Text>().text = "Position!";

            // reset timer
            timer = 0.0f;

        }
    }

    void ShowUserTransformData(UserTransform userTransform)
    {
        textDisplay.GetComponent<Text>().text = "Position: " + userTransform.headposition +
             "Orientation: " + userTransform.orientation;
    }
}
