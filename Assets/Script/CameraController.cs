using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 5f;
    public IroiroController forwardSensor;
    float mouseX;
    float mouseY;
    Vector2 cameraRotation = new Vector2(0, 0);

    void Start()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity;
    }

    void Update()
    {
        if (!Input.GetMouseButton(0) && !forwardSensor.isSelected)
        {
            mouseX = Input.GetAxis("Mouse X") * sensitivity;
            mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        }

        cameraRotation += new Vector2(mouseX, mouseY);
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -90f, 90f); // ƒJƒƒ‰‚ªŒX‚«‰ß‚¬‚È‚¢‚æ‚¤‚ÉƒNƒ‰ƒ“ƒv‚·‚é

        transform.localRotation = Quaternion.Euler(-cameraRotation.y, cameraRotation.x, 0f);
    }

}
