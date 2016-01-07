using UnityEngine;
using System.Collections;

public class AI_Command: MonoBehaviour {

    private Control CTRL;
    private BattleCalculator BC;

    private void Start()
    {
        CTRL = GameObject.FindGameObjectWithTag("Logic").GetComponent<Control>();
        BC = GameObject.FindGameObjectWithTag("Logic").GetComponent<BattleCalculator>();
    }

    public void Comand_To_Object(GameObject my_object, int command, GameObject target_object)
    {
        if(my_object.tag == "Enemy")
        {

            switch(command)
            {
                case 1:

                    CTRL.position_to_go = target_object.transform.position;
                    CTRL.target_object = target_object;
                    my_object.GetComponent<Unit>().Unit_Chouse();
                    GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().nna = true;
                    Invoke("EndMove", 0.5f);
                    break;
                case 2:
                    BC.BattleModeller(my_object, target_object);
                    break;

            }
        }
    }
    private void EndMove()
    {
        GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().End_move();
        GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>().chose_unit[0].GetComponent<Unit>().Unit_Chouse();
        
    }
	
}
