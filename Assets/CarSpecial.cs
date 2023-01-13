using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpecial : BaseCar
{
    private List<Transform> nodes;
    public GameObject path;
    private int currNode;

    void Start()
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

    private void FixedUpdate()
    {
        if (!SkipLights())
        {
            Sensor();
            CheckSensors();
        }
        ApplySteer();
        StartEngine();
        CheckWaypointDistance();
        StopEngine();
    }
    private bool SkipLights()
    {
        RaycastHit hit;                                                 // information about object collider hit with
        Vector3 sensorStartPosition = transform.position + new Vector3(0, 1, 0);

        // center
        if (Physics.Raycast(sensorStartPosition, transform.forward, out hit, 8f) && hit.collider.name.Contains("lightTrigger"))
        {
            isBraking = false;
            return true;
        }
        return false;
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
}
