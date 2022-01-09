using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate_nodes : MonoBehaviour
{
    public GameObject animation;

    protected GameObject getFrame(int n)
    {
        return animation.transform.GetChild(n).gameObject;
    }

    protected int getFrameCount()
    { 
        return animation.transform.childCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        animation = GameObject.Find("Animation");

        for (int i = 0; i < getFrameCount(); i++)
        {
            getFrame(i).SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
