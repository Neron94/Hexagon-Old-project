using UnityEngine;
using System.Collections;


public class HexComb : MonoBehaviour {

    //**********Класс Гекса Запиывает себя в Базу Данных Гексов*********\\

    #region Variables
    private DataBase DB;
    public SpriteRenderer sp;
    public Sprite avail_hex;
    public Sprite point_go;
    public Sprite enemy_target;
    public Sprite path;
    public Sprite def;
    public float bonus_defence;
    public int bonus_atack;

    public GameObject unit_on_hex;
    public GameObject army_on_hex;
    public GameObject city_on_hex;
    public GameObject army;

    #endregion


    void Start () {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        DB.hex_comb.Add(gameObject);
        sp = gameObject.GetComponentInChildren<SpriteRenderer>();

       

                  }
	void Update () {
        
	}
    public void Change(int sw)
    {
        int case_switch = sw;
        switch (case_switch)
        {
            case 1:
                sp.sprite = def;
                break;
            case 2:
                sp.sprite = avail_hex;
                break;
            case 3:
                sp.sprite = point_go;
                break;
            case 4:
                sp.sprite = enemy_target;
                break;
            case 5:
                sp.sprite = path;
                break;
                
        }
        
    }
    
    private void OnTriggerEnter(Collider col)
    {
        if(unit_on_hex == null)
        {
            if (col.gameObject.tag == "player_unit")
            {
                unit_on_hex = col.gameObject;
            }
            else if (col.gameObject.tag == "Enemy")
            {
                unit_on_hex = col.gameObject;
            }
        }
        else if(unit_on_hex != null)
        {
            if (city_on_hex == null)
            {
                if (army_on_hex != null)
                {

                    if (unit_on_hex.tag == "player_unit")
                    {
                        if (col.gameObject.tag == "player_unit")
                        {
                            army_on_hex.GetComponent<Army>().army_contain.Add(col.gameObject);
                            col.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                        }
                    }


                }
                else
                {
                    if (unit_on_hex.tag == "player_unit")
                    {
                        if (col.gameObject.tag == "player_unit")
                        {
                            unit_on_hex.transform.GetChild(2).gameObject.SetActive(false);
                            col.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                            army = Instantiate(DB.unit_Pref_types[6], unit_on_hex.transform.position, unit_on_hex.transform.rotation) as GameObject;
                            army_on_hex = army;
                            army.GetComponent<Army>().army_contain.Add(unit_on_hex);
                            army.GetComponent<Army>().army_contain.Add(col.gameObject);
                        }
                        else
                        {

                        }
                    }
                    else if (unit_on_hex.tag == "Enemy")
                    {
                        if (col.gameObject.tag == "Enemy")
                        {
                            //process sozdaniya dlia vragov poshol dlia vragov
                        }
                        else
                        {

                        }
                    }

                }
            }  
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        if(army != null)
        {
            if (col.gameObject.tag == "player_unit")
            {
                col.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                army.GetComponent<Army>().army_contain.Remove(col.gameObject);
                
            }
            else if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                unit_on_hex = null;
            }
        }
        if(unit_on_hex != null)
        {
            if(unit_on_hex == col.gameObject)
            {
                unit_on_hex = null;
            }
        }
        
        
            
        
        
            
            
    }
    
    
   
}
