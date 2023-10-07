using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShip : MonoBehaviour
{
    public Transform shipPosition,characterPosition;
    public GameObject FpsCharacter, TpsCamera , info;
    public GameObject dayi, nitro;
    public static bool isInShip = false;
    void Start()
    {
        
    }

    void Update()
    {
        GetVehicle();
        Info();
    }
    void Info()
    {
        if(!isInShip & ShipKey.canGetShip)
        {
            info.SetActive(true);
        }
        else if(isInShip || !ShipKey.canGetShip)
        {
            info.SetActive(false);
        }
    }
    void GetVehicle()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isInShip)
            {
                if (ShipKey.canGetShip)
                {
                    FpsCharacter.SetActive(false);
                    TpsCamera.SetActive(true);
                    dayi.SetActive(true);
                    nitro.SetActive(true);
                    shipPosition.GetComponent<Rigidbody>().useGravity = false;
                    isInShip = true;
                    
                }
                
            }
            else
            {
                TpsCamera.SetActive(false);
                characterPosition.position = new Vector3(shipPosition.position.x, shipPosition.position.y+5f , shipPosition.position.z);
                FpsCharacter.SetActive(true);
                dayi.SetActive(false);
                nitro.SetActive(false);
                shipPosition.GetComponent<Rigidbody>().useGravity = true;
                isInShip = false;
            }
        }
    }
}
