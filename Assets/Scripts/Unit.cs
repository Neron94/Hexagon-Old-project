using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

    //*******Класс Юнита*******\\

    #region Variables

    private bool moving = false;
    public int speed;
    public int c = 0;
    public bool movve = false;
    public List<Vector3> myPath;

    public GameObject move;
    public GameObject fire_effect;
    public GameObject explosion;


    private Control ctrl;
    private DataBase DB;
    private  UI ui;
    private StateManager SM;
    private  bool unit_chosen = false;
    private bool enemy_chose = false;
    private  GameObject unit_selector;
    private GameObject enemy_selector;
    [HideInInspector]
    public GameObject navigator_obj;
    [HideInInspector]
    public int action_points = 5;
    private bool but_rotation = false;
    [HideInInspector]
    public GameObject rotation_object_direction; //для обьекта поворота будь то Хекс или Юнит
    [HideInInspector]
    public int barrikade_power; // бонус барикад
    [HideInInspector]
    public GameObject barrikade;
    [HideInInspector]
    public GameObject barrik_have;
    [HideInInspector]
    public bool have_barrikade = false;

    


    public string unit_type;
    public GameObject another_unit;
    public string unit_fraction;
    public float unit_defence;
    [HideInInspector]
    public float unit_cur_defence;
    [HideInInspector]
    public int unit_cur_fire_power;
    public int unit_fire_power;
    public int fire_distance;
    public float max_hp;
    [HideInInspector]
    public float cur_hp;
    public GameObject my_hex;

    #endregion
    void Start () {
        
        ctrl = GameObject.Find("Logic").GetComponent<Control>();
        SM = GameObject.FindGameObjectWithTag("Logic").GetComponent<StateManager>();
        fire_effect = gameObject.transform.GetChild(4).gameObject;
        move = gameObject.transform.GetChild(5).gameObject;
        unit_selector = gameObject.transform.GetChild(0).gameObject;
        enemy_selector = gameObject.transform.GetChild(1).gameObject;
        DB = GameObject.Find("Logic").GetComponent<DataBase>();
        explosion = DB.unit_Pref_types[5];
        ui = GameObject.Find("UI").GetComponent<UI>();
        if(gameObject.tag == "player_unit")
        {
            DB.player_units.Add(gameObject);
        }
        else if(gameObject.tag == "Enemy")
        {
            DB.enemy_units.Add(gameObject);
        }
        


       
        
     
        
        }
	void Update ()
    {
        move.SetActive(movve);

        #region Move(Cicle)
        if (movve)
        {
            if(action_points > 0)
            {
                if (gameObject.transform.position != ctrl.position_to_go)
                {
                    
                    Debug.Log("cicle poshol");
                    if (!moving)
                    {
                        if(myPath.Count != 0)
                        {
                            try
                            {
                                gameObject.transform.LookAt(myPath[c]);
                                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, myPath[c], speed * Time.deltaTime);
                    
                            }
                            catch
                            {
                                /*
                                movve = false;
                                myPath.Clear();
                                c = 0;
                                 */
                            }
                            
                        }
                        }
                    if (gameObject.transform.position == myPath[c])
                    {
                        moving = false;
                        c++;
                        action_points--;
                        
                    }
                }
                else
                {
                    movve = false;
                    myPath.Clear();
                    c = 0;
                    SM.state_unit_movement = false;
                    DB.unit_is_moving.Remove(gameObject);
                    
                }
            }
            else
            {
                moving = false;
                movve = false;
                myPath.Clear();
                c = 0;
                SM.state_unit_movement = false;
                DB.unit_is_moving.Remove(gameObject);
            }

        }
        #endregion
        Unit_death();
        #region Rotation_On_Button(Cicle)
        if (but_rotation)
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
        #endregion


    }
    private void Unit_death()
    {
        
       
        if(cur_hp <= 0)
        {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (have_barrikade)
            {
                
                Destroy(barrik_have);
                unit_cur_defence -= barrikade_power;
                have_barrikade = false;
            }
        }
    }
    public void Move()
    {
        if (have_barrikade)
        {
            Destroy(barrik_have);
            unit_cur_defence -= barrikade_power;
            have_barrikade = false;
        }
        movve = true;
        DB.unit_is_moving.Add(gameObject);
        SM.state_unit_movement = true;
        
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
            ui.unitSats(action_points, unit_cur_fire_power, unit_cur_defence, cur_hp, max_hp);
            
            
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
    public void Enemy_Chose()
    {
    if(!enemy_chose)
    {
        enemy_chose = true;
        ui.enemyStats(cur_hp, max_hp);
        DB.enemy_chose.Add(gameObject);
        enemy_selector.SetActive(enemy_chose);

    }
    else if(enemy_chose)
    {
        enemy_chose = false;
        DB.enemy_chose.Remove(gameObject);
        enemy_selector.SetActive(enemy_chose);
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
                    gameObject.transform.LookAt(gmj.transform.position);
                    
                   
    }
    public void Unit_rotation()
    {
        but_rotation = true;
        
    }
    public void Build_barricade()
    {
        
      if(action_points >= 3)
      {
          
          float z = gameObject.transform.position.z;
          z += 3.8f;
          Vector3 position_of_spawn = gameObject.transform.FindChild("spawn_pos").transform.position;
          barrik_have = Instantiate(barrikade, position_of_spawn, gameObject.transform.rotation)as GameObject;
          barrik_have.transform.SetParent(gameObject.transform);
          unit_cur_defence += barrikade_power;
          Unit_Chouse();
          action_points -= 3;
          have_barrikade = true;
      }
        
    }
    

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Hex")
        {
            my_hex = col.gameObject;
            Bonus_Calculating();
            if(gameObject.tag == "player_unit")
            {
               // my_hex.GetComponent<HexComb>().Change(2);
            }
            else if(gameObject.tag == "Enemy")
            {
               // my_hex.GetComponent<HexComb>().Change(3);
            }
            
        }
        else if (col.gameObject.tag == "player_unit")
        {

        }
    }
    private void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Hex")
        {
            my_hex.GetComponent<HexComb>().Change(1);
        }
    }
    
    private void Bonus_Calculating()
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
