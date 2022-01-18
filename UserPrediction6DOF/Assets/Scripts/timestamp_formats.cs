using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;
using System.IO;


public class timestamp_formats : MonoBehaviour
{
    public GameObject textDisplay;
    public TextMeshPro textmeshPro;

    // time variables for delay
    private float waitTime = 1.0f;
    private float timer = 0.0f;


    void Start()
    {

    }


    void Update()
    {

        timer += Time.deltaTime;

        float timestamp1 = Time.time;

        if (timer > waitTime)
        {
            // update text block in hologram 
            textmeshPro = GetComponent<TextMeshPro>();
            textmeshPro.SetText("Time.time: {0:3}", timestamp1);

            // reset timer
            timer = 0.0f;

        }
    }


}
