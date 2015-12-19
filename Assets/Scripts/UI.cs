using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    private DataBase DB;
    public GameObject but_turn_Unit;
    public GameObject but_build_barrikade;
    public GameObject but_buy;
    public GameObject unitStats;
    public GameObject enemy_stats;
    public GameObject but_menu;
  

    public Text money;
    public Text tx;
    public Text enemyStat;


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
            unitStats.SetActive(false);
            enemy_stats.SetActive(false);
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
        else if (button_name == "menu")
        {
            but_menu.SetActive(true);
            
        }
        else if (button_name == "close_menu")
        {
            but_menu.SetActive(false);
            
        }    
        else if (button_name == "exit")
        {
            Application.Quit();
        }
        
    }
    public void unitSats(int ap, int unit_damage, float unit_defence, float hp , float max_hp)
    {
        unitStats.SetActive(true);
        tx.text = "AP :  " + ap  + " Damage  " +  unit_damage  +  " Def  " +  unit_defence + "  HP: " + hp + "/ " + max_hp;
    }
    public void enemyStats(float hp, float max_hp)
    {
        enemy_stats.SetActive(true);
        enemyStat.text = "Enemy HP: " + hp + "/" + max_hp;
    }
    public void money_monitor(int mon)
    {
        money.text = "$" + mon;
    }
    
	
}
