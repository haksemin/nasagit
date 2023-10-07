using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipKey : MonoBehaviour
{
    public static bool canGetShip = false;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "FPSController")
        {
            canGetShip = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FPSController")
        {
            canGetShip=false;
        }
    }
}
