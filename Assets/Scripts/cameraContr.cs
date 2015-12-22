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
    public GameObject camera_object;
    public bool on_terrain;

    public Vector3 zoom_start;
    public Vector3 zoom_end;
    public float speed = 3;
    #endregion

    void Start () {
        camera_object = Camera.main.gameObject;
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
        if(Input.touchCount == 1)
        {
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

                    camera_object.transform.position += start_point - end_point;




                }

            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touchzero = Input.GetTouch(0);
            Touch toucheone = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchzero.position - touchzero.deltaPosition;
            Vector2 touchOnePrevPos = toucheone.position - toucheone.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchdeltaMag = (touchzero.position - toucheone.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchdeltaMag;

            Camera.main.fieldOfView += deltaMagnitudeDiff * speed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 41.9f, 86.9f);
        }
           
        if(Input.GetMouseButtonUp(0))
        {
            camera_move = false;
        }
        
        
	}
}
