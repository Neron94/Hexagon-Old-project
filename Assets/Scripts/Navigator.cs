using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Navigator : MonoBehaviour {

    //******** Класс Навигатор Прокладывает Путь для Юнита********\\

    #region Variables
    public int ind = 0; // Счет перечесления элементов Массива
    public float[] cif = new float[7]; //Массив Дистанции до цели 
    public Control ctrl; // Ссылка на Контроль
    public DataBase DB; // Ссылка на базу данных
    public Vector3 curPos; // Текущая позиция навигатора
    public bool nna = false; // переменная включатель поиска пути
    public LineRenderer l_r;
    public Vector3 start_point; // Начальная точка при спавне навигатора
    public int c =0;
    #endregion

    void Start () {
        ctrl = GameObject.Find("Logic").GetComponent<Control>();
        DB = GameObject.Find("Logic").GetComponent<DataBase>();
        l_r = gameObject.GetComponent<LineRenderer>();
        start_point = gameObject.transform.position;
    }
	void Update () {
        if(nna)
        {
            Path_find_cicle();
        }

        
       
        
    }
    
    private void Path_find_cicle()
        {
        //Сводим к первому значению массив Дистанций окружающих обьектов до цели
            cif[1] = cif[0];
            cif[2] = cif[0];
            cif[3] = cif[0];
            cif[4] = cif[0];
            cif[5] = cif[0];
            cif[6] = cif[0];
           
        if(curPos != ctrl.position_to_go)
            {
                
                Debug.Log("Мы не находимся на точке назн");
                if(curPos != Path_finder())
                {
                    Debug.Log("Мы не на рациональном пути но начинаем двигаться туда");
                    curPos = Path_finder();
                   
                    DB.Path.Add(curPos);
                    Move_Nav(curPos);
                    
                }
            else if(curPos == Path_finder())
                {
                    curPos = new Vector3(0,0,0);
                }
          
                
                

            }
            else
            {
                Debug.Log("Мы  находимся на точке назн");
                Move_Nav(curPos);
                LineDraw();
                nna = false;
                Move_Nav(start_point);
               
            }
       
        } // Метод запускатор Поиска пути
    private Vector3 Path_finder()   //Возвращает позицию рационального пути
    {
        foreach(GameObject gj in DB.hex_eight)
        {
            cif[ind] = Vector3.Distance(gj.transform.position, ctrl.target_object.transform.position);
            ind++;
        }
        ind = 0;
        try
        {
            return Min().gameObject.transform.position;
        }
        catch
        {

            return Path_finder();
        }
        
        
     }
    private GameObject Min()
    {
        
        float minimum;
        float objDist;
        minimum = Mathf.Min(cif[0], cif[1], cif[2], cif[3], cif[4], cif[5], cif[6]);
        
        foreach(GameObject obj in DB.hex_eight)
        {
            objDist = Vector3.Distance(obj.transform.position, ctrl.target_object.transform.position);
            if(objDist == minimum)
            {
                
                return obj;
                
            }
            else
            {
                cif[1] = cif[0];
                cif[2] = cif[0];
                cif[3] = cif[0];
                cif[4] = cif[0];
                cif[5] = cif[0];
                cif[6] = cif[0];
            }
        }
        return null;
        
    } // Возвращает Обьект рационального пути Path_Finder*у
    private void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Hex")
        {
            if (!InList(obj.gameObject))
            {
                DB.hex_eight.Add(obj.gameObject);
            }


        }


    } // Инициализирует рядом стоящие Гексы
    private void OnTriggerExit(Collider exit_obj)
    {
        DB.hex_eight.Remove(exit_obj.gameObject);
    } // Удаляет Гексы при отдаление от ближайших
    private bool InList(GameObject obj)
    {

        foreach (GameObject objk in DB.hex_eight)
        {
            if (objk == obj)
            {
                return true;
            }

        }
        return false;
    } // Не позволяет записывать одни и те же гексы раз за разом
    private void Move_Nav(Vector3 point)
    {
        gameObject.transform.position = new Vector3(point.x, point.y, point.z);
    } // Метод двигает Навигатор
    private void LineDraw()
    {
       
        
        l_r.SetVertexCount(DB.Path.Count + 1);
        for (int i = 0; i < DB.Path.Count + 1; i++)
        {
            if(i > 0)
            {
                l_r.SetPosition(i, DB.Path[c]);
                c++;
            }
            if(i <= 0)
            {
                l_r.SetPosition(i, start_point);
            }
            
        }
        c = 0;
        
       

    } //Рисует путь обьекта
    public void End_move()
    {
        Destroy(gameObject);
        DB.hex_eight.Clear();
        foreach(Vector3 jj in DB.Path)
        {
            DB.chose_unit[0].GetComponent<Unit>().myPath.Add(jj);
        }
        DB.chose_unit[0].GetComponent<Unit>().Move();
        
        
    }
    public void Chose_another_unit()
    {
        
        Destroy(gameObject);
        DB.hex_eight.Clear();
        DB.Path.Clear();
    }

      
}
