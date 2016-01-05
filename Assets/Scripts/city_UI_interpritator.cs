using UnityEngine;
using System.Collections;

public class city_UI_interpritator : MonoBehaviour {

    private DataBase DB;

    void Start()
    {
        DB = GameObject.Find("Logic").GetComponent<DataBase>();
    }
    public void MainButton(int num)
    {
        if (num == 1)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().MainButton(1);
        }
        else if (num == 2)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().MainButton(2);
        }
        else if (num == 3)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().MainButton(3);
        }
        else if (num == 4)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().MainButton(4);
        }
    }
    public void StructButton(int index)
    {
        if (index == 1)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().StructButton(1);
        }
        else if (index == 2)
        {

            DB.city_selected[0].GetComponent<city_UI_manager>().StructButton(2);

        }
        else if (index == 3)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().StructButton(3);

        }
        else if (index == 4)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().StructButton(4);
        }
        else if (index == 5)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().StructButton(5);
        }
    }
    public void Naym_Soldat(int index)
    {
        if (index == 1)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().Naym_Soldat(1);
        }
        else if (index == 2)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().Naym_Soldat(2);
        }
        else if (index == 3)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().Naym_Soldat(3);
        }
    }
    public void Garnizon(int index)
    {
        if (index == 1)
        {

            DB.city_selected[0].GetComponent<city_UI_manager>().Garnizon(1);

        }
        else if (index == 2)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().Garnizon(2);
        }
        else if (index == 3)
        {
            DB.city_selected[0].GetComponent<city_UI_manager>().Garnizon(3);
         
        }
    }
    public void Back_Button()
    {
        DB.city_selected[0].GetComponent<city_UI_manager>().Back_Button();
    }
	
}
