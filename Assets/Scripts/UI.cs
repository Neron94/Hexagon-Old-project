﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    #region variables
    private DataBase DB;
    private StateManager SM;
    public GameObject but_turn_Unit;
    public GameObject but_build_barrikade;
    public GameObject but_buy;
    public GameObject unitStats;
    public GameObject enemy_stats;
    public GameObject but_menu;
    public GameObject city_stats;
    public GameObject but_army_panel;
    public GameObject but_army_panel_1;
    public GameObject but_army_panel_2;
    public GameObject but_army_panel_3;

    public GameObject but_city_Menu;
    public GameObject panel_City;

    public GameObject but_InCity_first;
    public GameObject but_InCite_Second;
    public GameObject but_InCity_third;

    public GameObject image_of_defeat_player;
    public GameObject image_of_defeat_enemy;
    public GameObject but_resume;

    public Text in_city_fr;
    public Text in_city_sc;
    public Text in_city_th;
    public Text city_name;
    

    public Button menu;
    public Button next_turn;
  

    public Text money;
    public Text money_plusing;
    public Text tx;
    public Text enemyStat;
    public Text cityStats;
   


    public Text ar_panel_1;
    public Text ar_panel_2;
    public Text ar_panel_3;
    #endregion



    public void Start()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        SM = GameObject.FindGameObjectWithTag("Logic").GetComponent<StateManager>();
        
    }

    public void Update()
    {
        if(SM.state_pause || SM.state_unit_movement)
        {
            menu.interactable = false;
            next_turn.interactable = false;
        }
        else if (!SM.state_unit_movement || !SM.state_pause)
        {
            menu.interactable = true;
            next_turn.interactable = true;
        }
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
            but_city_Menu.SetActive(false);
            
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
            SM.state_pause = true;
            
            
        }
        else if (button_name == "close_menu")
        {
            but_menu.SetActive(false);
            SM.state_pause = false;
            
        }    
        else if (button_name == "exit")
        {
            Application.Quit();
        }
        else if (button_name == "hide_army")
        {
            but_army_panel.SetActive(false);
            but_army_panel_1.SetActive(false);
            but_army_panel_2.SetActive(false);
            but_army_panel_3.SetActive(false);
        }
        else if (button_name == "cityMenu")
        {
            panel_City.SetActive(true);
        }
        else if(button_name == "closePanelCity")
        {
            panel_City.SetActive(false);
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
    public void money_monitor(int mon, int plusing)
    {
        money.text = "" + mon;
        money_plusing.text = "" + plusing;
    }
    public void ArmyPanel(GameObject first, GameObject second, GameObject third)
    {
            but_army_panel.SetActive(true);
            but_army_panel_1.SetActive(true);
            but_army_panel_2.SetActive(true);
            but_army_panel_3.SetActive(true);

            ar_panel_1.text = first.GetComponent<Unit>().unit_type;
            ar_panel_2.text = second.GetComponent<Unit>().unit_type;
            ar_panel_3.text = third.GetComponent<Unit>().unit_type;
        
        
    }
    public void ArmyPanel(GameObject first, GameObject second)
    {
        but_army_panel.SetActive(true);
        but_army_panel_1.SetActive(true);
        but_army_panel_2.SetActive(true);

        ar_panel_1.text = first.GetComponent<Unit>().unit_type;
        ar_panel_2.text = second.GetComponent<Unit>().unit_type;
    }
    public void Unit_of_army(int number)
    {
      if(number == 1)
      {
          DB.chose_unit[0].GetComponent<Army>().army_contain[0].GetComponent<Unit>().Unit_Chouse();
          DB.chose_unit[0].GetComponent<Army>().Army_Chose();
          
          
      }
      else if (number == 2)
      {
          DB.chose_unit[0].GetComponent<Army>().army_contain[1].GetComponent<Unit>().Unit_Chouse();
          DB.chose_unit[0].GetComponent<Army>().Army_Chose();
         

      }
      else if (number == 3)
      {
          DB.chose_unit[0].GetComponent<Army>().army_contain[2].GetComponent<Unit>().Unit_Chouse();
          DB.chose_unit[0].GetComponent<Army>().Army_Chose();
         
      }
    }

    public void city_panel_hide()
    {
        panel_City.SetActive(false);
        but_InCity_first.SetActive(false);
        but_InCite_Second.SetActive(false);
        but_InCity_third.SetActive(false);
    }


    public void InCity(GameObject first)
    {

        but_InCity_first.SetActive(true);
        

        in_city_fr.text = first.GetComponent<Unit>().unit_type;
        
    }
    public void InCity(GameObject first, GameObject second, GameObject third)
    {
        but_InCity_first.SetActive(true);
        but_InCite_Second.SetActive(true);
        but_InCity_third.SetActive(true);

        in_city_fr.text = first.GetComponent<Unit>().unit_type;
        in_city_sc.text = second.GetComponent<Unit>().unit_type;
        in_city_th.text = third.GetComponent<Unit>().unit_type;
    }
    public void InCity(GameObject first, GameObject second)
    {

        but_InCity_first.SetActive(true);
        but_InCite_Second.SetActive(true);

        in_city_fr.text = first.GetComponent<Unit>().unit_type;
        in_city_sc.text = second.GetComponent<Unit>().unit_type;
    }

    public void Unit_of_city (int num)
    {
        if(num == 1)
        {
            DB.city_selected[0].GetComponent<city>().units_in_city[0].GetComponent<Unit>().Unit_Chouse();
           city_panel_hide();
           DB.city_selected[0].GetComponent<city>().City_Chosen();
           SM.Mouse_off_UI();
            
        }
        else if (num == 2)
        {
            DB.city_selected[0].GetComponent<city>().units_in_city[1].GetComponent<Unit>().Unit_Chouse();
           city_panel_hide();
           DB.city_selected[0].GetComponent<city>().City_Chosen();
           SM.Mouse_off_UI();
        }
        else if (num == 3)
        {
            DB.city_selected[0].GetComponent<city>().units_in_city[2].GetComponent<Unit>().Unit_Chouse();
            city_panel_hide();
            DB.city_selected[0].GetComponent<city>().City_Chosen();
            SM.Mouse_off_UI();
        }
    }

    public void DefeaatScreen(string who)
    {
        if(who == "player")
        {
            image_of_defeat_player.SetActive(true);
        }
        else if (who == "enemy")
        {
            image_of_defeat_enemy.SetActive(true);
        }
    }

    
  
    
	
}
