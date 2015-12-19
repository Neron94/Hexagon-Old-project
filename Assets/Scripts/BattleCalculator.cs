using UnityEngine;
using System.Collections;

public class BattleCalculator : MonoBehaviour {

    
    
	void Start () {
	
	}
    void Update () {
	
	}
    
    public void BattleModeller(GameObject atacker, GameObject defender)
    {
        

     
        
        float def = defender.GetComponent<Unit>().unit_defence;
        int atk = atacker.GetComponent<Unit>().unit_fire_power;
        Debug.Log("ВЫСТРЕЛ!!!");
        float atack_power = atk - def;
        defender.GetComponent<Unit>().cur_hp -= atack_power;
        atacker.GetComponent<Unit>().action_points -= 2;
        atacker.GetComponent<Unit>().Unit_Chouse();

       
        
    
    
    }
}
