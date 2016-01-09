using UnityEngine;
using System.Collections;

public class AI_Command: MonoBehaviour {

    private AI_Core AI_CORE;
    private Control CTRL;
    private BattleCalculator BC;

    private void Start()
    {
        CTRL = GameObject.FindGameObjectWithTag("Logic").GetComponent<Control>();
        BC = GameObject.FindGameObjectWithTag("Logic").GetComponent<BattleCalculator>();
        AI_CORE = gameObject.transform.GetComponent<AI_Core>();
    }

    public void Comand_To_Object(GameObject my_object, int command, GameObject target_object)
    {
        if(my_object.tag == "Enemy")
        {

            switch(command)
            {
                case 1: //Ищем Город рядом ничейный
                    CTRL.position_to_go = target_object.transform.position;
                    CTRL.target_object = target_object;
                    my_object.GetComponent<Unit>().Unit_Chouse();
                    GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().nna = true;
                    Invoke("EndMove", 1f);
                    break;
                case 2: //Атакуем врага в зоне поражения
                    BC.BattleModeller(my_object, target_object);
                    Invoke("EndAtack", 2f);
                    break;

            }
        }
    }
    private void EndMove()
    {
        GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().End_move();
        GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>().chose_unit[0].GetComponent<Unit>().Unit_Chouse();
        Invoke("EndAtack",6);
       
    }
    private void EndAtack()
    {
      AI_CORE.index_unit++;
      AI_CORE.Fraction_Analiz();
    }
    
	
}
