using UnityEngine;
using System.Collections;


public class HexComb : MonoBehaviour {

    //**********Класс Гекса Запиывает себя в Базу Данных Гексов*********\\

    #region Variables
    private DataBase DB;
    public SpriteRenderer sp;
    public Sprite avail_hex;
    public Sprite point_go;
    public Sprite enemy_target;
    public Sprite def;
    public float bonus_defence;
    public int bonus_atack;

    public GameObject unit_on_hex;
    public GameObject city_on_hex;
    #endregion


    void Start () {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        DB.hex_comb.Add(gameObject);
        sp = gameObject.GetComponentInChildren<SpriteRenderer>();
                  }
	void Update () {
        
	}
    public void Change(int sw)
    {
        int case_switch = sw;
        switch (case_switch)
        {
            case 1:
                sp.sprite = def;
                break;
            case 2:
                sp.sprite = avail_hex;
                break;
            case 3:
                sp.sprite = point_go;
                break;
            case 4:
                sp.sprite = enemy_target;
                break;
                
        }
        
    }
    
    
    
   
}
