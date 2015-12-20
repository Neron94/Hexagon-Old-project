using UnityEngine;
using System.Collections;

public class city : MonoBehaviour {
    private DataBase DB;

    public string city_name;
    public int salary_bonus;
    public bool switcher = false;
    public string fraction_name;
    public int defence_bonus;
    public Fractions frac;
    public GameObject my_hex;
    private GameObject flag_spawn;
    private bool flag_spawn_stop;
    private bool city_selected = false;
	void Start () {
        
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        DB.all_cities.Add(gameObject);
        flag_spawn = gameObject.transform.FindChild("spawn_flag").gameObject;
        
        
	}
	
	
	void Update () {
    if(switcher)
    {
        Flag_spawner();
    }
    else
    {
        
    }
	}
    public void Money_pay()
    {
        if(switcher)
        {
            frac.Salary_plus(salary_bonus);
        }
    }
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "player_unit")
        {
            if(flag_spawn_stop)
            {
                if(fraction_name != col.gameObject.GetComponent<Unit>().unit_fraction)
                {
                    Destroy(gameObject.transform.GetChild(5).gameObject);
                    Flag_spawner();
                }
                
            }
            switcher = false;
            switcher = true;
            DB.player_cities.Add(gameObject);
            fraction_name = DB.player_units[0].GetComponent<Unit>().unit_fraction;
            frac = GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>();
        }
        else if (col.gameObject.tag == "Enemy")
        {

            foreach(GameObject gj in DB.enemy_units)
            {
                if(col.gameObject == gj)
                {
                    if (flag_spawn_stop)
                    {
                        if (fraction_name != col.gameObject.GetComponent<Unit>().unit_fraction)
                        {
                            Destroy(gameObject.transform.GetChild(5).gameObject);
                        }
                    }
                    switcher = false;
                    switcher = true;
                    DB.enemy_cities.Add(gameObject);
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

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "player_unit")
        {
            DB.player_units[0].GetComponent<Unit>().unit_cur_defence -= defence_bonus;
            
            
        }
        else if (col.gameObject.tag == "Enemy")
        {

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
    public void Flag_spawner()
    {
        if (!flag_spawn_stop)
        {
            if (fraction_name == "RedArmy")
            {

                GameObject flag = Instantiate(DB.unit_Pref_types[3], flag_spawn.transform.position, Quaternion.identity) as GameObject;
                flag.transform.SetParent(gameObject.transform);
                flag_spawn_stop = true;
            }
            else if (fraction_name == "Wehrmacht")
            {
                GameObject flag = Instantiate(DB.unit_Pref_types[4], flag_spawn.transform.position, Quaternion.identity) as GameObject;
                flag.transform.SetParent(gameObject.transform);
                flag_spawn_stop = true;
            }
        }
        else
        {

        }
    }
    public void City_Chosen()
    {
        if(city_selected)
        {
            city_selected = false;
            DB.city_selected.Remove(gameObject);
            my_hex.GetComponent<HexComb>().Change(1);
            GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>().city_stats.SetActive(false);
        }
        else
        {
            city_selected = true;
            DB.city_selected.Add(gameObject);
            my_hex.GetComponent<HexComb>().Change(3);
            GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>().city_stats.SetActive(true);
            GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>().cityStats.text = "" + city_name + "  Cash  " + salary_bonus + "  Def  " + defence_bonus;
        }
    }

}
