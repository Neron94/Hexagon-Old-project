using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour

{
    //******Класс Оперирующий Элементы управления******\\

    #region Variables
    public DataBase DB;
    public BattleCalculator BC;
    public Vector3 position_to_go; //Позиция Гекса куда нужно добраться
    public GameObject target_object; //Обьект (юнит) от которого мерится дистанция до целевого гекса
    public int count_of_Turns= 0;
    public Fractions frc;
    #endregion
    void Start()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        BC = GameObject.FindGameObjectWithTag("Logic").GetComponent<BattleCalculator>();
        target_object = gameObject;
        frc = gameObject.transform.GetComponent<Fractions>();
        
    }
   
   
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            if(frc.buy_time)
            {
                foreach(GameObject gmj in DB.arrivel_list)
                {
                    if(hit.collider.gameObject == gmj)
                    {
                       
                    }
                }
            }
            if (hit.collider.gameObject.tag == "Hex"){
                
                foreach (GameObject obj in DB.hex_comb){
                    if (hit.collider.gameObject == obj){
                        position_to_go = obj.transform.position;
                        
                            if(DB.chose_unit.Count == 1){
                                GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().nna = true;
                            }
                                    if (DB.chose_unit.Count == 1){
                                        if(target_object.transform.position == position_to_go){
                            
                                            GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().End_move();
                                            DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();

                                        }
                               
                               
                                    }
                                    target_object = obj;
                        DB.Path.Clear();
                        
                    }
                }
            }
            
                        else if(hit.collider.gameObject.tag == "player_unit"){
                            Debug.Log("Попали в юнита");
                            if(DB.chose_unit.Count == 1){
                                DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
                            }
                            
                            
                            foreach(GameObject unit in DB.player_units){
                                          if (hit.collider.gameObject == unit){
                                           
                                                  unit.GetComponent<Unit>().Unit_Chouse();
                                                  
                                             }
                                     }
                        }
            else if (hit.collider.gameObject.tag == "Enemy")
            {
                
                if(DB.chose_unit.Count == 1)
                {
                    if(DB.chose_unit[0].GetComponent<Unit>().action_points >= 2)
                    foreach(GameObject enemy in DB.enemy_units)
                    {
                      
                        if(hit.collider.gameObject == enemy)
                        {
                            
                            float enemy_Distance = Vector3.Distance(DB.chose_unit[0].transform.position, enemy.transform.position);
                            Debug.Log(enemy_Distance);
                            if(DB.chose_unit[0].GetComponent<Unit>().fire_distance > enemy_Distance)
                            {
                                
                                BC.Side_of_atack(DB.chose_unit[0], enemy);
                            }
                            break;
                        }
                    }
                }

                    
                }
            
            else
            {
                Debug.Log("Что то не так");
            }
            }
                                   
                                    
        }

    public void End_of_Turn()
    {
        foreach(GameObject units in DB.player_units)
        {
            units.GetComponent<Unit>().End_Turn();
            foreach(GameObject ct in DB.all_cities)
            {
                ct.GetComponent<city>().Money_pay();
            }
        }
        DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
    }
   

    }




