using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private GameObject mainCamera;

	// Use this for initialization
	void Start ()
	{
        // Set Camera to new player
	    mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
	    mainCamera.GetComponent<CameraFollow>().SetCameraToTarget(this.transform);
	}
}
