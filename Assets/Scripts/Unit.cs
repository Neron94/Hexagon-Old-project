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
    
    #endregion
    void Start () {
        ctrl = GameObject.Find("Logic").GetComponent<Control>();
        unit_selector = gameObject.transform.GetChild(0).gameObject;
        DB = GameObject.Find("Logic").GetComponent<DataBase>();
        DB.player_units.Add(gameObject);
        
                  }
	void Update () {
        
        
        

	}
    public void Move(List<Vector3> path)
    {
        for (int i = 0; i < action_points; i++)
        {
            
            gameObject.transform.position = new Vector3(DB.Path[i].x, DB.Path[i].y, DB.Path[i].z);
            action_points--;
  
            
        }
    } // Метод движения Юнита
    public void Unit_Chouse()
    {
        if(unit_chosen == false)
        {
            unit_chosen = true;
            unit_selector.SetActive(unit_chosen);
            DB.chose_unit.Add(gameObject);
           
        }
        else if(unit_chosen == true)
        {
            unit_chosen = false;
            unit_selector.SetActive(unit_chosen);
            DB.chose_unit.Remove(gameObject);
           
            
        }
    }


    
}
