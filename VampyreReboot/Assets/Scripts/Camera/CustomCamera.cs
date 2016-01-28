// <summary>
/// Custom Camera.cs
/// 03-12-13
/// M A Plant
/// 
/// This script is directly responsible for control of all camera related functions and tracking
/// It should act more natural than the preset Unity one
/// </summary>
using UnityEngine;
using System.Collections;


[AddComponentMenu("Custom/Camera Control/3rd Camera")]
public class CustomCamera : MonoBehaviour {
	public Transform target;
	public string cameraTagName = "Camera Target";

	public float minDistance;
	public float maxDistance;
	public float height;
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;

	private Transform _myTransform;
	private float _x;
	private float _y;
	private bool _ButtonPressed = false;
	private bool _RotateKeyPressed = false;

	void Awake(){
		_myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		if(target == null)
			Debug.LogWarning("No Target Found");
		else{
			CameraSetup();
		}
	}

	// This function is called once per frame
	void Update(){
		if(Input.GetButtonDown("Rotate Camera Button"))
			_ButtonPressed = true;

		if(Input.GetButtonUp("Rotate Camera Button")){
			_x = 0;
			_y = 0;
			_ButtonPressed = false;
		}
		if(Input.GetButtonDown("Rotate Camera Horizontal Buttons") || Input.GetButtonDown("Rotate Camera Vertical Buttons"))
			_RotateKeyPressed = true;
		
		if(Input.GetButtonUp("Rotate Camera Horizontal Buttons") || Input.GetButtonUp("Rotate Camera Vertical Buttons")){
			_x = 0;
			_y = 0;
			_RotateKeyPressed = false;
		}
	}

	// This function is called after all other UPDATE functions are called
	void LateUpdate(){
		if(_RotateKeyPressed){					// Use the Input Manager to make this User Definable
			_x += Input.GetAxis("Rotate Camera Horizontal Buttons") * xSpeed * 0.02f;
			_y -= Input.GetAxis("Rotate Camera Vertical Buttons") * ySpeed * 0.02f; 

			RotateCamera();
		}
		else if(target != null){
			if(_ButtonPressed){					// Use the Input Manager to make this User Definable
				_x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				_y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f; 
				
//				y = ClampAngle(y, yMinLimit, yMaxLimit);

				RotateCamera();
			}
			else{
	//			_myTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - minDistance);
	//			_myTransform.LookAt(target);

				// Calculate the current rotation angles
				float wantedRotationAngle = target.eulerAngles.y;
				float wantedHeight = target.position.y + height;
				
				float currentRotationAngle = _myTransform.eulerAngles.y;
				float currentHeight = _myTransform.position.y;
				
				// Damp the rotation around the y-axis
				currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
				
				// Damp the height
				currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
				
				// Convert the angle into a rotation
				Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
				
				// Set the position of the camera on the x-z plane to:
				// distance meters behind the target
				_myTransform.position = target.position;
				_myTransform.position -= currentRotation * Vector3.forward * minDistance;
				
				// Set the height of the camera
				_myTransform.position = new Vector3(_myTransform.position.x, currentHeight, _myTransform.position.z);
				
				// Always look at the target
				_myTransform.LookAt(target);
			}
		}
		else {
			GameObject gotemp = GameObject.FindGameObjectWithTag(cameraTagName);
		}
	}

	private void RotateCamera(){
		Quaternion rotation = Quaternion.Euler(_y, _x, 0);
		Vector3 position = rotation * new Vector3(0.0f, 0.0f, -minDistance) + target.position;
		
		_myTransform.rotation = rotation;
		_myTransform.position = position;
}
	// Automatically sets the camera to a defaulted position
	public void CameraSetup(){
		_myTransform.position = new Vector3(target.position.x, target.position.y + height, target.position.z - minDistance);
		_myTransform.LookAt(target);
	}
}
