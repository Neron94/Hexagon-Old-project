using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour

{
    //******Класс Оперирующий Элементы управления******\\

    #region Variables
    public DataBase DB;
    public Vector3 position_to_go; //Позиция Гекса куда нужно добраться
    public GameObject target_object; //Обьект (юнит) от которого мерится дистанция до целевого гекса
    public Vector3 start_point;
    public Vector3 end_point;
    public bool camera_move = false;
    public float distance;
    public GameObject camera;
    public float min_pos_x;
    public float max_pos_x;
    public float min_pos_y;
    public float max_pos_y;
    
    #endregion
    void Start()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        target_object = gameObject;
        
    }
   
   
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            
            if (hit.collider.gameObject.tag == "Hex"){
                foreach (GameObject obj in DB.hex_comb){
                    if (hit.collider.gameObject == obj){
                        position_to_go = obj.transform.position;
                        target_object = obj;
                        if(DB.chose_unit.Count == 1){
                            GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().nna = true;
                        }
                       
                        if(DB.chose_unit[0].transform.position == position_to_go){
                            if(DB.chose_unit.Count == 1){
                                GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().End_move();
                            }
                               
                               
                        }
                        
                        DB.Path.Clear();
                    }
                }
            }
            
                        else if(hit.collider.gameObject.tag == "player_unit"){
                            if(DB.chose_unit.Count == 1){
                                DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
                            }
                            
                            
                            foreach(GameObject unit in DB.player_units){
                                          if (hit.collider.gameObject == unit){
                                                  unit.GetComponent<Unit>().Unit_Chouse();
                                                  
                                             }
                                     }
                        }
                                   
                                    else{
                                        Debug.Log("Что то не так");
                                    }
        }

    }
}



