using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
    public DataBase DB;
    public GameObject but_turn_Unit;
    public GameObject but_build_barrikade;
    public GameObject but_buy;


    public void Start()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
    }
	public void ButtonHider(string button_name)
    {
        if(button_name == "turnUnit")
        {
            but_turn_Unit.SetActive(true);
        }
        else if(button_name == "hide")
        {
            but_turn_Unit.SetActive(false);
            but_build_barrikade.SetActive(false);
            but_buy.SetActive(false);
        }
        else if(button_name == "build_barrikade")
        {
            but_build_barrikade.SetActive(true);
        }
        else if(button_name == "buy_buton")
        {
            if(DB.chose_unit.Count == 1)
            {
                DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
            }
           
            but_buy.SetActive(true);
            
        }
        
    }
    
	
}
