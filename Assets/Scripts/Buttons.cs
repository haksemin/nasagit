using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void SahneDegistir(string sahne)
    {
        SceneManager.LoadScene(sahne);
    }
}
