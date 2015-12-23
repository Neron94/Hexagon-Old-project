using UnityEngine;
using System.Collections;


public class Fractions : MonoBehaviour
{

    #region Variables
    public string fraction_name; // Название фракции 
    private DataBase DB;
    public int Salary; // кол-во средств фракции
    private  bool buy_time = false; // обозначает что идет покупка юнита
    private GameObject spawn_Object; // содержит юнита покупки обозначается по разному
    private RaycastHit hit;
    public int tank_cost; //цена танка
    public int cannon_cost; // цена пушки
    public int infantry_costs; // цена пехоты
    public UI ui;
    public int all_money;
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
        if(buy_time)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit, Mathf.Infinity);
                if (buy_time)
                {
                    foreach (GameObject gmj in DB.arrivel_list)
                    {
                        if (hit.collider.gameObject == gmj)
                        {
                            Instantiate(spawn_Object, hit.collider.gameObject.transform.position, Quaternion.identity);
                            if (spawn_Object.name == "wehrmacht_Cannon")
                            {
                                Salary -= cannon_cost;
                            }
                            else if (spawn_Object.name == "wehrmacht_infantry")
                            {
                                Salary -= infantry_costs;
                            }
                            else if (spawn_Object.name == "wehrmacht_Tank")
                            {
                                Salary -= tank_cost;
                            }
                            foreach(GameObject gnn in DB.arrivel_list)
                            {
                                gnn.GetComponent<HexComb>().Change(1);
                            }
                            buy_time = false;
                            break;
                        }
                        
                    }
                }

            }
           
        }
        
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
        buy_time = true;
        if(name == "tank")
        {
            if(Salary >= tank_cost)
            {
                DB.arrivel_list.Clear();
                foreach (GameObject city in DB.player_cities)
                {
                    city.GetComponent<city>().my_hex.GetComponent<HexComb>().Change(2);
                    DB.arrivel_list.Add(city.GetComponent<city>().my_hex);
                    spawn_Object = DB.unit_Pref_types[0];
                   
                    
                }
            }
            else
            {
                buy_time = false;
            }
            
        }
        else if (name == "cannon")
        {
            if(Salary >= cannon_cost)
            {
                DB.arrivel_list.Clear();
                foreach (GameObject city in DB.player_cities)
                {
                    city.GetComponent<city>().my_hex.GetComponent<HexComb>().Change(2);
                    DB.arrivel_list.Add(city.GetComponent<city>().my_hex);
                    spawn_Object = DB.unit_Pref_types[1];
                    
                }
            }
            else
            {
                buy_time = false;
            }
            
        }
        if (name == "infantry")
        {
            if (Salary >= infantry_costs)
            {
                DB.arrivel_list.Clear();
                foreach (GameObject city in DB.player_cities)
                {
                    city.GetComponent<city>().my_hex.GetComponent<HexComb>().Change(2);
                    DB.arrivel_list.Add(city.GetComponent<city>().my_hex);
                    spawn_Object = DB.unit_Pref_types[2];
                    

                }
            }
            else
            {
                buy_time = false;
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
