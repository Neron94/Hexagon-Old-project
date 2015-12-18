using UnityEngine;
using System.Collections;

public class BattleCalculator : MonoBehaviour {

    
    
	void Start () {
	
	}
    void Update () {
	
	}
    public void Side_of_atack(GameObject atk, GameObject def)
    {
        atk.GetComponent<Unit>().Unit_rotation(def,def);
        float atk_rot = atk.transform.rotation.y;
        float def_rot = def.transform.rotation.y;
        float beh_bonus;

        if (def_rot == Mathf.Clamp(def_rot, 119, 121) && atk_rot == Mathf.Clamp(atk_rot, 59, 181))
        {
            Debug.Log("1 вар");
            beh_bonus = 2;
        }
        else if (def_rot == Mathf.Clamp(def_rot, 179, 181) && atk_rot == Mathf.Clamp(atk_rot, 119, 241))
        {
            Debug.Log("2 вар");
            beh_bonus = 2;
        }
        else if (def_rot == Mathf.Clamp(def_rot, 239, 241) && atk_rot == Mathf.Clamp(atk_rot, 179, 301))
        {
            Debug.Log("3 вар");
            beh_bonus = 2;
        }
        else if (def_rot == Mathf.Clamp(def_rot, 299, 301) && atk_rot == Mathf.Clamp(atk_rot, 239, 301) || atk_rot == Mathf.Clamp(atk_rot, 0, 1))
        {
            Debug.Log("4 вар");
            beh_bonus = 2;
        }
        else if (def_rot == Mathf.Clamp(def_rot, 0, 1) && atk_rot == Mathf.Clamp(atk_rot, 299, 301) || atk_rot == Mathf.Clamp(atk_rot, 0, 61))
        {
            Debug.Log("5 вар");
            beh_bonus = 2;
        }
        else
        {
            Debug.Log("6 вар");
            beh_bonus = 0;
        }
        Debug.Log(beh_bonus);
        BattleModeller(atk, def, beh_bonus);


    }
    public void BattleModeller(GameObject atacker, GameObject defender, float behind_bonus)
    {
        

     
        
        float def = defender.GetComponent<Unit>().unit_defence;
       
        int atk = atacker.GetComponent<Unit>().unit_fire_power;
        Debug.Log("ВЫСТРЕЛ!!!");
        float atack_power = atk - def;

        defender.GetComponent<Unit>().cur_hp -= atack_power;
        atacker.GetComponent<Unit>().action_points -= 2;
       
        
    
    
    }
}
