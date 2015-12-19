using UnityEngine;
using System.Collections;


public class Fractions : MonoBehaviour {

    public string name;
    public DataBase DB;
    public int Salary;
    public bool buy_time = false;
    public GameObject spawn_Object;
    public RaycastHit hit;
    public int tank_cost;
    public int cannon_cost;
    public UI ui;
    
   

	void Start () {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        ui = GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>();
	}
	void Update () {
        ui.money_monitor(Salary);
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
                    Salary -= tank_cost;

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
                    Salary -= cannon_cost;
                }
            }
            else
            {
                buy_time = false;
            }
            
        }

        }
   
}
