using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

	void Start () {
        motor = GetComponent<PlayerMotor>();		
	}
	
	// Update is called once per frame
	void Update () {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocty = (movHorizontal + movVertical).normalized * speed;

        motor.Move(velocty);

        // Y rotation
        float yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRotation, 0f) * lookSensitivity;

        //Apply rotation now
        motor.Rotate(rotation);

        //X rotation
        float xRotation = Input.GetAxisRaw("Mouse Y");
        Vector3 cameraRotation = new Vector3(xRotation, 0f, 0f) * lookSensitivity;

        //Apply rotation of camera now
        motor.RotateCamera(cameraRotation);
    }
}
