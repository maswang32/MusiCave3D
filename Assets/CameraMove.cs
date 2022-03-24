using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //public float turnSpeed = 4.0f;
    //public float moveSpeed = 2.0f;

    //public float minTurnAngle = -90.0f;
    //public float maxTurnAngle = 90.0f;
    //private float rotX;

    public int movementspeed = 1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        /*if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * 10 * Time.deltaTime);
        }*/

        // get the mouse inputs
        //float y = Input.GetAxis("Mouse X") * turnSpeed;
        //rotX += Input.GetAxis("Mouse Y") * turnSpeed;

        // clamp the vertical rotation
        //rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

        // rotate the camera
        //transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }
}
