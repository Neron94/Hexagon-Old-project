using UnityEngine;
using System.Collections;

public class AI_Analiz : MonoBehaviour {

    private AI_Core AI_CORE;
    private AI_Command AI_COM;
    private AI_Data_Base DB;

    private GameObject cachCity;
    private GameObject cachEnemy;


    private void Start()
    {
        AI_CORE = gameObject.transform.GetComponent<AI_Core>();
        AI_COM = gameObject.transform.GetComponent<AI_Command>();
        DB = gameObject.transform.GetComponent<AI_Data_Base>();
    }

    public void Object_On_Analiz(GameObject unit)
    {
        
        //Анализ Юнита
        if(unit.gameObject.tag == "Enemy")
        {
            //ЗАХВАТ ГОРОДОВ
            if(Neutral_City_Near(unit))
            {
                Debug.Log("Нейтрал Сити не НУЛЬ");
                AI_COM.Comand_To_Object(unit,1, cachCity);
            }
            //АТАКА ПРОТИВНИКА
            else if(Enemy_Near(unit))
            {
                Debug.Log("Атакуем Юнита");
                AI_COM.Comand_To_Object(unit, 2, cachEnemy);
            }
            else
            {
                Debug.Log("Задач нет");
                AI_CORE.index_unit++;
                AI_CORE.Fraction_Analiz();
            }
            
        }
        else
        {
            //Анализ города
        }
    }

    private GameObject Neutral_City_Near(GameObject unit)
    {
        
        foreach (GameObject citys in DB.city_neutral)
        {
            if (Distance(unit.transform.position, citys.transform.position) <= 55*55)
            {
                
                cachCity = citys;
                return citys;
            }
        }
        return null;
        
    }
    private GameObject Enemy_Near(GameObject unit)
    {
        foreach (GameObject unt in DB.unit_enemy)
        {
            float dist = Vector3.Distance(unit.transform.position, unt.transform.position);
           if (dist <= unit.GetComponent<Unit>().fire_distance)
            {
                cachEnemy = unt;
                return unt;
            }

        }
        return null;
    }
    private float Distance(Vector3 unit, Vector3 target)
    {
        Vector3 disst = unit - target;
        float dist = disst.sqrMagnitude;
        
        return dist;
    }



}
