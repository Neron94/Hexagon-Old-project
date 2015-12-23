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
    #endregion

    void Start () {
        camera_object = Camera.main.gameObject;
        SM = GameObject.FindGameObjectWithTag("Logic").GetComponent<StateManager>();
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
	}
	void Update () {
        
        if(SM.state_unit_movement)
        {          
            Camera.main.gameObject.transform.position = new Vector3(DB.unit_is_moving[0].transform.position.x, Camera.main.gameObject.transform.position.y, DB.unit_is_moving[0].transform.position.z);
            
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
