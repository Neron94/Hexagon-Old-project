using UnityEngine;
using System.Collections;

public class AI_Core : MonoBehaviour {

    private Fractions MY_FRAC;
    public AI_Data_Base AI_DB;
    private AI_Analiz AI_ANLZ;
    private AI_Command AI_COM;

    


    private void Start()
    {
        MY_FRAC = gameObject.transform.GetComponent<Fractions>();
        AI_DB = gameObject.transform.GetComponent<AI_Data_Base>();
        AI_ANLZ = gameObject.transform.GetComponent<AI_Analiz>();
        AI_COM = gameObject.transform.GetComponent<AI_Command>();
    }

    public void Fraction_Analiz()
    {
        //Сбор инф. о фракции
        Unit_Chose();
        
    }
    private void Unit_Chose()
    {
       
            foreach (GameObject unit in AI_DB.unit_my)
            {
                if (unit.GetComponent<Unit>().action_points > 0)
                {
                    
                    AI_ANLZ.Object_On_Analiz(unit);
                    break;

                }
                else
                {
                    
                    
                }
            }
     
        
        City_Chose();
    }
    private void City_Chose()
    {
        foreach(GameObject city in AI_DB.city_my)
        {
            if(MY_FRAC.Salary >= 100)
            {
                AI_ANLZ.Object_On_Analiz(city);
            }
            else
            {
                End_of_AI_Turn();
            }
        }
        End_of_AI_Turn();
    }

    private void End_of_AI_Turn()
    {
        Debug.Log("ИИ ЗАКОНЧИЛ ХОД");
    }

   
}
