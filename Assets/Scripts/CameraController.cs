using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float accelerationFactor = 0.2f;
    // How much we want to reduce % each tick without
    public float dampeningFactor = 0.2f;
    public float maxSpeed = 30f;
    private Vector3 acceleration = new(0, 0, 0);
    private Vector3 velocity = new(0, 0, 0);


    public float mouseSensitivity = 100.0f;
	public float clampAngle = 80.0f;

	private float rotY = 0.0f; // rotation around the up/y axis
	private float rotX = 0.0f; // rotation around the right/x axis

    public enum ViewState { Locked, Unlocked}

    public ViewState currentMode = ViewState.Locked;
    // Start is called before the first frame update
    void Start()
    {
        if (currentMode == ViewState.Locked) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;  
        }
        Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
		float mouseY = -Input.GetAxis("Mouse Y");

		rotY += mouseX * mouseSensitivity * Time.deltaTime;
        // Note: rotX is the up down visibility
		rotX += mouseY * mouseSensitivity * Time.deltaTime;

		// rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);

        if (currentMode == ViewState.Locked) {
		    transform.rotation = localRotation;
        }
        
        print(rotX);

        // TODO: Get our current direction and apply it to the direction
        // Vector3 currentDirection = new(Math.Abs(rotX))
        
        if (Input.GetKey(KeyCode.A)) {

            velocity += accelerationFactor * Vector3.left * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            velocity += accelerationFactor * Vector3.right * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W)) {
            velocity += accelerationFactor * Vector3.forward * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            velocity += accelerationFactor * Vector3.back * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.P)) {
            if (currentMode == ViewState.Unlocked) {
                currentMode = ViewState.Locked;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            } else {
                currentMode = ViewState.Unlocked;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        velocity[0] = Mathf.Min(maxSpeed, velocity[0]);
        velocity[1] = Mathf.Min(maxSpeed, velocity[1]);
        velocity[2] = Mathf.Min(maxSpeed, velocity[2]);

        transform.position += Time.deltaTime * velocity;

    }
}
