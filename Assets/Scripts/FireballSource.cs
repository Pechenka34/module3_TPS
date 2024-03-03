using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSource : MonoBehaviour
{
    public Transform targetPoint;
    public Camera cameraLink;

    private void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.7f, 0));
        Debug.Log(ray);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint.position = hit.point;
        }

        transform.LookAt(targetPoint.position);
    }
}
