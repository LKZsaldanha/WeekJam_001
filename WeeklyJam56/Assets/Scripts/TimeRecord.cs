using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PointInTime {
    public Vector3 position;
    public Quaternion rotation;

    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}

public class TimeRecord : MonoBehaviour {

    public bool recording = true;
    public bool playingReplay = false;



    public bool AutoPlaySavedReplay = false;


    public List<PointInTime> pointsInTime;

    public List<PointInTime> pointsInTime_ToSave;
    public List<PointInTime> pointsInTime_Loaded = new List<PointInTime>();



    private void Start()
    {
        pointsInTime = new List<PointInTime>();
        pointsInTime_ToSave = new List<PointInTime>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            recording = false;
            pointsInTime_ToSave = pointsInTime;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            recording = false;
            playingReplay = true;
        }
    }

    private void FixedUpdate()
    {
        if (AutoPlaySavedReplay)
        {
            if (pointsInTime.Count > 0)
            {
                Replay();
            }
            else {
                recording = false;
                playingReplay = false;
                for (int i = 0; i < pointsInTime_Loaded.Count; i++)
                {
                    pointsInTime.Add(pointsInTime_Loaded[i]);
                }
            }
        }
        else
        {
            if (playingReplay)
            {
                //pointsInTime_ToSave = pointsInTime;
                Replay();
            }

            if (recording)
            {
                Record();
            }
        }
    }

    private void Replay()
    {
        if(pointsInTime.Count > 0)
        {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            pointsInTime.RemoveAt(0);
        }
        else
        {
            playingReplay = false;
        }
    }

    private void Record()
    {
        PointInTime pointInTime = new PointInTime(transform.position, transform.rotation);
        pointsInTime.Add(pointInTime);
    }
}
