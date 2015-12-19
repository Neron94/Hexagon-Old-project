using UnityEngine;
using System.Collections;

public class cameraContr : MonoBehaviour {
   

    /// <Описание>
    /// Класс Оперирует Управлением камеры
    /// </Описание>


    #region Variables
    public Vector3 start_point;
    public Vector3 end_point;
    public bool camera_move = false;
    public float distance;
    public GameObject camera;
    public bool on_terrain;
    
    #endregion

    void Start () {
	
	}
	void Update () {
        
        Ray first_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray second_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        /*Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hiit;
        Physics.Raycast(ray, out hiit, Mathf.Infinity);
        
        ДОДЕЛАТЬ ОГРАНИЧИТЕЛЬ КАМЕРЫ
         
        if(hiit.collider)
        {
            on_terrain = true;
        }
        else
        {
            on_terrain = false;
        }*/
            if (Input.GetMouseButtonDown(0))
            {
                start_point = first_ray.GetPoint(40);
                start_point.y = 0;
                camera_move = true;
            }
            if (camera_move)
            {
                distance = Mathf.Clamp(Vector3.Distance(end_point, start_point), 0.0f, 1.0f);
                end_point = second_ray.GetPoint(40);
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
