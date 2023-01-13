using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Color lineColor;

    private List<Transform> nodes = new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;
        // отримуємо ноди з нашого шляху да додаємо їх у List
        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes = new List<Transform>(pathTransforms.Length);
        for(int i = 0; i < pathTransforms.Length; i++)
        {
            if(pathTransforms[i] != transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }

        // Малюємо лінії, для зручного коригування маршруту
        for(int i = 0; i < nodes.Count; i++)
        {
            Vector3 currNode = nodes[i].position;
            Vector3 nextNode = nodes[(i + 1) % nodes.Count].position;

            Gizmos.DrawLine(currNode, nextNode);
            Gizmos.DrawSphere(currNode, 0.5f);
        }
    }

}
