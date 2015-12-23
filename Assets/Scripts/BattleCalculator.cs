using UnityEngine;
using System.Collections;

public class BattleCalculator : MonoBehaviour {
    public void BattleModeller(GameObject atacker, GameObject defender)
    {
        atacker.GetComponent<Unit>().fire_effect.SetActive(true);
        float def = defender.GetComponent<Unit>().unit_defence;
        int atk = atacker.GetComponent<Unit>().unit_fire_power;
        float atack_power = atk - def;
        defender.GetComponent<Unit>().cur_hp -= atack_power;
        atacker.GetComponent<Unit>().action_points -= 2;
        atacker.GetComponent<Unit>().Unit_Chouse();
    }
}
