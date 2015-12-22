using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour

{
    //******Класс Оперирующий Элементы управления******\\

    #region Variables
    private DataBase DB;
    private BattleCalculator BC;
    public Vector3 position_to_go; //Позиция Гекса куда нужно добраться
    public GameObject target_object; //Обьект (юнит) от которого мерится дистнция до целевого гекса
    public int count_of_Turns= 0;
    private GameObject enemy_correct;
    #endregion
    void Start()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        BC = GameObject.FindGameObjectWithTag("Logic").GetComponent<BattleCalculator>();
        target_object = gameObject;
        
    }
   
   
    void Update(){
        
            if(Input.GetMouseButtonDown(0))
            {
                
                if(DB.enemy_chose.Count == 1)
                {
                    DB.enemy_chose[0].GetComponent<Unit>().Enemy_Chose();
                }
                if(DB.city_selected.Count == 1)
                {
                    DB.city_selected[0].GetComponent<city>().City_Chosen();
                }
                
                
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            if (hit.collider.gameObject.tag == "Hex"){
                if(enemy_correct != null)
                {
                    enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
                    enemy_correct = null;
                }
               
                foreach (GameObject obj in DB.hex_comb){
                    if (hit.collider.gameObject == obj){
                        position_to_go = obj.transform.position;
                            if(DB.chose_unit.Count == 1){
                                
                                
                                GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().nna = true;
                                if (target_object.transform.position == position_to_go)
                                {
                                    GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().End_move();
                                    DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();

                                }
                            }
                            else
                            {
                                if(obj.GetComponent<HexComb>().city_on_hex != null)
                                {
                                    obj.GetComponent<HexComb>().city_on_hex.GetComponent<city>().City_Chosen();
                                }
                                
                            }
                                    
                                    target_object = obj;
                                    DB.Path.Clear();
                        
                    }
                }
            }
            
                        else if(hit.collider.gameObject.tag == "player_unit"){
                            if (enemy_correct != null)
                            {
                                enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
                                enemy_correct = null;
                            }
                            
                            if(DB.chose_unit.Count == 1){
                           
                                if(DB.chose_unit[0].tag == "Army")
                                {
                                    DB.chose_unit[0].GetComponent<Army>().Army_Chose();
                                }
                                else
                                {
                                    DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
                                }
                                
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
                                
                                    DB.chose_unit[0].GetComponent<Unit>().Unit_rotation(enemy, enemy);
                                    hit.collider.gameObject.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(4);
                                    if(hit.collider.gameObject == enemy_correct)
                                    {
                                    BC.BattleModeller(DB.chose_unit[0], enemy);
                                    enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
                                    enemy_correct = null;
                                        
                                    }
                                    else
                                    {
                                        if (enemy_correct != null)
                                        {
                                            enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
                                            enemy_correct = null;
                                        }
                                    }
                                    enemy_correct = hit.collider.gameObject;
                                    
                                
                                
                                
                            }
                            break;
                        }
                    }
                }
                else
                {
                    foreach(GameObject gj in DB.enemy_units)
                    {
                        if(hit.collider.gameObject == gj)
                        {
                            gj.GetComponent<Unit>().Enemy_Chose();
                        }
                    }
                }

                    
                }
            else if (hit.collider.gameObject.tag == "Army")
            {
                if (DB.chose_unit.Count == 1)
                {

                    if (DB.chose_unit[0].tag == "Army")
                    {
                        DB.chose_unit[0].GetComponent<Army>().Army_Chose();
                    }
                    DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
                }
               hit.collider.gameObject.GetComponent<Army>().Army_Chose();
                
                
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
        
        }
        foreach (GameObject ct in DB.all_cities)
        {
            ct.GetComponent<city>().Money_pay();
            
        }
        if(DB.chose_unit.Count == 1)
        {
            DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
        }
        
    }
   

    }




