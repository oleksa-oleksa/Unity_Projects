using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;
using System.IO;


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

    // for CSV Logger
    private List<string[]> rowData = new List<string[]>();
    private string filePath = getPath();
    private StringBuilder sb;


    // Following method is used to retrive the relative path as device platform
    private string getPath()
    {
#if UNITY_EDITOR
        return Application.dataPath +"/CSV/"+"Saved_data.csv";
#elif UNITY_ANDROID
        return Application.persistentDataPath+"Saved_data.csv";
#elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+"Saved_data.csv";
#elif WINDOWS_UWP
        return Application.persistentDataPath  + "/" + "Saved_data.csv";
#else
        return Application.dataPath + "/CSV/";
#endif
    }


    void Start()
    {
        // prepares app state on start
        
        //  mutable string of characters for keeping the values before saving 
        sb = new StringBuilder();

        // opens CVS using specific for OS path
        // on HoloLens 2 .csv file will be saved on "User Folders\LocalAppData\<AppName>\LocalState\CSV\"
        // saved files can be obrained via Windows Device Portal after HoloLens was connected to a WiFi (Windows Docs!)
        OpenCSVFile();

        
        
        // original 
        //Save();
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


    void OpenCSVFile() 
    {
        //  retriving the relative path as device platform
        string filePath = getPath() + DateTime.Now.ToString("yyyyMMdd_HHmm") + "_saved.csv";

        //  Creates or opens a file for writing UTF-8 encoded text.
        //  If the file already exists, its contents are overwritten.
        //  By using a timestamp in file name it is supposed to creare a new csv file
        //  for every start of HoloLens Application
        StreamWriter outStream = System.IO.File.CreateText(filePath);
    }


    void writeFrameToCSV(StringBuilder sb)
    { 
    }


    void Save()
    {

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[3];
        rowDataTemp[0] = "Name";
        rowDataTemp[1] = "ID";
        rowDataTemp[2] = "Income";
        rowData.Add(rowDataTemp);

        // You can add up the values in as many cells as you want.
        for (int i = 0; i < 10; i++)
        {
            rowDataTemp = new string[3];
            rowDataTemp[0] = "Sushanta" + i; // name
            rowDataTemp[1] = "" + i; // ID
            rowDataTemp[2] = "$" + UnityEngine.Random.Range(5000, 10000); // Income
            rowData.Add(rowDataTemp);
        }

        string[][] output = new string[rowData.Count][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int length = output.GetLength(0);
        string delimiter = ",";

        StringBuilder sb = new StringBuilder();

        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));


        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

}
