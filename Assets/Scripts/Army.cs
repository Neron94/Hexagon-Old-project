using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Army : MonoBehaviour {

    public List<GameObject> army_contain;
    private bool army_chose = false;
    public GameObject army_selector;
    public GameObject my_Hex;
    private DataBase DB;
    private UI ui; 

	void Start () {
        army_selector = gameObject.transform.GetChild(1).gameObject;
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        ui = GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>();
        DB.player_units.Add(gameObject);
        my_Hex = army_contain[0].GetComponent<Unit>().my_hex;
	}
	
	void Update () {
   if(army_contain.Count == 1)
   {
       army_contain[0].transform.GetChild(2).gameObject.SetActive(true);
       DB.player_units.Remove(gameObject);
       Destroy(gameObject);
   }
	}
    public void Army_Chose()
    {
        if(army_chose)
        {
            army_chose = false;
            army_selector.SetActive(army_chose);
            DB.chose_unit.Remove(gameObject);
            ui.ButtonHider("hide_army");
        }
        else if (!army_chose)
        {
            army_chose = true;
            army_selector.SetActive(army_chose);
            DB.chose_unit.Add(gameObject);
            if(army_contain.Count == 2)
            {
                ui.ArmyPanel(army_contain[0], army_contain[1]);
            }
            else if (army_contain.Count == 3)
            {
                ui.ArmyPanel(army_contain[0], army_contain[1], army_contain[2]);
            }
        }
    }
    
}
