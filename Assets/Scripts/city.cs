using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class city : MonoBehaviour
{


    #region Variables
    private DataBase DB;
    public Fractions frac;
    public Sprite fraction_Icon;
    private UI ui;
    public string city_name; // название города
    public int salary_bonus; // кол-во денег которые дает город по окончанию хоода
    public bool switcher = false; // включатель обладания городом
    public string fraction_name; // название фракции города
    public int defence_bonus; // бонус к защите юнита если он в городе
    public GameObject my_hex; // сторим хекс на котором стоит город
    private bool city_selected = false; // селекнут ли город
    public List<GameObject> units_in_city; //юниты в городе
    public GameObject Canvas;
    public int salary_factory_lvl= 0;
    public bool baracks;
    public bool tank_factory;
    public bool cannon_factory;
    public bool air_field;

    
    #endregion 
    void Awake()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        DB.all_cities.Add(gameObject);
    }
    void Start () {
        
        
        
        frac = GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>();
        ui = GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>();
        Canvas = gameObject.transform.FindChild("Canvas").gameObject;
        if(fraction_name == "")
        {
            GameObject.FindGameObjectWithTag("AI").GetComponent<AI_Data_Base>().city_neutral.Add(gameObject);
        }
     }
	void Update () {
    
    
        if(units_in_city.Count > 0)
        {
            //вкл окопов
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (units_in_city.Count == 0)
        {
            //выкл окопов
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }

        if(fraction_name != "")
        {
            GameObject.FindGameObjectWithTag("AI").GetComponent<AI_Data_Base>().city_neutral.Remove(gameObject);
        }
        
        
        
        
	}
    public void Money_pay()
    {
        if(switcher)
        {
            frac.Salary_plus(salary_bonus);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "player_unit")
        {
          
            units_in_city.Add(col.gameObject);
            
            //Активирует кнопки в панели Гарнизона UI города
            UnitArrived();
            
            //выкл тело юнита
            col.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            //не проницаем рейкастом
            col.gameObject.layer = 2;
            
            switcher = false;
            switcher = true;
            
            if(!City_almost_DB(gameObject))
            {
                DB.player_cities.Add(gameObject);
            }
            if (City_almost_in_Enemy_DB(gameObject))
            {
                DB.enemy_cities.Remove(gameObject);
            }
            
            
            fraction_name = DB.player_units[0].GetComponent<Unit>().unit_fraction;
            fraction_Icon = GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().icon_of_fraction; ;
            frac = GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>();
        }
        else if (col.gameObject.tag == "Enemy")
        {
            units_in_city.Add(col.gameObject);

            col.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            
            foreach(GameObject gj in DB.enemy_units)
            {
                if(col.gameObject == gj)
                {
                    if(!City_almost_in_Enemy_DB(gameObject))
                    {
                        DB.enemy_cities.Add(gameObject);
                    }
                    if(City_almost_DB(gameObject))
                    {
                        DB.player_cities.Remove(gameObject);
                    }
                    switcher = false;
                    switcher = true;
                    
                    fraction_name = gj.GetComponent<Unit>().unit_fraction;
                    frac = GameObject.FindGameObjectWithTag("AI").GetComponent<Fractions>();
                    break;
                }
            }
           

        }
        else if(col.gameObject.tag == "Hex")
        {
            my_hex = col.gameObject;
            my_hex.GetComponent<HexComb>().bonus_defence += defence_bonus;
            my_hex.GetComponent<HexComb>().city_on_hex = gameObject;
            
        }

    }

    private  void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "player_unit")
        {
            
            col.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            units_in_city.Remove(col.gameObject);
            UnitArrived();
            col.gameObject.layer = 0;
            


            DB.player_units[0].GetComponent<Unit>().unit_cur_defence -= defence_bonus;
            
            
        }
        else if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.transform.GetChild(2).gameObject.SetActive(true);
            units_in_city.Remove(col.gameObject);
            foreach (GameObject gj in DB.enemy_units)
            {
                if (col.gameObject == gj)
                {
                    gj.GetComponent<Unit>().unit_cur_defence -= defence_bonus;
                   
                    
                    break;
                }
            }


        }
    }
    public void City_Chosen()
    {
        if(city_selected)
        {
            ui.ButtonHider("hide");
            
            city_selected = false;
            DB.city_selected.Remove(gameObject);
            my_hex.GetComponent<HexComb>().Change(1);
            
             gameObject.transform.GetComponent<city_UI_manager>().Back_Button();
            Canvas.SetActive(false);
            
            
        }
        else
        {
            city_selected = true;
            DB.city_selected.Add(gameObject);
            my_hex.GetComponent<HexComb>().Change(3);
            GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>().cityStats(fraction_Icon,salary_bonus,city_name);
            if(fraction_name == frac.fraction_name)
            {
                Canvas.SetActive(true);

            }
         
        }
    }
    private  bool City_almost_DB(GameObject city)
    {
       foreach(GameObject db in DB.player_cities)
       {
        if(city == db)
        {
            return true;
        }
        
       }
       return false;
    }
    private bool City_almost_in_Enemy_DB(GameObject city)
    {
        foreach(GameObject ciTy in DB.enemy_cities)
        {
            if(city == ciTy)
            {
                return true;
            }
        }
        return false;
    }
    
    public void Build_Salary_Factory(int lvl)
    {
        if(lvl ==1)
        {
            salary_bonus += 10;
            salary_factory_lvl = 1;
        }
        else if(lvl == 2)
        {
            salary_bonus += 5;
            salary_factory_lvl = 2;
        }
        else if(lvl == 3)
        {
            salary_bonus += 5;
            salary_factory_lvl = 3;

        }
    }

    public void UnitArrived()
    {
        //Активирует кнопки в панели Гарнизона UI города
        if (units_in_city.Count == 1)
        {
            gameObject.transform.GetComponent<city_UI_manager>().SoldiersInCity(units_in_city[0]);
        }
        else if (units_in_city.Count == 2)
        {
            gameObject.transform.GetComponent<city_UI_manager>().SoldiersInCity(units_in_city[0], units_in_city[1]);
        }
        else if (units_in_city.Count == 3)
        {
            gameObject.transform.GetComponent<city_UI_manager>().SoldiersInCity(units_in_city[0], units_in_city[1], units_in_city[2]);
        }
        else if (units_in_city.Count == 0)
        {
            gameObject.transform.GetComponent<city_UI_manager>().SoldiersNone();
        }
    }
  

}
