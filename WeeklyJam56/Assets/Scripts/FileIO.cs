using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileIO : MonoBehaviour {

    private TimeRecord timeRecord;

    string filePath = "Assets\\Resources\\Replays\\";
    public string fileName;

    private List<PointInTime> pointsInTimeToSave;

    public List<PointInTime> loadedPointsInTime = new List<PointInTime>();
    private List<Vector3> loadedPositions;
    private List<Quaternion> loadedRotations;

    private void Start()
    {
        timeRecord = GetComponent<TimeRecord>();
        LoadReplay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SaveReplay();
        }

    }

    public void SaveReplay()
    {
        GetInfoToSave();
        string newfileName = filePath + fileName + ".txt";
        StreamWriter writer = new StreamWriter(newfileName);

        //Populate
        while (pointsInTimeToSave.Count > 0)
        {
            PointInTime pointInTime = pointsInTimeToSave[0];
            string tmpPos = pointInTime.position.x.ToString() + ":" +
                pointInTime.position.y.ToString() + ":" +
                pointInTime.position.z.ToString();

            string tmpRot = pointInTime.rotation.x.ToString() + ":" +
                pointInTime.rotation.y.ToString() + ":" +
                pointInTime.rotation.z.ToString() + ":" +
                pointInTime.rotation.w.ToString();

            string output = tmpPos + ":" + tmpRot;
            writer.WriteLine(output);
            pointsInTimeToSave.RemoveAt(0);
            //print(output);
        }
        writer.Close();
    }

    private void GetInfoToSave()
    {
        pointsInTimeToSave = new List<PointInTime>();
        for (int i = 0; i < timeRecord.pointsInTime_ToSave.Count; i++)
        {
            pointsInTimeToSave.Add(timeRecord.pointsInTime_ToSave[i]);
        }
    }

    public void LoadReplay()
    {
        loadedPositions = new List<Vector3>();
        loadedRotations = new List<Quaternion>();
        ReadFromFile();
        for (int i = 0; i < loadedPointsInTime.Count; i++)
        {
            timeRecord.pointsInTime_Loaded.Add(loadedPointsInTime[i]);
        }
    }

    private void ReadFromFile()
    {
        string fileToReadName = filePath + fileName + ".txt";
        if (!File.Exists(fileToReadName))
        {
            print("File not found");
            return;
        }
        StreamReader reader = new StreamReader(fileToReadName);
        

        string s = reader.ReadLine();

        while (s != null)
        {
            char[] delimiter = { ':' };
            string[] fields = s.Split(delimiter);
            loadedPositions.Add(new Vector3
                (Convert.ToSingle(fields[0]), Convert.ToSingle(fields[1]), Convert.ToSingle(fields[2])));
            loadedRotations.Add(new Quaternion
                (Convert.ToSingle(fields[3]), Convert.ToSingle(fields[4]), Convert.ToSingle(fields[5]),Convert.ToSingle(fields[6])));
            s = reader.ReadLine();
        }

        for (int i = 0; i < loadedPositions.Count; i++)
        {
            loadedPointsInTime.Add(new PointInTime(loadedPositions[i], loadedRotations[i]));
        }
    }

}