using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Car : BaseCar
{
    private List<Transform> nodes;
    private int currNode;
    public GameObject path;

    private void Start()
    {
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>(pathTransforms.Length);

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    public override void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currNode].position) < 2f && currNode < nodes.Count - 1)
        {
            currNode++;
        }
    }

    public override void ApplySteer()
    {
        Vector3 reletiveVector = transform.InverseTransformPoint(nodes[currNode].position);
        float newSteer = (reletiveVector.x / reletiveVector.magnitude) * maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFL.steerAngle = newSteer;
    }

    private void FixedUpdate()
    {
        Sensor();
        CheckSensors();
        ApplySteer();
        StartEngine();
        CheckWaypointDistance();
        StopEngine();
    }
}
