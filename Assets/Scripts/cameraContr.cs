using UnityEngine;
using System.Collections;

public class cameraContr : MonoBehaviour {
   

    /// <Описание>
    /// Класс Оперирует Управлением камеры
    /// </Описание>


    #region Variables
    private StateManager SM;
    private DataBase DB;
    private  Vector3 start_point;  // обозначене первой точки начала касания для передвижения
    private  Vector3 end_point; // обозначение конечной точки движение 
    private  bool camera_move = false; // включатель движения камеры
    private float distance; // определение дистанции между стартом касания и концом
    private  GameObject camera_object; // обьект камер
    private  Vector3 zoom_start;
    private  Vector3 zoom_end;
    public  float speed = 3;

    public Vector3 cameraMove;
    public Vector3 zoom;



    #endregion

    void Start () {
        camera_object = Camera.main.gameObject;
        SM = GameObject.FindGameObjectWithTag("Logic").GetComponent<StateManager>();
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        cameraMove = camera_object.transform.position;
        zoom = camera_object.transform.position;
	}

	void Update () {


        
        if(SM.state_unit_movement)
        {
            cameraMove = camera_object.transform.position;
            camera_object.transform.position = new Vector3(DB.unit_is_moving[0].transform.position.x, zoom.y, DB.unit_is_moving[0].transform.position.z);
            cameraMove = camera_object.transform.position;
        }
     
        Ray first_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray second_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
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
                   
                    
                    cameraMove += start_point - end_point;
                    camera_object.transform.position = new Vector3(cameraMove.x = Mathf.Clamp(cameraMove.x, -5.0f, 275.0f), camera_object.transform.position.y, cameraMove.z = Mathf.Clamp(cameraMove.z, 32.0f, 334.0f));
                   
                   
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
            
            zoom.y += deltaMagnitudeDiff * speed;
            camera_object.transform.position = new Vector3(camera_object.transform.position.x,zoom.y = Mathf.Clamp(zoom.y,52.0f,115.0f),camera_object.transform.position.z);
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 41.9f, 86.9f);
        }
           
        if(Input.GetMouseButtonUp(0))
        {
            camera_move = false;
        }
        
        
	}
}
