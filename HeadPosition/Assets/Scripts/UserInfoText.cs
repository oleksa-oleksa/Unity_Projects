using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInfoText : MonoBehaviour
{
    public GameObject textDisplay;
    public TextMeshPro textmeshPro;

    public GameObject detectedTransform;
    // script to access
    private UserTransform userTransform;

    // time variables for delay
    private float waitTime = 2.0f;
    private float timer = 0.0f;
    
    private int counter = 0;


    void Start()
    {
        userTransform = detectedTransform.GetComponent<UserTransform>();
    }

  
    void Update()
    {
        timer += Time.deltaTime;
        counter++;

        // Check if we have reached beyond 2 seconds.
        if (timer > waitTime)
        {
            // display user transform information on text dislay
            //ShowUserTransformData(userTransform);
            // textDisplay.GetComponent<Text>().text = "Position!" + counter;
            textmeshPro = GetComponent<TextMeshPro>();
            textmeshPro.SetText("Position: {0}", counter);

            // reset timer
            timer = 0.0f;

        }
    }
/*
    void ShowUserTransformData(UserTransform userTransform)
    {
        textDisplay.GetComponent<Text>().text = "Position: " + userTransform.headposition +
             "Orientation: " + userTransform.orientation;
    }
*/
}
