using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour
{

    public float cameraSpeed = 20.0f;
    public GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 position = transform.position;
		if (Input.GetKey(KeyCode.RightArrow)) {
			position += Vector3.right * cameraSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			position += Vector3.left* cameraSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			position += Vector3.forward * cameraSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			position += Vector3.back* cameraSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.Equals)) {
			position += Vector3.up * cameraSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.Minus)) {
			position += Vector3.down * cameraSpeed * Time.deltaTime;
		}
        transform.position = position;
        transform.LookAt(focalPoint.transform.position);
    }
}
