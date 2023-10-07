using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsCamera : MonoBehaviour
{
    public Transform target; // Aracýn Transform bileþeni

    public float distance = 5.0f; // Kamera ile araç arasýndaki mesafe
    public float height = 2.0f; // Kamera yüksekliði
    public float damping = 5.0f; // Kamera hareketindeki yumuþaklýk

    void Update()
    {
        // Hedefin bulunduðu konuma doðru bir vektör oluþtur
        Vector3 targetPosition = target.position - target.forward * distance + Vector3.up * height;

        // Hedefin bulunduðu konuma doðru yumuþak bir þekilde ilerle
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * damping);

        // Hedefin yönüne bak
        transform.LookAt(target.position);
    }
}
