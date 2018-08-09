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

    public bool recording = false;


    public List<PointInTime> pointsInTime;

    public List<PointInTime> pointsInTime_ToSave;

    private int currentReplayFrame = 0;
    


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
        }
    }

    private void FixedUpdate()
    {
        if (recording)
        {
            Record();
        }
        else
        {
            pointsInTime_ToSave = pointsInTime;
            Replay();
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
    }

    private void Record()
    {
        PointInTime pointInTime = new PointInTime(transform.position, transform.rotation);
        pointsInTime.Add(pointInTime);
    }
}
