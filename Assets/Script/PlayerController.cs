using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject playerCamera;
    public IroiroController forwardSensor;
    private Rigidbody rb;
    public static int gameLevel = 1;
    public static int clearLevel = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 forward = playerCamera.transform.forward; // オブジェクトが向いている方向を取得する
        forward.y = 0;
        Vector3 right = Quaternion.Euler(0, 90, 0) * forward;
        if (!forwardSensor.isSelected)
        {
            Vector3 velocity = new Vector3(0, rb.velocity.y, 0);
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            velocity = (forward * z + playerCamera.transform.right * x) * speed * Time.deltaTime;
            velocity.y = 0;
            /*
            if (Input.GetKey(KeyCode.W))
            {
                velocity.z = (forward * speed * Time.deltaTime).z;
            }
            if (Input.GetKey(KeyCode.S))
            {
                velocity.z = (-forward * speed * Time.deltaTime).z;
            }
            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = (right * speed * Time.deltaTime).x;
            }
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x = (-right * speed * Time.deltaTime).x;
            }
            if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
            }
            */
            rb.velocity = velocity;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
            Cursor.lockState = Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }

    public void SubmitText(string input)
    {
        Debug.Log(input);
    }
}
