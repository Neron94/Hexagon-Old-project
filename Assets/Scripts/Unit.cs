using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

    //*******Класс Юнита*******\\

    #region Variables
    public Control ctrl;
    public float speed = 10;
    public DataBase DB;
    public UI ui;
    public bool unit_chosen = false;
    public GameObject unit_selector;
    public int action_points = 5;
    public GameObject navigator_obj;
    public float rotation;
    public bool but_rotation = false;
    public GameObject rotation_object_direction;
    public int barrikade_power;
    public GameObject barrikade;
    public GameObject barrik_have;
    


    public string unit_type;
    public string unit_fraction;
    public int number_of_soldiers;
    public float unit_defence;
    public float unit_cur_defence;
    public int unit_cur_fire_power;
    public int unit_fire_power;
    public int fire_distance;
    public float max_hp;
    public float cur_hp;
    public Vector3 my_position;
    public GameObject my_hex;
    #endregion
    void Start () {
        ctrl = GameObject.Find("Logic").GetComponent<Control>();
        unit_selector = gameObject.transform.GetChild(0).gameObject;
        DB = GameObject.Find("Logic").GetComponent<DataBase>();
        ui = GameObject.Find("UI").GetComponent<UI>();
        my_position = gameObject.transform.position;
        DB.all_units.Add(gameObject);
        if(gameObject.tag == "player_unit")
        {
            DB.player_units.Add(gameObject);
        }
        else if(gameObject.tag == "Enemy")
        {
            DB.enemy_units.Add(gameObject);
        }
        
     
        
        }
	void Update () {

        Bonus_Calculating();
        Unit_death();

        if(but_rotation)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit, Mathf.Infinity);
                if(hit.collider.gameObject.tag == "Hex")
                {
                    foreach(GameObject gmj in DB.hex_comb)
                    {
                        if(hit.collider.gameObject == gmj)
                        {
                            rotation_object_direction =hit.collider.gameObject;
                            Unit_rotation(rotation_object_direction);
                            break;
                        }
                    }
                }
                if(hit.collider.gameObject.tag == "Enemy")
                {
                    foreach(GameObject gbj in DB.enemy_units)
                    if(gbj == hit.collider.gameObject)
                    {
                        GameObject hexik = gbj.GetComponent<Unit>().my_hex;
                        foreach(GameObject ggmg in DB.hex_eight)
                        {
                            if(hexik == ggmg)
                            {
                                rotation_object_direction = hexik;
                                Unit_rotation(rotation_object_direction);
                                break;
                            }
                        }
                        
                        break;
                    }

                }
                
            }
            
        }
        

	}
    public void Unit_death()
    {
        if (barrik_have != null)
        {
            Destroy(barrik_have);
        }
        if(cur_hp == 0)
        {
            Destroy(gameObject, 3);
        }
    }
    public void Move()
    {
        if(barrik_have != null)
        {
            Destroy(barrik_have);
        }
        for (int i = 0; action_points != 0; i++)
        {

            gameObject.transform.LookAt(ctrl.target_object.transform.position);
            gameObject.transform.position = new Vector3(DB.Path[i].x, DB.Path[i].y, DB.Path[i].z);
            action_points--;
            if(gameObject.transform.position == ctrl.position_to_go)
            {
                break;
            }
            
            
            
        }
        my_position = gameObject.transform.position;
        
        
    } // Метод движения Юнита
    public void Unit_Chouse()
    {
        if(unit_chosen == false)
        {
            
            unit_chosen = true;
            unit_selector.SetActive(unit_chosen);
            DB.chose_unit.Add(gameObject);
            Instantiate(navigator_obj, transform.position, Quaternion.identity);
            ui.ButtonHider("turnUnit");
            ui.ButtonHider("build_barrikade");
            
            
        }
        else if(unit_chosen == true)
        {
            unit_chosen = false;
            unit_selector.SetActive(unit_chosen);
            DB.chose_unit.Remove(gameObject);
            GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().Chose_another_unit();
            ui.ButtonHider("hide");
            
           
            
        }
    }

    public void Unit_rotation(GameObject gmj)
    {
        if(action_points >= 1)
        {
            
           foreach(GameObject hex in DB.hex_eight)
           {
               if(gmj == hex)
               {
                   gameObject.transform.LookAt(gmj.transform.position);
                   but_rotation = false;
                   Unit_Chouse();
                   action_points -= 1;
               }
               else
               {
                   Debug.Log("Выберите ближайший Хекс");
               }
           }
            
        }
        
    }
    public void Unit_rotation(GameObject gmj, GameObject gbb)
    {
        if (action_points >= 1)
        {

            
                    gameObject.transform.LookAt(gmj.transform.position);
                    but_rotation = false;
                    Unit_Chouse();
                    action_points -= 1;
                
               
                    
                
            

        }

    }
    public void Unit_rotation()
    {
        but_rotation = true;
        
    }
    public void Build_barricade()
    {
        
      if(action_points >= 3)
      {
          unit_cur_defence += barrikade_power;
          float z = gameObject.transform.position.z;
          z += 3.8f;
          Vector3 position_of_spawn = gameObject.transform.FindChild("spawn_pos").transform.position;
          barrik_have = Instantiate(barrikade, position_of_spawn, gameObject.transform.rotation) as GameObject;
          barrik_have.transform.SetParent(gameObject.transform);
          Unit_Chouse();
          action_points -= 3;
      }
        
    }
    

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hex")
        {
            my_hex = col.gameObject;
            if(gameObject.tag == "player_unit")
            {
                my_hex.GetComponent<HexComb>().Change(2);
            }
            else if(gameObject.tag == "Enemy")
            {
                my_hex.GetComponent<HexComb>().Change(3);
            }
            
        }
    }
    public void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Hex")
        {
            my_hex.GetComponent<HexComb>().Change(1);
        }
    }
    
    public void Bonus_Calculating()
    {
        unit_cur_fire_power = unit_fire_power;
        unit_cur_defence = unit_defence;
        
        unit_cur_defence += my_hex.GetComponent<HexComb>().bonus_defence;
        unit_cur_fire_power += my_hex.GetComponent<HexComb>().bonus_atack;

        
       
    }
    public void End_Turn()
    {
        action_points = 5;
    }

    
}
