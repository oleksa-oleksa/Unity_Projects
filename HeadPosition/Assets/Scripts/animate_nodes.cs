using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate_nodes : MonoBehaviour
{
    public GameObject animation;
    public int targetFramesPerSecond = 120;
    
    protected GameObject getFrame(int n)
    {
        return animation.transform.GetChild(n).gameObject;
    }

    protected int getFrameCount()
    { 
        return animation.transform.childCount;
    }

    private void Awake()
    {
        animation = GameObject.Find("Animation");

        for (int i = 0; i < getFrameCount(); i++)
        {
            getFrame(i).SetActive(false);    
        }
    }

    private IEnumerator Start()
    {
        var currentIndex = 0;
        getFrame(currentIndex).SetActive(true);

        while (true)
        {
            yield return new WaitForEndOfFrame();
            getFrame(currentIndex).SetActive(false);
            currentIndex = (currentIndex + 1) % getFrameCount();
            getFrame(currentIndex).SetActive(true);
        }
        /*
         * var currentIndex = 0;

        getFrame(currentIndex).SetActive(true);
        int frameCount = getFrameCount();

        while (true)
        {
            yield return new WaitForSeconds(1f / targetFramesPerSecond);
            getFrame(currentIndex).SetActive(false);
            currentIndex = (currentIndex + 1) % frameCount;
            getFrame(currentIndex).SetActive(true);
        }
        */
    }

/*    // Start is called before the first frame update
    void Start()
    {
        animation = GameObject.Find("Animation");

        for (int i = 0; i < getFrameCount(); i++)
        {
            getFrame(i).SetActive(false);
        }

        activeFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
}
