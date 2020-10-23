using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSpeed = 100f;
    [SerializeField] Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime - делает поворот более плавным.
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        player.Rotate(Vector3.up * mouseX);
    }
}
