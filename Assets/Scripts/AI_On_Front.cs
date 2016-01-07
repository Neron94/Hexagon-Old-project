using UnityEngine;
using System.Collections;

public class AI_On_Front : MonoBehaviour {
    /*private AI_Data_Base AI_DB;
    private Control Ctrl;

    private float targ_Distance;

    private bool unit_moving_proces = false;

    private float timer;
    private bool timer_On;

    private void Start()
    {
        AI_DB = gameObject.transform.GetComponent<AI_Data_Base>();
        Ctrl = GameObject.FindGameObjectWithTag("Logic").GetComponent<Control>();
    }
    private void Update()
    {
        

      

        
        
    }
    public void MyTurn()
    {

    }


    public void Search_And_Destroy()
    {
        //в будущ. можно добавить входные данные в конкретные обьекты и учесть тип юнита из чего более точно работать
        targ_Distance = Vector3.Distance(AI_DB.unit_my[0].transform.position, AI_DB.unit_enemy[0].transform.position);
        if(targ_Distance > 13)
        {
            MoveUnit();
        }
        else
        {
            unit_moving_proces = false;
           // Atack();
        }
    }

    private void MoveUnit()
    {
        if(AI_DB.unit_my[0].GetComponent<Unit>().action_points != 0)
        {
            Ctrl.position_to_go = AI_DB.unit_enemy[0].GetComponent<Unit>().my_hex.transform.position;
            Ctrl.target_object = AI_DB.unit_enemy[0].GetComponent<Unit>().my_hex;
            AI_DB.unit_my[0].GetComponent<Unit>().Unit_Chouse();
            GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().nna = true;

          

        }
        else
        {
            unit_moving_proces = false;
            Ctrl.End_of_Turn();
            Ctrl.whoTurn = false;
            
        }
        
    }
    private void Atack()
    {
        
    }*/
	
}
