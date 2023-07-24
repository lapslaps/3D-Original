using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectController : MonoBehaviour
{
    public float rotateSpeed = 0.5f;
    float delta = 0;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        speed += speed < 0 ? -PlayerController.gameLevel : PlayerController.gameLevel;
    }

    // Update is called once per frame
    void Update()
    {
        delta += 1;
        this.transform.Rotate(0, rotateSpeed, rotateSpeed);
        this.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, 0);
    }

    public void ObjectDestroy()
    {
        Destroy(this.gameObject);
    }
}