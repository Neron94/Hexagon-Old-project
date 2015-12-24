using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class city_UI : MonoBehaviour {

    private city myCity;
    private DataBase DB;



    

    public GameObject but_fac_first;
    public GameObject but_fac_second;
    public GameObject but_fac_third;
    public int[] bonus_level = { 10, 5, 5 };
    public int[] upgrade_price = { 100, 150, 200 };
    public int[] war_fac_prices = { 150, 200 };

    public GameObject but_canno_fac;
    public GameObject but_tank_fac;

    public GameObject have_mark_1;
    public GameObject have_mark_2;
    public GameObject have_mark_3;
    public GameObject have_mark_4;
    public GameObject have_mark_5;

    public GameObject but_infantry;
    public GameObject but_cannon;
    public GameObject but_tank;
    
    void Start()
    {
       
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        but_cannon.GetComponent<Button>().interactable = false;
        but_tank.GetComponent<Button>().interactable = false;
        but_fac_second.GetComponent<Button>().interactable = false;
        but_fac_third.GetComponent<Button>().interactable = false;
    }
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(DB.city_selected[0]!= null)
            {
                myCity = DB.city_selected[0].GetComponent<city>();
            }
        }
    }
    public void Factory_upgrade(int level)
    {
        if (level == 0)
        {
            but_fac_second.GetComponent<Button>().interactable = false;
            but_fac_third.GetComponent<Button>().interactable = false;
        }
        else if (level == 1)
        {
            if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= upgrade_price[0])
            {
                but_fac_first.GetComponent<Button>().interactable = false;
                but_fac_second.GetComponent<Button>().interactable = true;
                have_mark_1.SetActive(true);
                but_fac_third.GetComponent<Button>().interactable = false;
                myCity.salary_bonus += bonus_level[0];
                GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(upgrade_price[0]);
            }
            
        }
        else if (level == 2)
        {
            if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= upgrade_price[1])
            {
                but_fac_first.GetComponent<Button>().interactable = false;
                but_fac_second.GetComponent<Button>().interactable = false;
                but_fac_third.GetComponent<Button>().interactable = true;
                have_mark_1.SetActive(true);
                have_mark_2.SetActive(true);
                myCity.salary_bonus += bonus_level[1];
                GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(upgrade_price[1]);
            }
            
        }
        else if (level == 3)
        {
            if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= upgrade_price[2])
            {
                but_fac_first.GetComponent<Button>().interactable = false;
                but_fac_second.GetComponent<Button>().interactable = false;
                but_fac_third.GetComponent<Button>().interactable = false;
                have_mark_1.SetActive(true);
                have_mark_2.SetActive(true);
                have_mark_3.SetActive(true);
                myCity.salary_bonus += bonus_level[2];
                GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(upgrade_price[2]);
            }
            
        }
    }
    public void Cannon_factory()
    {
        if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= war_fac_prices[0])
        {
            but_canno_fac.GetComponent<Button>().interactable = false;
            have_mark_4.SetActive(true);
            GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(war_fac_prices[0]);
            but_cannon.GetComponent<Button>().interactable = true;
        }
   
    }
    public void Tank_factory()
    {
        if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= war_fac_prices[1])
        {
            but_tank_fac.GetComponent<Button>().interactable = false;
            have_mark_5.SetActive(true);
            GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(war_fac_prices[1]);
            but_tank.GetComponent<Button>().interactable = true;
        }
       
    }
}
