using UnityEngine;
using System.Collections;

public class canvasLook : MonoBehaviour {

    public GameObject my_camera;
	// Use this for initialization
	void Start () {
        my_camera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(transform.position + my_camera.transform.rotation * Vector3.forward, my_camera.transform.rotation * Vector3.up);
       
	}
}
