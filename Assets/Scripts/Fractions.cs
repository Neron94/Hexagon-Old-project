using UnityEngine;
using System.Collections;


public class Fractions : MonoBehaviour
{

    #region Variables
    public string fraction_name; // Название фракции 
    private DataBase DB;
    public int Salary; // кол-во средств фракции
    private GameObject spawn_Object; // содержит юнита покупки обозначается по разному
    private RaycastHit hit;
    public int tank_cost; //цена танка
    public int cannon_cost; // цена пушки
    public int infantry_costs; // цена пехоты
    public int air_cost; // цена воздушной поддержки
    public int air_power; // сила уудара авиации
    public bool isPlayer;

    public UI ui;
    public int all_money;//Общий доход
    public Sprite icon_of_fraction;
    #endregion



    void Start () {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        ui = GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>();
       	}
	void Update () {
        Money_from_citys();
        if(Salary <= 0)
        {
            Salary = 0;
        }
        ui.money_monitor(Salary, all_money);
        
        
	}
    public void Salary_plus(int count)
    {
       Salary += count;
    }
    public void Salary_minus(int count)
    {
        
        Salary -= count;
    }
    public void buy_unit(string name)
    {
        spawn_Object = null;
        if(name == "tank")
        {
            if(Salary >= tank_cost)
            {
                
                if(fraction_name == "Wehrmacht")
                {
                    spawn_Object = DB.unit_Pref_types[0];
                }
                else
                {
                    spawn_Object = DB.unit_Pref_types[9];
                }
                spawn_Object = DB.unit_Pref_types[0];
                if(DB.city_selected.Count != 0)
                {
                    Instantiate(spawn_Object, DB.city_selected[0].transform.position, Quaternion.identity);
                }
           
                   
            }
            
            
            
        }
         if (name == "cannon")
        {
            if(Salary >= cannon_cost)
            {

                if (fraction_name == "Wehrmacht")
                {
                    spawn_Object = DB.unit_Pref_types[1];
                }
                else
                {
                    spawn_Object = DB.unit_Pref_types[8];
                }
            if (DB.city_selected.Count != 0)
            {
                Instantiate(spawn_Object, DB.city_selected[0].transform.position, Quaternion.identity);
            }
             
                    
                
            }
            
            
        }
        if (name == "infantry")
        {
            if (Salary >= infantry_costs)
            {

                if (fraction_name == "Wehrmacht")
                {
                    spawn_Object = DB.unit_Pref_types[2];
                }
                else
                {
                    spawn_Object = DB.unit_Pref_types[7];
                }
             if (DB.city_selected.Count != 0)
             {
                 Instantiate(spawn_Object, DB.city_selected[0].transform.position, Quaternion.identity);
             }
                    

                
            }
            

        }
        if (name == "air")
        {
            if (Salary >= air_cost)
            {
                if (DB.city_selected.Count != 0)
                {
                    DB.gameObject.transform.GetComponent<Control>().air_support_is_action = true;
                    DB.city_selected[0].GetComponent<city>().City_Chosen();
                }



            }


        }
        

        }
    public void Money_from_citys()
    {
        all_money = 0;
        foreach(GameObject city in DB.player_cities)
        {
            
            all_money += city.GetComponent<city>().salary_bonus;
            
        }
    }
   
}
