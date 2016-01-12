using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class city_UI_manager : MonoBehaviour {

    Fractions frac;

    public GameObject panel_main;
    public GameObject panel_structers;
    public GameObject panel_naym;
    public GameObject panel_garnizon;
    public GameObject unit_but_1;
    public GameObject unit_but_2;
    public GameObject unit_but_3;

    public Image unit_1;
    public Image unit_2;
    public Image unit_3;

    public Button structers;

    public Image sal_factory;
    
    public Button sal_factory_but;
    public Button baracks;
    public Button cannon;
    public Button tank;
    public Button air;

    public Button naym_infantry;
    public Button naym_tank;
    public Button naym_cannon;
    public Button naym_Air;



    public Sprite sal_fac_lvl_one;
    public Sprite sal_fac_lvl_two;
    

    public int[] factory_price = { 100, 150, 200 };
    public int baracks_fac_price = 100;
    public int cannon_fac_price = 150;
    public int tank_fac_price = 200;
    public int air_field_price = 300;
   


    


    void Start()
    {
        structers = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Main").gameObject.transform.FindChild("Structs").GetComponent<Button>();
        panel_main = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Main").gameObject;
        frac = GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>();
        panel_structers = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Struct").gameObject;
        panel_naym = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Naym").gameObject;
        panel_garnizon = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Garnizon").gameObject;
        sal_factory = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Struct").gameObject.transform.FindChild("Sal_Factory").gameObject.GetComponent<Image>();
        sal_factory_but = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Struct").gameObject.transform.FindChild("Sal_Factory").gameObject.GetComponent<Button>();
        baracks = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Struct").gameObject.transform.FindChild("Baracks").gameObject.GetComponent<Button>();
        cannon = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Struct").gameObject.transform.FindChild("Cannon").gameObject.GetComponent<Button>();
        tank = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Struct").gameObject.transform.FindChild("Tank").gameObject.GetComponent<Button>();
        air = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Struct").gameObject.transform.FindChild("Air").gameObject.GetComponent<Button>();
        naym_cannon = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Naym").gameObject.transform.FindChild("Cannon").gameObject.GetComponent<Button>();
        naym_tank = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Naym").gameObject.transform.FindChild("Tank").gameObject.GetComponent<Button>();
        naym_infantry = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Naym").gameObject.transform.FindChild("Infantry").gameObject.GetComponent<Button>();
        naym_Air = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Naym").gameObject.transform.FindChild("Air").gameObject.GetComponent<Button>();
        naym_infantry.interactable = false;
        naym_cannon.interactable = false;
        naym_tank.interactable = false;
        naym_Air.interactable = false;
        unit_but_1 = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Garnizon").gameObject.transform.FindChild("Unit_1").gameObject;
        unit_but_2 = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Garnizon").gameObject.transform.FindChild("Unit_2").gameObject;
        unit_but_3 = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Garnizon").gameObject.transform.FindChild("Unit_3").gameObject;
        unit_1 = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Garnizon").gameObject.transform.FindChild("Unit_1").GetComponent<Image>();
        unit_2 = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Garnizon").gameObject.transform.FindChild("Unit_2").GetComponent<Image>();
        unit_3 = gameObject.transform.FindChild("Canvas").gameObject.transform.FindChild("Panel_Garnizon").gameObject.transform.FindChild("Unit_3").GetComponent<Image>();
    }
    void Update()
    {
       
        if(gameObject.transform.GetComponent<city>().baracks == true)
        {
            
            naym_infantry.interactable = true;
        }
        if (gameObject.transform.GetComponent<city>().cannon_factory == true)
        {
            naym_cannon.interactable = true;
        }
        if (gameObject.transform.GetComponent<city>().tank_factory == true)
        {
            naym_tank.interactable = true;
        }
        if(gameObject.transform.GetComponent<city>().air_field == true)
        {
            naym_Air.interactable = true;
        }
        
    }


    public void MainButton(int num)
    {
        if(num == 1)
        {
            panel_structers.SetActive(true);
            panel_main.SetActive(false);
        }
        else if (num == 2)
        {
            panel_naym.SetActive(true);
            panel_main.SetActive(false);
        }
        else if (num == 3)
        {
            panel_garnizon.SetActive(true);
            panel_main.SetActive(false);
        }
        else if(num == 4)
        {
          
        }
    }
    public void StructButton(int index)
    {
        if(index == 1)
        {
            if (gameObject.transform.GetComponent<city>().salary_factory_lvl == 0)
            {
                if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= factory_price[0])
                {
                    sal_factory.sprite = sal_fac_lvl_one;
                   gameObject.transform.GetComponent<city>().Build_Salary_Factory(1);
                    GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(factory_price[0]);
                }
            }
            else if (gameObject.transform.GetComponent<city>().salary_factory_lvl == 1)
            {
                if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= factory_price[1])
                {
                    sal_factory.sprite = sal_fac_lvl_two;
                    gameObject.transform.GetComponent<city>().Build_Salary_Factory(2);
                    GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(factory_price[1]);
                }
            }
            else if (gameObject.transform.GetComponent<city>().salary_factory_lvl == 2)
            {
                if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= factory_price[2])
                {
                    sal_factory_but.interactable = false;
                    gameObject.transform.GetComponent<city>().Build_Salary_Factory(3);
                    GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(factory_price[2]);
                }
            }

            
            
        }
        else if (index == 2)
        {
            if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= baracks_fac_price)
            {
                baracks.interactable = false;
               gameObject.transform.GetComponent<city>().baracks = true;
                GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(baracks_fac_price);
            }


        }
        else if (index == 3)
        {
            if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= cannon_fac_price)
            {
                gameObject.transform.GetComponent<city>().cannon_factory = true;
                cannon.interactable = false;
                GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(cannon_fac_price);
            }

        }
        else if (index == 4)
        {
            if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= tank_fac_price)
            {
                gameObject.transform.GetComponent<city>().tank_factory = true;
                tank.interactable = false;
                GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(tank_fac_price);

            }
        }
        else if (index == 5)
        {
            if (GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary >= air_field_price)
            {
                gameObject.transform.GetComponent<city>().air_field = true;
                air.interactable = false;
                GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>().Salary_minus(air_field_price);
            }
        }
    }
    public void Naym_Soldat(int index)
    {
        if(index == 1)
        {
            frac.buy_unit("infantry");
        }
        else if(index == 2)
        {
            frac.buy_unit("cannon");
        }
        else if (index == 3)
        {
            frac.buy_unit("tank");
        }
        else if (index == 4)
        {
            frac.buy_unit("air");
        }
    }
    public void Garnizon(int index)
    {
        if(index == 1)
        {

            gameObject.transform.GetComponent<city>().units_in_city[0].GetComponent<Unit>().Unit_Chouse();
           gameObject.transform.GetComponent<city>().City_Chosen();
           
        }
        else if(index == 2)
        {
            
            gameObject.transform.GetComponent<city>().units_in_city[1].GetComponent<Unit>().Unit_Chouse();
            gameObject.transform.GetComponent<city>().City_Chosen();
        }
        else if(index == 3)
        {
           
            gameObject.transform.GetComponent<city>().units_in_city[2].GetComponent<Unit>().Unit_Chouse();
            gameObject.transform.GetComponent<city>().City_Chosen();
        }
    }
    public void Back_Button()
    {
          panel_main.SetActive(true);
          panel_structers.SetActive(false);
          panel_naym.SetActive(false);
          panel_garnizon.SetActive(false);
    }
    public void SoldiersInCity(GameObject first)
    {
        unit_but_1.SetActive(true);
        unit_1.sprite = first.GetComponent<Unit>().icon;
        unit_but_2.SetActive(false);
        unit_but_3.SetActive(false);
    }
    public void SoldiersInCity(GameObject first, GameObject second)
    {
        unit_but_1.SetActive(true);
        unit_1.sprite = first.GetComponent<Unit>().icon;
        unit_but_2.SetActive(true);
        unit_2.sprite = first.GetComponent<Unit>().icon;
        unit_but_3.SetActive(false);
    }
    public void SoldiersInCity(GameObject first, GameObject second, GameObject Third)
    {
        unit_but_1.SetActive(true);
        unit_1.sprite = first.GetComponent<Unit>().icon;
        unit_but_2.SetActive(true);
        unit_2.sprite = first.GetComponent<Unit>().icon;
        unit_but_3.SetActive(true);
        unit_3.sprite = first.GetComponent<Unit>().icon;
    }
    public void  SoldiersNone()
    {
        unit_but_1.SetActive(false);
        unit_but_2.SetActive(false);
        unit_but_3.SetActive(false);
    }


}
