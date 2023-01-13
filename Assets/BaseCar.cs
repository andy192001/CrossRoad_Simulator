using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCar : MonoBehaviour
{
    public float weight;
    public float maxSpeed;
    public float maxSteerAngle;

    // Colliders
    public WheelCollider wheelFL;
    public WheelCollider wheelFW;
    public WheelCollider wheelRL;
    public WheelCollider wheelRW;

    // Sensors
    private float sensorLength = 7f;

    private float currSpeed;

    public virtual void Sensor()
    {
        RaycastHit hit;                                                 // information about object collider hit with
        Vector3 sensorStartPosition = transform.position + new Vector3(0, 1, 0);

        // center
        if (Physics.Raycast(sensorStartPosition, transform.forward, out hit, sensorLength))
            sensors[0] = true;
        else
            sensors[0] = false;
        Debug.DrawLine(sensorStartPosition, hit.point);
        
        // right
        sensorStartPosition.z += 0.8f;
        if (Physics.Raycast(sensorStartPosition, transform.forward, out hit, sensorLength))
            sensors[1] = true;
        else
            sensors[1] = false;
        Debug.DrawLine(sensorStartPosition, hit.point);

        // angle right
        if (Physics.Raycast(sensorStartPosition, Quaternion.AngleAxis(15, transform.up) * transform.forward, out hit, 8.7f))
            sensors[2] = true;
        else
            sensors[2] = false;
        Debug.DrawLine(sensorStartPosition, hit.point);

        // left
        sensorStartPosition.z -= 2 * 0.8f;
        if (Physics.Raycast(sensorStartPosition, transform.forward, out hit, sensorLength))
            sensors[3] = true;
        else
            sensors[3] = false;
        Debug.DrawLine(sensorStartPosition, hit.point);

        // angle left
        if (Physics.Raycast(sensorStartPosition, Quaternion.AngleAxis(-15, transform.up) * transform.forward, out hit, 8.7f))
            sensors[4] = true;
        else
            sensors[4] = false;
        Debug.DrawLine(sensorStartPosition, hit.point);

    }

    private bool[] sensors = new bool[5];
    public void CheckSensors()
    {
        bool allUnabled = true;
        foreach(var sensor in sensors)
        {
            if (sensor)
                allUnabled = false; 
                
        }
        if (allUnabled)
            isBraking = false;
        else
            isBraking = true;
    }

    public bool isBraking = false;
    public virtual void StopEngine()
    {
        if (isBraking)
        {
            wheelRL.brakeTorque = 600f;
            wheelRW.brakeTorque = 600f;
        }
        else
        {
            wheelRL.brakeTorque = 0;
            wheelRW.brakeTorque = 0;
        }
    }

    public virtual void StartEngine()
    {
        currSpeed = (float)(2 * Math.PI * wheelFL.radius * wheelFL.rpm * 60 / weight);
        if (currSpeed < maxSpeed && !isBraking)
        {
            wheelFL.motorTorque = 300f;
            wheelFW.motorTorque = 300f;
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFW.motorTorque = 0;
        }
    }

    public abstract void CheckWaypointDistance();

    public abstract void ApplySteer();

}
