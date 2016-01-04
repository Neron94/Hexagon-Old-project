using UnityEngine;
using System.Collections;

public class BattleCalculator : MonoBehaviour {
    public void BattleModeller(GameObject atacker, GameObject defender)
    {
        atacker.GetComponent<Unit>().fire_effect.SetActive(true);
        float def = defender.GetComponent<Unit>().unit_cur_defence;
        int atk = atacker.GetComponent<Unit>().unit_fire_power;
        float atack_power = atk - def;
        defender.GetComponent<Unit>().cur_hp -= atack_power;
        atacker.GetComponent<Unit>().action_points -= 2;
        BackFire(defender, atacker);
        atacker.GetComponent<Unit>().Unit_Chouse();
    }

    public void BackFire(GameObject firing, GameObject back_target)
    {
        float back_defence = back_target.GetComponent<Unit>().unit_cur_defence;
        int fire_of_damaged = firing.GetComponent<Unit>().unit_fire_power / 2;
        float damage = fire_of_damaged - back_defence;
        back_target.GetComponent<Unit>().cur_hp -= fire_of_damaged;
    }
}
