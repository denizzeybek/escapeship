using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	[Range (50, 500)]
	public float sens;

	public Transform body;

	float xRot = 0f;

	public Transform leaner;
	public float zRot;
	bool isRotating;


	private void Start ()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	// Update is called once per frame
	void Update ()
	{
		#region Camera Movement

		float rotX = Input.GetAxis ("Mouse X") * sens * Time.deltaTime;
		float rotY = Input.GetAxis ("Mouse Y") * sens * Time.deltaTime;

		xRot -= rotY;
		transform.localRotation = Quaternion.Euler (xRot, 0f, 0f);


		xRot = Mathf.Clamp (xRot, -80f, 80f);

		body.Rotate (Vector3.up * rotX);
		#endregion

		#region Camera Lean
		if (Input.GetKey (KeyCode.E))
		{
			zRot = Mathf.Lerp (zRot, -20.0f, 5f * Time.deltaTime);
			isRotating = true;
		}
		if (Input.GetKey (KeyCode.Q))
		{
			zRot = Mathf.Lerp (zRot, 20.0f, 5f * Time.deltaTime);
			isRotating = true;
		}
		if (Input.GetKey (KeyCode.E) || Input.GetKey (KeyCode.Q))
		{
			isRotating = false;

		}
		if(!isRotating)
		{
			zRot = Mathf.Lerp (zRot, 0.0f, 5f * Time.deltaTime); 
		}

		leaner.localRotation = Quaternion.Euler (0, 0, zRot);

		#endregion
	}
}
