using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsCamera : MonoBehaviour
{
    public Transform target; // Arac�n Transform bile�eni

    public float distance = 5.0f; // Kamera ile ara� aras�ndaki mesafe
    public float height = 2.0f; // Kamera y�ksekli�i
    public float damping = 5.0f; // Kamera hareketindeki yumu�akl�k

    void Update()
    {
        // Hedefin bulundu�u konuma do�ru bir vekt�r olu�tur
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * height;

        // Hedefin bulundu�u konuma do�ru yumu�ak bir �ekilde ilerle
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);

        // Hedefin y�n�ne bak
        transform.LookAt(target.position);
    }
}
