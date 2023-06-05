using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRotating : MonoBehaviour
{
    public Transform cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectsWithTag("MainCamera")[0].transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
