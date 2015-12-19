using UnityEngine;
using System.Collections;

public class city : MonoBehaviour {
    public DataBase DB;
    public Control ctrl;
    public string city_name;
    public int salary_bonus;
    public bool switcher = false;
    public string fraction_name;
    public int defence_bonus;
    public Fractions frac;
    public GameObject my_hex;
	void Start () {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        ctrl = GameObject.FindGameObjectWithTag("Logic").GetComponent<Control>();
        DB.all_cities.Add(gameObject);
        
        
	}
	
	
	void Update () {
    
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

}
