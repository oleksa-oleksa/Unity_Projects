using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class envoke_repeating_timestamp : MonoBehaviour
{
    public GameObject textDisplay;
    public TextMeshPro textmeshPro;

    // time variables for delay
    private float waitTime = 1.0f;
    private float timer = 0.0f;


    void Start()
    {
        // 100 ns is 1e-7
    }


    void GetTimestamp()
    {
        
    }

    void Update()
    {

        timer += Time.deltaTime;

        float timestamp = Time.time;
        float timestamp_ms = Time.time * 1000.0f;
        int timestamp_dt = DateTime.UtcNow.Millisecond;

        if (timer > waitTime)
        {
            // update text block in hologram 
            textmeshPro = GetComponent<TextMeshPro>();
            textmeshPro.SetText("Time.time: {0:17}, Time.time ms: {1:17}, TimeDate: {2}", timestamp, timestamp_ms, timestamp_dt);

            // reset timer
            timer = 0.0f;

        }
    }

}
