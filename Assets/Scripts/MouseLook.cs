/*Denis Yurkov*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт поворота камеры персонажа.
public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSpeed = 100f;
    [SerializeField] Transform player;
    
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * Определяет, привязан ли аппаратный указатель к центру представления, 
         * ограничен ли он окном или вообще не ограничен. 
         * Когда заблокировано, курсор помещается в центр вида и не может быть перемещен.
         * Состояние курсора может быть изменено операционной системой или Unity.
         */
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime - делает поворот более плавным.
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime; 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

        xRotation -= mouseY;

        // Используйте Clamp, чтобы ограничить значение диапазоном, который определяется минимальным и максимальным значениями.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // localRotation - поворот относительно родительского элемента.
        // Quaternion - Кватернионы используются для обозначения поворотов.
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}
