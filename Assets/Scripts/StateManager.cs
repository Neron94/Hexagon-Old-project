using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

    public bool state_pause;
    public bool state_unit_movement;
    public bool state_enemy_turn;
    public bool state_On_UI;
    public bool AI_moves;


    public void Mouse_On_UI()
    {
        state_On_UI = true;
    }
    public void Mouse_off_UI()
    {
        state_On_UI = false;
    }
    
}
