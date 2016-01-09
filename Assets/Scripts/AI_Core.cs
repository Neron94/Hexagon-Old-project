using UnityEngine;
using System.Collections;

public class AI_Core : MonoBehaviour {

    private Fractions MY_FRAC;
    public AI_Data_Base AI_DB;
    private AI_Analiz AI_ANLZ;
    private AI_Command AI_COM;
    private StateManager SM;
    

    public int index_unit = 0;

    


    private void Start()
    {
        SM = GameObject.FindGameObjectWithTag("Logic").GetComponent<StateManager>();
       
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
    private  void Unit_Chose()
    {
        if(index_unit<= AI_DB.unit_my.Count-1)
        {
            AI_ANLZ.Object_On_Analiz(AI_DB.unit_my[index_unit]);
        }
        else
        {
            End_of_AI_Turn();
        }
      
        
     
        
       
    }
    private void City_Chose()
    {
        
            foreach (GameObject city in AI_DB.city_my)
            {
                if (MY_FRAC.Salary >= 100)
                {
                    AI_ANLZ.Object_On_Analiz(city);
                }
                else
                {

                }
            }
        Invoke("End_of_AI_Turn",2);
        
    }

    private void End_of_AI_Turn()
    {
        
        SM.AI_moves = false;
        index_unit = 0;
        Debug.Log("ИИ ЗАКОНЧИЛ ХОД");
        GameObject.FindGameObjectWithTag("Logic").GetComponent<Control>().End_of_Turn();
    }
   

   
}
