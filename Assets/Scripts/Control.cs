using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour

{
    //******Класс Оперирующий Элементы управления******\\

    #region Variables
    private DataBase DB;
    private StateManager SM;
    private UI ui;
    private BattleCalculator BC;
    public Vector3 position_to_go; //Позиция Гекса куда нужно добраться
    public GameObject target_object; //Обьект (юнит) от которого мерится дистнция до целевого гекса
    public int count_of_Turns = 0; // сторит число прошедших ходов
    private GameObject enemy_correct; // сторит первый вражеский юнит цель при повторном нажатие стреляет
    public GameObject marker;
    public bool air_support_is_action = false;
    public bool whoTurn = false;
    #endregion
    void Start()
    {
        ui = GameObject.FindGameObjectWithTag("myUI").GetComponent<UI>();
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        BC = GameObject.FindGameObjectWithTag("Logic").GetComponent<BattleCalculator>();
        SM = GameObject.FindGameObjectWithTag("Logic").GetComponent<StateManager>();
        target_object = gameObject;
        
    }


    void Update()
    {
        if (!SM.state_pause)
        {
            if (!SM.state_unit_movement)
            {

                if (!SM.state_On_UI)
                {

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (DB.enemy_chose.Count == 1)
                        {
                            DB.enemy_chose[0].GetComponent<Unit>().Enemy_Chose();
                        }

                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        Physics.Raycast(ray, out hit, Mathf.Infinity);

                        if (hit.collider.gameObject.tag == "Hex")
                        {
                            if (enemy_correct != null)
                            {
                                enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
                                enemy_correct = null;
                            }
                            if (DB.city_selected.Count != 0)
                            {
                                ui.ButtonHider("hide_stats");
                                DB.city_selected[0].GetComponent<city>().City_Chosen();
                            }

                            foreach (GameObject obj in DB.hex_comb)
                            {
                                if (hit.collider.gameObject == obj)
                                {

                                    if (DB.chose_unit.Count == 1)
                                    {

                                        GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().nna = true;
                                        position_to_go = obj.transform.position;


                                        if (target_object.transform.position == position_to_go)
                                        {
                                            target_object = gameObject;

                                            GameObject.FindGameObjectWithTag("Navigator").GetComponent<Navigator>().End_move();

                                            DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();


                                        }
                                        if (DB.path_drawer.Count != 0)
                                        {
                                            foreach (GameObject gj in DB.path_drawer)
                                            {
                                                gj.GetComponent<HexComb>().Change(1);
                                            }
                                            DB.path_drawer.Clear();
                                        }


                                        target_object = obj;
                                    }
                                    else
                                    {
                                        if (obj.GetComponent<HexComb>().city_on_hex != null)
                                        {
                                            AirSupCancel();
                                            obj.GetComponent<HexComb>().city_on_hex.GetComponent<city>().City_Chosen();

                                        }

                                    }


                                    DB.Path.Clear();

                                }
                            }

                        }

                        else if (hit.collider.gameObject.tag == "player_unit")
                        {


                            AirSupCancel();
                            if (enemy_correct != null)
                            {
                                enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
                                enemy_correct = null;
                            }
                            if (DB.city_selected.Count != 0)
                            {
                                DB.city_selected[0].GetComponent<city>().City_Chosen();
                            }

                            if (DB.chose_unit.Count == 1)
                            {

                                if (DB.chose_unit[0].tag == "Army")
                                {
                                    DB.chose_unit[0].GetComponent<Army>().Army_Chose();
                                }
                                else
                                {
                                    DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
                                }

                            }


                            foreach (GameObject unit in DB.player_units)
                            {
                                if (hit.collider.gameObject == unit)
                                {

                                    unit.GetComponent<Unit>().Unit_Chouse();

                                }
                            }
                        }
                        else if (hit.collider.gameObject.tag == "Enemy")
                        {

                            if (DB.city_selected.Count != 0)
                            {
                                DB.city_selected[0].GetComponent<city>().City_Chosen();
                            }
                            if (DB.chose_unit.Count == 1)
                            {

                                if (DB.chose_unit[0].GetComponent<Unit>().action_points >= 2)
                                {
                                    foreach (GameObject enemy in DB.enemy_units)
                                    {

                                        if (hit.collider.gameObject == enemy)
                                        {

                                            float enemy_Distance = Vector3.Distance(DB.chose_unit[0].transform.position, enemy.transform.position);

                                            if (DB.chose_unit[0].GetComponent<Unit>().fire_distance > enemy_Distance)
                                            {

                                                DB.chose_unit[0].GetComponent<Unit>().Unit_rotation(enemy, enemy);
                                                hit.collider.gameObject.GetComponent<Unit>().target.SetActive(true);
                                                if (hit.collider.gameObject == enemy_correct)
                                                {

                                                    BC.BattleModeller(DB.chose_unit[0], enemy);
                                                    DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
                                                    enemy_correct.GetComponent<Unit>().target.SetActive(false);
                                                    enemy_correct = null;

                                                }
                                                else
                                                {
                                                    if (enemy_correct != null)
                                                    {

                                                        enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
                                                        enemy_correct = null;

                                                    }
                                                }
                                                enemy_correct = hit.collider.gameObject;




                                            }
                                            break;
                                        }
                                    }
                                }

                            }
                            else if (air_support_is_action == true)
                            {
                                hit.collider.gameObject.GetComponent<Unit>().target.SetActive(true);
                                if (hit.collider.gameObject == enemy_correct)
                                {

                                    BC.AirSupportFire(hit.collider.gameObject, DB.gameObject.transform.GetComponent<Fractions>().air_power);
                                    DB.gameObject.transform.GetComponent<Fractions>().Salary_minus(DB.gameObject.transform.GetComponent<Fractions>().air_cost);
                                    enemy_correct.GetComponent<Unit>().target.SetActive(false);
                                    enemy_correct = null;
                                    air_support_is_action = false;
                                }
                                else
                                {
                                    if (enemy_correct != null)
                                    {
                                        enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
                                        enemy_correct = null;
                                    }
                                }
                                enemy_correct = hit.collider.gameObject;
                            }


                            else
                            {
                                foreach (GameObject gj in DB.enemy_units)
                                {
                                    if (hit.collider.gameObject == gj)
                                    {
                                        gj.GetComponent<Unit>().Enemy_Chose();
                                    }
                                }
                            }


                        }
                        else if (hit.collider.gameObject.tag == "Army")
                        {

                            AirSupCancel();
                            if (DB.city_selected.Count != 0)
                            {
                                DB.city_selected[0].GetComponent<city>().City_Chosen();
                            }
                            if (DB.chose_unit.Count == 1)
                            {
                                if(DB.chose_unit[0].tag == "player_unit")
                                {
                                    DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
                                }
                                
                            }
                            if (hit.collider.gameObject.GetComponent<Army>().army_contain[0].tag == "player_unit")
                            {
                                hit.collider.gameObject.GetComponent<Army>().Army_Chose();
                            }

                            else
                            {
                                Debug.Log("Что то не так");
                            }
                        }
                    }
                }

            }


        }
    }

    public void End_of_Turn()
    {
        
        count_of_Turns++;
        ui.label_of_turn.text = ("You Turn "+ count_of_Turns);
        ui.ButtonHider("label_of_turn");
        ui.ButtonHider("close_label");
        foreach(GameObject units in DB.player_units)
        {
            units.GetComponent<Unit>().End_Turn();
        
        }
        foreach (GameObject units in DB.enemy_units)
        {
            units.GetComponent<Unit>().End_Turn();

        }
        
        foreach (GameObject ct in DB.all_cities)
        {
            ct.GetComponent<city>().Money_pay();
            
        }
        if(DB.chose_unit.Count == 1)
        {
            DB.chose_unit[0].GetComponent<Unit>().Unit_Chouse();
        }
        GameObject.FindGameObjectWithTag("Save").GetComponent<SaveLoadGameMy>().Save_Press();
        
    }
    public void Turn_of_Enemy()
    {
        SM.AI_moves = true;
        GameObject.FindGameObjectWithTag("AI").GetComponent<AI_Core>().Fraction_Analiz();
    }
    public void AirSupCancel()
    {
        if(air_support_is_action == true)
        {
            enemy_correct.GetComponent<Unit>().target.SetActive(false);
            air_support_is_action = false;
        }
        if (enemy_correct != null)
        {
            enemy_correct.GetComponent<Unit>().my_hex.GetComponent<HexComb>().Change(1);
            enemy_correct = null;
        }
        
    }
   

    }




