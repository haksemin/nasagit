using System;
using System.Collections.Generic;
using UnityEngine;

public class dondur : MonoBehaviour
{
    public float rotationSpeed = 10f;
    void Update()
    {

        
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount, Space.Self);
    }
}
