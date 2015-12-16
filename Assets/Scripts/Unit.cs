using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

    //*******Класс Юнита*******\\

    #region Variables
    public Control ctrl;
    public float speed = 10;
    public DataBase DB;
    public bool unit_chosen = false;
    public GameObject unit_selector;
    public int action_points = 3;
    public GameObject navigator_obj;


    public string unit_type;
    public string unit_fraction;
    public int number_of_soldiers;
    public float unit_defence;
    public int unit_fire_power;
    public int fire_distance;
    #endregion
    void Start () {
        ctrl = GameObject.Find("Logic").GetComponent<Control>();
        unit_selector = gameObject.transform.GetChild(0).gameObject;
        DB = GameObject.Find("Logic").GetComponent<DataBase>();
        DB.player_units.Add(gameObject);
        
                  }
	void Update () {
        
        
        

	}
    public void Move()
    {
        for (int i = 0; action_points != 0; i++)
        {

            gameObject.transform.position = new Vector3(DB.Path[i].x, DB.Path[i].y, DB.Path[i].z);
            action_points--;
            if(gameObject.transform.position == ctrl.position_to_go)
            {
                break;
            }
            
            
        }
        
    } // Метод движения Юнита
    public void Unit_Chouse()
    {
        if(unit_chosen == false)
        {
            
            unit_chosen = true;
            unit_selector.SetActive(unit_chosen);
            DB.chose_unit.Add(gameObject);
            Instantiate(navigator_obj, transform.position, Quaternion.identity);
            
        }
        else if(unit_chosen == true)
        {
            unit_chosen = false;
            unit_selector.SetActive(unit_chosen);
            DB.chose_unit.Remove(gameObject);
            GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().Chose_another_unit();
            
           
            
        }
    }


    
}
