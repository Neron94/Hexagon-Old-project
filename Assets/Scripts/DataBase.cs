using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataBase : MonoBehaviour {

    //*********Класс Базы Данных*********\\
    #region Variables
    public List<GameObject> hex_comb; //БД Всех Гексов на карте
    public List<GameObject> hex_eight; //БД Окружающих Гексов
    public List<Vector3> Path; // Список посещенных точек
    public List<GameObject> player_units; //список Юнитов Игрока
    public List<GameObject> enemy_units; // список Юнитов противника
    public List<GameObject> chose_unit; // список выбранных юнитов 
    public List<GameObject> all_units;
    #endregion


    void Start () {


        

	}
	void Update () {

	
	}
    public void Clear_select_list()
    {
        if(chose_unit.Count == 1)
        {
            chose_unit[0].GetComponent<Unit>().Unit_Chouse();
        }
        else
        {
            Debug.Log("Юнита то и нет");
        }
        
    }
    public void Current_Unit(string command)
    {
        if(command == "Rotate")
        {
            chose_unit[0].GetComponent<Unit>().Unit_rotation();
            
        }
        else if(command == "Build_barrikade")
        {
            chose_unit[0].GetComponent<Unit>().Build_barricade();
        }
        else
        {
            Debug.Log("Неизвестная команда");
        }
        
    }
   
}
