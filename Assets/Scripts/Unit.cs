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

	}
    public void Unit_death()
    {
        if(cur_hp == 0)
        {
            Destroy(gameObject, 3);
        }
    }
    public void Move()
    {
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

        gameObject.transform.LookAt(gmj.transform.position);
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
