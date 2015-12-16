using UnityEngine;
using System.Collections;

public class cameraContr : MonoBehaviour {
   
    public Vector3 start_point;
    public Vector3 end_point;
    public bool camera_move = false;
    public float distance;
    public GameObject camera;
    public float min_pos_x;
    public float max_pos_x;
    public float min_pos_y;
    public float max_pos_y;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Ray first_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray second_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      
            if (Input.GetMouseButtonDown(0))
            {
                start_point = first_ray.GetPoint(10);
                start_point.y = 0;
                camera_move = true;
            }
            if (camera_move)
            {
                distance = Mathf.Clamp(Vector3.Distance(end_point, start_point), 0.0f, 1.0f);
                end_point = second_ray.GetPoint(10);
                end_point.y = 0;

                if (distance >= 0.1)
                {
                    camera.transform.position += start_point - end_point;

                }

            }
        if(Input.GetMouseButtonUp(0))
        {
            camera_move = false;
        }
        
        
	}
}
