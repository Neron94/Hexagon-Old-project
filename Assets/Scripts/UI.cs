using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour
{

    #region variables
    private DataBase DB;
    private StateManager SM;
    public GameObject but_build_barrikade;
    public GameObject unitStats;
    public GameObject enemy_stats;
    public GameObject but_menu;
    public GameObject but_army_panel;
    public GameObject but_army_panel_1;
    public GameObject but_army_panel_2;
    public GameObject but_army_panel_3;
    public GameObject but_diselect;

    
    public GameObject panel_City;
    private GameObject money_tablo;

    

    public GameObject image_of_defeat_player;
    public GameObject image_of_defeat_enemy;
    public GameObject but_resume;

    
    public GameObject Air_sup_Button;

    public Button menu;
    public Button next_turn;
  

    public Text money;
    public Text money_plusing;
    public Text tx;
    public Text enemyStat;
    

    private GameObject unitStats_panel;
    private Image icon;
    private Image hp;
    private Text ap;
    private Text atack;
    private Text defence;


    public Text ar_panel_1;
    public Text ar_panel_2;
    public Text ar_panel_3;

    public Text label_of_turn;
    private GameObject label_of_turn_object;
    #endregion
    public void Start()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        SM = GameObject.FindGameObjectWithTag("Logic").GetComponent<StateManager>();
        unitStats_panel = GameObject.Find("Canvas").gameObject.transform.FindChild("unitStats").gameObject;
        icon = unitStats_panel.transform.FindChild("unitImage").GetComponent<Image>();
        ap = unitStats_panel.transform.FindChild("unitAP").GetComponent<Text>();
        atack = unitStats_panel.transform.FindChild("unitDamage").GetComponent<Text>();
        defence = unitStats_panel.transform.FindChild("unitDefence").GetComponent<Text>();
        hp = unitStats_panel.transform.FindChild("hp").GetComponent<Image>();


        label_of_turn = GameObject.Find("Canvas").gameObject.transform.FindChild("label_of_turn").GetComponent<Text>();
        label_of_turn_object = GameObject.Find("Canvas").gameObject.transform.FindChild("label_of_turn").gameObject;
        money_tablo = GameObject.Find("Canvas").gameObject.transform.FindChild("Text_salary").gameObject;
        but_diselect = GameObject.Find("Canvas").gameObject.transform.FindChild("unitStats").gameObject.transform.FindChild("diselect").gameObject;
    }
    public void Update()
    {
        if(SM.state_pause || SM.state_unit_movement || SM.AI_moves)
        {
            menu.interactable = false;
            next_turn.interactable = false;
            money_tablo.SetActive(false);
        }
        else if (!SM.state_unit_movement || !SM.state_pause || SM.AI_moves)
        {
            menu.interactable = true;
            next_turn.interactable = true;
            money_tablo.SetActive(true);
        }
        Air_sup_Button.SetActive(DB.gameObject.transform.GetComponent<Control>().air_support_is_action);
        

    }
	public void ButtonHider(string button_name)
    {
        if(button_name == "hide")
        {
         
            but_build_barrikade.SetActive(false);
            
            enemy_stats.SetActive(false);
            
            
        }
        else if (button_name == "hide_stats")
        {
            unitStats_panel.SetActive(false);
        }
        else if(button_name == "build_barrikade")
        {
            but_build_barrikade.SetActive(true);
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
        else if (button_name == "label_of_turn")
        {
            label_of_turn_object.SetActive(true);
        }
        else if(button_name == "close_label")
        {
            Invoke("Label_off", 2);
        }
            
       
        
        
    }
    public void unitStats_method(int app, int unit_damage, float unit_defence, Sprite iccon, float hpp)
    {
        unitStats_panel.SetActive(true);
        icon.sprite = iccon;
        ap.text = ""+app;
        atack.text = "Damage: " + unit_damage;
        defence.text = "Defence: " + unit_defence;
        hp.fillAmount = hpp / 10;
        

        
    }
    public void enemyStats(float hpp, Sprite iconc)
    {
        ap.text = "";
        atack.text = "";
        defence.text = "";
        unitStats_panel.SetActive(true);
        hp.fillAmount = hpp / 10;
        icon.sprite = iconc;
    }
    public void cityStats(Sprite iconc, int cash, string name)
    {
        hp.fillAmount = 1;
        ap.text = "";
        atack.text = ""+name;
        defence.text = "          $ "+ cash;
        unitStats_panel.SetActive(true);
        icon.sprite = iconc;
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

    public void CityUI_provider(int index)
    {

        DB.city_selected[0].GetComponent<city_UI_manager>().MainButton(index);

    }

    public void Label_off()
    {
        label_of_turn_object.SetActive(false);
    }

    
  
    
	
}
