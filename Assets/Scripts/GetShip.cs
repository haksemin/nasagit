using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetShip : MonoBehaviour
{
    public Transform shipPosition,characterPosition;
    public GameObject FpsCharacter, TpsCamera;
    public static bool isInShip = false;
    void Start()
    {
        
    }

    void Update()
    {
        GetVehicle();
    }
    void GetVehicle()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isInShip)
            {
                FpsCharacter.SetActive(false);
                TpsCamera.SetActive(true);
                isInShip = true;
            }
            else
            {
                TpsCamera.SetActive(false);
                characterPosition.position = new Vector3(shipPosition.position.x, shipPosition.position.y+5f , shipPosition.position.z);
                FpsCharacter.SetActive(true);
                isInShip = false;
            }
        }
    }
}
