using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject lights;
    private Transform[] lightStatus;
    public Collider currCollider;
    public bool flag;
    void Start()
    {
        lightStatus = lights.GetComponentsInChildren<Transform>();
        currCollider = GetComponent<Collider>();
    }

    void Update()
    {
        if(!flag)
            CheckLights();
    }

    private void CheckLights()
    {
        if (lightStatus[1].GetComponent<Light>().enabled)
            currCollider.enabled = false;
        else
            currCollider.enabled = true;
    }
}
