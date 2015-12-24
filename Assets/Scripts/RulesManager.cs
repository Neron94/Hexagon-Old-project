using UnityEngine;
using System.Collections;

public class RulesManager : MonoBehaviour {

    private DataBase DB;
    private UI ui;
    void Start()
    {
        DB = gameObject.GetComponent<DataBase>();
        ui = GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>();
    }
	 void Update()
    {
         if(DB.start_games == true)
         {
             if (DB.player_units.Count == 0 && DB.player_cities.Count == 0)
             {
                 ui.DefeaatScreen("player");
                 ui.ButtonHider("menu");
                 ui.but_resume.SetActive(false);
             }
             else if (DB.enemy_units.Count == 0 && DB.enemy_cities.Count == 0)
             {
                 ui.DefeaatScreen("enemy");
                 ui.ButtonHider("menu");
                 ui.but_resume.SetActive(false);
             }
         }
       
    }
}
