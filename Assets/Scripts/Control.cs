using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour

{
    //******Класс Оперирующий Элементы управления******\\

    #region Variables
    public DataBase DB;
    public Vector3 position_to_go; //Позиция Гекса куда нужно добраться
    public GameObject target_object; //Целевой Гекс куда движутс
    public Navigator nvg;
    
    public Vector3 start_point;
    public Vector3 end_point;
    public bool camera_move = false;
    public float distance;
    public GameObject camera;
    public float min_pos_x;
    public float max_pos_x;
    public float min_pos_y;
    public float max_pos_y;
    public GameObject navigator_object;
    #endregion
    void Start()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        target_object = gameObject;
       
        
    }
    public void InsNavigator()
    {
        nvg = GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>();
    }
    void Update()
    {
        /*
        Ray first_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray second_ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.touchCount == 1)
        {
            if(Input.GetMouseButtonDown(0))
            {
                start_point = first_ray.GetPoint(10);
                start_point.z = 0;
                camera_move = true;
            }
            if(camera_move)
            {
                distance = Mathf.Clamp(Vector3.Distance(end_point, start_point), 0, 1.0);
                end_point = second_ray.GetPoint(10);
                end_point.z = 0;
                 
                if(distance >= 0.1)
                {
                    camera.transform.position += start_point - end_point;
                    camera.transform.position.x = Mathf.Clamp(transform.position.x, min_pos_x, max_pos_x);
                    camera.transform.position.y = Mathf.Clamp(transform.position.y, min_pos_y, max_pos_y);
                }

            }
        }*/
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            
            
            
            
            
            if (hit.collider.gameObject.tag == "Hex")
            {
                
                foreach (GameObject obj in DB.hex_comb)
                {
                    if (hit.collider.gameObject == obj)
                    {
                        if(DB.chose_unit.Count == 1)
                        {
                            Instantiate(navigator_object, DB.chose_unit[0].transform.position, Quaternion.identity);
                            InsNavigator(); 
                            nvg.nna = true;
                        }
                        
                        position_to_go = obj.transform.position;
                        if(target_object.transform.position == position_to_go && nvg != null)
                        {
                                nvg.End_move();
                                DB.Clear_select_list();
                        }
                        
                        DB.Path.Clear();
                        
                        
                    }
                }
            }
            
                        else if(hit.collider.gameObject.tag == "player_unit")
                        {
                            Debug.Log("Попал в юнита");
                            DB.Clear_select_list();
                            foreach(GameObject unit in DB.player_units)
                            {
                                if (hit.collider.gameObject == unit)
                                {
                                    Debug.Log("Отобрал юнита");
                                    unit.GetComponent<Unit>().Unit_Chouse();
                                }
                            }
                        }
                                    else
                                    {
                                        Debug.Log("Что то не так");
                                    }
        }

    }
}



