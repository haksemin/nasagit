using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float rotationSpeed = 50.0f;
    public float moveSpeed = 10.0f;
    public float maxRotationX = 45.0f; // Maksimum eðilme açýsý
    public float minRotationX = -45.0f; // Minimum eðilme açýsý
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
            // A ve D tuþlarýna göre saða ve sola dönme
            RotateSideways();

            // Ok yukarý ve aþaðý tuþlarýyla yukarý ve aþaðý eðilme
            TiltUpDownWithArrowKeys();

            // W tuþuna basýldýðýnda ileri gitme
            MoveForward();

            // Ctrl tuþuna basýldýðýnda alçalma
            Descend();

            // Space tuþuna basýldýðýnda yükselme
            Ascend();
        }
       
    }

    void RotateSideways()
    {
        // A tuþuna basýldýðýnda sola, D tuþuna basýldýðýnda saða dönme
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotationY = transform.rotation.eulerAngles.y + horizontalInput * rotationSpeed * Time.deltaTime;

        float rotationX = transform.rotation.eulerAngles.x;

        // Sýnýrlarý kontrol et
        if (rotationX > 180.0f)
        {
            rotationX -= 360.0f;
        }

        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX); // Eðilme açýsýný sýnýrla

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
    }

    void TiltUpDownWithArrowKeys()
    {
        // Ok yukarý tuþuyla yukarý eðilme
        if (Input.GetKey(KeyCode.UpArrow))
        {
            TiltUpDown(-1); // Eðilme deðerini azalt
        }
        // Ok aþaðý tuþuyla aþaðý eðilme
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            TiltUpDown(1); // Eðilme deðerini artýr
        }
    }

    void TiltUpDown(int direction)
    {
        float rotationX = transform.rotation.eulerAngles.x + direction * rotationSpeed * Time.deltaTime;

        // Sýnýrlarý kontrol et
        if (rotationX > 180.0f)
        {
            rotationX -= 360.0f;
        }

        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX); // Eðilme açýsýný sýnýrla
        float rotationZ = transform.rotation.eulerAngles.z; // Z eksenindeki rotasyonu koru
        transform.rotation = Quaternion.Euler(rotationX, transform.rotation.eulerAngles.y, rotationZ);
    }

    void MoveForward()
    {
        // W tuþuna basýldýðýnda ileri gitme
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
        // Ctrl tuþuna basýldýðýnda alçalma
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.down * verticalSpeed * Time.deltaTime);
        }
    }

    void Ascend()
    {
        // Space tuþuna basýldýðýnda yükselme
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime);
        }
    }
}
