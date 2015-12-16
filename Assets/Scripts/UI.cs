using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
    public GameObject but_turn_Unit;


    public void Start()
    {
       
    }
	public void ButtonHider(string button_name)
    {
        if(button_name == "turnUnit")
        {
            but_turn_Unit.SetActive(true);
        }
        else if(button_name == "hide")
        {
            but_turn_Unit.SetActive(false);
        }
        
    }
    
	
}
