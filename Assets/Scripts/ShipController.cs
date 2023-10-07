using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public float moveSpeed = 10.0f;
    public float maxRotationX = 45.0f; // Maksimum e�ilme a��s�
    public float minRotationX = -45.0f; // Minimum e�ilme a��s�
    public float verticalSpeed = 5.0f;

    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (GetShip.isInShip)
        {
            // A ve D tu�lar�na g�re sa�a ve sola d�nme
            RotateSideways();

            // Ok yukar� ve a�a�� tu�lar�yla yukar� ve a�a�� e�ilme
            TiltUpDownWithArrowKeys();

            // W tu�una bas�ld���nda ileri gitme
            MoveForward();

            // Ctrl tu�una bas�ld���nda al�alma
            Descend();

            // Space tu�una bas�ld���nda y�kselme
            Ascend();
        }
       
    }

    void RotateSideways()
    {
        // A tu�una bas�ld���nda sola, D tu�una bas�ld���nda sa�a d�nme
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationY = transform.rotation.eulerAngles.y + horizontalInput * rotationSpeed * Time.deltaTime;

        float rotationX = transform.rotation.eulerAngles.x;

        // S�n�rlar� kontrol et
        if (rotationX > 180.0f)
        {
            rotationX -= 360.0f;
        }

        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX); // E�ilme a��s�n� s�n�rla

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
    }

    void TiltUpDownWithArrowKeys()
    {
        // Ok yukar� tu�uyla yukar� e�ilme
        if (Input.GetKey(KeyCode.UpArrow))
        {
            TiltUpDown(-1); // E�ilme de�erini azalt
        }
        // Ok a�a�� tu�uyla a�a�� e�ilme
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            TiltUpDown(1); // E�ilme de�erini art�r
        }
    }

    void TiltUpDown(int direction)
    {
        float rotationX = transform.rotation.eulerAngles.x + direction * rotationSpeed * Time.deltaTime;

        // S�n�rlar� kontrol et
        if (rotationX > 180.0f)
        {
            rotationX -= 360.0f;
        }

        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX); // E�ilme a��s�n� s�n�rla
        float rotationZ = transform.rotation.eulerAngles.z; // Z eksenindeki rotasyonu koru
        transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y, rotationZ);
    }

    void MoveForward()
    {
        // W tu�una bas�ld���nda ileri gitme
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.zero;
        }
    }

    void Descend()
    {
        // Ctrl tu�una bas�ld���nda al�alma
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
        }
    }

    void Ascend()
    {
        // Space tu�una bas�ld���nda y�kselme
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        }
    }
}
