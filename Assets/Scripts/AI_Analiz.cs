using UnityEngine;
using System.Collections;

public class AI_Analiz : MonoBehaviour {

    private AI_Core AI_CORE;
    private AI_Command AI_COM;


    private void Start()
    {
        AI_CORE = gameObject.transform.GetComponent<AI_Core>();
        AI_COM = gameObject.transform.GetComponent<AI_Command>();
    }

    public void Object_On_Analiz(GameObject unit)
    {
        //Анализ Юнита
        if(unit.gameObject.tag == "Enemy")
        {
            //ЗАХВАТ ГОРОДОВ
            if(Neutral_City_Near(unit)!= null)
            {
                AI_COM.Comand_To_Object(unit,1, Neutral_City_Near(unit));
            }
            //АТАКА ПРОТИВНИКА
            else if(Enemy_Near(unit)!= null)
            {
                AI_COM.Comand_To_Object(unit, 2, Enemy_Near(unit));
            }
            
            
        }
        else
        {
            //Анализ города
        }
    }

    private GameObject Neutral_City_Near(GameObject unit)
    {
        foreach (GameObject citys in AI_CORE.AI_DB.city_neutral)
        {
            float dist = Vector3.Distance(unit.transform.position, citys.transform.position);
            Debug.Log("Дистанция до города" + dist);
            if (dist <= 55)
            {
                return citys;
                
               
                
            }
        }
        return null;
    }
    private GameObject Enemy_Near(GameObject unit)
    {
        foreach (GameObject unt in AI_CORE.AI_DB.unit_enemy)
        {
            float dist = Vector3.Distance(unit.transform.position, unt.transform.position);
            Debug.Log("Дистанция до врага" + dist);
            if (dist <= unit.GetComponent<Unit>().fire_distance)
            {
                return unt;
             
               
            }

        }
        return null;
    }



}
