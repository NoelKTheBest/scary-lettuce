using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float verticalLimit;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform body;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private float currentX;
    private float currentY;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentX = xRotation;
        currentY = yRotation;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLimit, verticalLimit);
        
        currentX = Mathf.Lerp(currentX, xRotation, smoothSpeed * Time.deltaTime);
        currentY = Mathf.Lerp(currentY, yRotation, smoothSpeed * Time.deltaTime);

        transform.rotation = Quaternion.Euler(currentX, currentY, 0);
        orientation.rotation = Quaternion.Euler(0, currentY, 0);
        body.rotation = Quaternion.Euler(0, currentY, 0);
    }
}
