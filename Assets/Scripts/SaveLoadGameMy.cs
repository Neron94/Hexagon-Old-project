using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SaveLoadGameMy : MonoBehaviour
{
    private DataBase DB;

    public string saveUnit = "unitsSave.xml";
    public string saveFra = "fracSave.xml";
    public string saveCitys = "citysSave.xml";
    public List<GameObject> saveUnits;
    public List<GameObject> saveCity;
    public List<GameObject> saveFrac;
    List<Units> loadUnits;
    List<Citys> loadCitys;
    List<GameFractions> loadFrac;

    void Awake()
    {
        DB = GameObject.FindGameObjectWithTag("Logic").GetComponent<DataBase>();
        if(Application.loadedLevelName == "emptyLevel")
        {
            loadUnits = BinarySaver.Load(saveUnit) as List<Units>;
            loadCitys = BinarySaver.Load(saveCitys) as List<Citys>;
            loadFrac = BinarySaver.Load(saveFra) as List<GameFractions>;
            Load();
           
        }
    }
   
    public void Save_Press()
    {
        InitLists();
       BinarySaver.Save(GetUnitsToSave(), saveUnit);
       BinarySaver.Save(GetCitysToSave(), saveCitys);
       BinarySaver.Save(GetFracToSave(), saveFra);
       
  
    }
    public void Load_Press()
    {
        
        Application.LoadLevel(0);
        
        
    }
    public void Load()
    {
        SetUnits(loadUnits.Count);
        SetCitys(loadCitys.Count);
        SetFraction(loadFrac.Count);
    }
  public List<Units> GetUnitsToSave()
    {
        List<Units> toSave = new List<Units>();
        int count = saveUnits.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject obj = saveUnits[i];
            toSave.Add(new Units(obj));
        }
        saveUnits.Clear();
        return toSave;
      
    }
  public List<Citys> GetCitysToSave()
  {
          List<Citys> toCSave = new List<Citys>();
          int count = saveCity.Count;
          for (int i = 0; i < count; i++)
          {
              GameObject obj = saveCity[i];
              toCSave.Add(new Citys(obj));
          }
          Debug.Log("Citys " + toCSave.Count);
          saveCity.Clear();
          return toCSave;
   

  }
  public List<GameFractions> GetFracToSave()
  {
      List<GameFractions> toQSave = new List<GameFractions>();
      int count = saveFrac.Count;
      for (int i = 0; i < count; i++)
      {
          GameObject obj = saveFrac[i];
          toQSave.Add(new GameFractions(obj));
      }
      Debug.Log("Frac "+ toQSave.Count);
      saveFrac.Clear();
      return toQSave;

  }
    public void InitLists()
  {
        foreach(GameObject unit in DB.player_units)
        {
            saveUnits.Add(unit);
        }
        foreach(GameObject unitEn in DB.enemy_units)
        {
            saveUnits.Add(unitEn);
        }
        foreach(GameObject citys in DB.player_cities)
        {
            saveCity.Add(citys);
        }
        foreach(GameObject citysEn in DB.enemy_cities)
        {
            saveCity.Add(citysEn);
        }
        
       saveFrac.Add(GameObject.FindGameObjectWithTag("Logic").gameObject);
       saveFrac.Add(GameObject.FindGameObjectWithTag("AI").gameObject);
       
        
  }

// ==================== Функции загрузки=====================
    public void SetUnits(int ucount)
    {
        Vector3 pos;
        int count = ucount;
        for(int i = 0; i < count; i ++)
        {
            switch(loadUnits[i].fraction_name)
            {
                case "RedArmy":
                    switch(loadUnits[i].unit_Type)
                    {
                        case "Infantry":
                            pos = new Vector3(loadUnits[i].x, loadUnits[i].y, loadUnits[i].z);
                            GameObject unit = Instantiate(DB.unit_Pref_types[7], pos, Quaternion.identity) as GameObject;
                            unit.name = loadUnits[i].unitName;
                            unit.GetComponent<Unit>().unit_type = loadUnits[i].unit_Type;
                            unit.GetComponent<Unit>().unit_fraction = loadUnits[i].fraction_name;
                            unit.GetComponent<Unit>().cur_hp = loadUnits[i].cur_hp;
                            unit.GetComponent<Unit>().action_points = loadUnits[i].action_point;
                            unit.tag = loadUnits[i].unit_tag;
                            break;
                        case "Tank":
                            pos = new Vector3(loadUnits[i].x, loadUnits[i].y, loadUnits[i].z);
                            unit = Instantiate(DB.unit_Pref_types[9], pos, Quaternion.identity) as GameObject;
                            unit.name = loadUnits[i].unitName;
                            unit.GetComponent<Unit>().unit_type = loadUnits[i].unit_Type;
                            unit.GetComponent<Unit>().unit_fraction = loadUnits[i].fraction_name;
                            unit.GetComponent<Unit>().cur_hp = loadUnits[i].cur_hp;
                            unit.GetComponent<Unit>().action_points = loadUnits[i].action_point;
                            unit.tag = loadUnits[i].unit_tag;
                            break;
                        case "Cannon":
                            pos = new Vector3(loadUnits[i].x, loadUnits[i].y, loadUnits[i].z);
                            unit = Instantiate(DB.unit_Pref_types[8], pos, Quaternion.identity) as GameObject;
                            unit.name = loadUnits[i].unitName;
                            unit.GetComponent<Unit>().unit_type = loadUnits[i].unit_Type;
                            unit.GetComponent<Unit>().unit_fraction = loadUnits[i].fraction_name;
                            unit.GetComponent<Unit>().cur_hp = loadUnits[i].cur_hp;
                            unit.GetComponent<Unit>().action_points = loadUnits[i].action_point;
                            unit.tag = loadUnits[i].unit_tag;
                            break;
                    }
                    break;
                case "Wehrmacht":
                    switch (loadUnits[i].unit_Type)
                    {
                        case "Infantry":
                            pos = new Vector3(loadUnits[i].x, loadUnits[i].y, loadUnits[i].z);
                            GameObject unit = Instantiate(DB.unit_Pref_types[2], pos, Quaternion.identity) as GameObject;
                            unit.name = loadUnits[i].unitName;
                            unit.GetComponent<Unit>().unit_type = loadUnits[i].unit_Type;
                            unit.GetComponent<Unit>().unit_fraction = loadUnits[i].fraction_name;
                            unit.GetComponent<Unit>().cur_hp = loadUnits[i].cur_hp;
                            unit.GetComponent<Unit>().action_points = loadUnits[i].action_point;
                            unit.tag = loadUnits[i].unit_tag;
                            break;
                        case "Tank":
                            pos = new Vector3(loadUnits[i].x, loadUnits[i].y, loadUnits[i].z);
                            unit = Instantiate(DB.unit_Pref_types[0], pos, Quaternion.identity) as GameObject;
                            unit.name = loadUnits[i].unitName;
                            unit.GetComponent<Unit>().unit_type = loadUnits[i].unit_Type;
                            unit.GetComponent<Unit>().unit_fraction = loadUnits[i].fraction_name;
                            unit.GetComponent<Unit>().cur_hp = loadUnits[i].cur_hp;
                            unit.GetComponent<Unit>().action_points = loadUnits[i].action_point;
                            unit.tag = loadUnits[i].unit_tag;
                            break;
                        case "Cannon":
                            pos = new Vector3(loadUnits[i].x, loadUnits[i].y, loadUnits[i].z);
                            unit = Instantiate(DB.unit_Pref_types[1], pos, Quaternion.identity) as GameObject;
                            unit.name = loadUnits[i].unitName;
                            unit.GetComponent<Unit>().unit_type = loadUnits[i].unit_Type;
                            unit.GetComponent<Unit>().unit_fraction = loadUnits[i].fraction_name;
                            unit.GetComponent<Unit>().cur_hp = loadUnits[i].cur_hp;
                            unit.GetComponent<Unit>().action_points = loadUnits[i].action_point;
                            unit.tag = loadUnits[i].unit_tag;
                            break;
                    }
                    break;
            }
                
        }
    }
    public void SetCitys(int ccount)
    {
        
        int count = ccount;
        for (int i = 0; i < count; i++)
        {
            foreach(GameObject cit in DB.all_cities)
            {
                if(loadCitys[i].cityName == cit.GetComponent<city>().city_name)
                {
                    
                    cit.GetComponent<city>().switcher = loadCitys[i].switcher;
                    cit.GetComponent<city>().fraction_name = loadCitys[i].frac_name;
                    cit.GetComponent<city>().salary_factory_lvl = loadCitys[i].sal_fac_lvl;
                    cit.GetComponent<city>().baracks = loadCitys[i].baracks;
                    cit.GetComponent<city>().tank_factory = loadCitys[i].tank_factory;
                    cit.GetComponent<city>().cannon_factory = loadCitys[i].cannon_factory;
                    cit.GetComponent<city>().air_field = loadCitys[i].air_field;
                    cit.GetComponent<city>().salary_bonus = loadCitys[i].salary_bonus;
                    break;
                }
            }
        }
    }
    public void SetFraction(int countt)
    {
        int count = countt; 
        for(int i =0; i < count; i++)
        {
            if(loadFrac[i].player)
            {
                Fractions fc = GameObject.FindGameObjectWithTag("Logic").GetComponent<Fractions>();
                fc.fraction_name = loadFrac[i].fraction_name;
                fc.Salary = loadFrac[i].frac_salary;
                fc.isPlayer = loadFrac[i].player;
                GameObject.FindGameObjectWithTag("Logic").GetComponent<Control>().count_of_Turns = loadFrac[i].count_of_turns;
            }
            else
            {
                Fractions aiFc = GameObject.FindGameObjectWithTag("AI").GetComponent<Fractions>();
                aiFc.isPlayer = loadFrac[i].player;
                aiFc.fraction_name = loadFrac[i].fraction_name;
                aiFc.Salary = loadFrac[i].frac_salary;

            }
        }
    }

}


[System.Serializable]
public class Units
{
    public string unitName;
    public string unit_tag;
    public string fraction_name;
    public float cur_hp;
    public int action_point;
    public float x;
    public float y;
    public float z;
    public string unit_Type;
    

   public Units()
    {

    }
    public Units(GameObject obj)
    {
        unitName = obj.name;
        unit_tag = obj.tag;
        cur_hp = obj.GetComponent<Unit>().cur_hp;
        action_point = obj.GetComponent<Unit>().action_points;
        x = obj.transform.position.x;
        y = obj.transform.position.y;
        z = obj.transform.position.z;
        unit_Type = obj.GetComponent<Unit>().unit_type;
        fraction_name = obj.GetComponent<Unit>().unit_fraction;
    }
}
[System.Serializable]
public class Citys
{
    public string cityName;
    public int salary_bonus;
    public bool switcher;
    public string frac_name;
    public int sal_fac_lvl;
    public bool baracks;
    public bool tank_factory;
    public bool cannon_factory;
    public bool air_field;

    public Citys()
    {
    }
    public Citys(GameObject city)
    {
        cityName = city.GetComponent<city>().city_name;
        salary_bonus = city.GetComponent<city>().salary_bonus;
        switcher = city.GetComponent<city>().switcher;
        frac_name = city.GetComponent<city>().fraction_name;
        sal_fac_lvl = city.GetComponent<city>().salary_factory_lvl;
        baracks = city.GetComponent<city>().baracks;
        tank_factory = city.GetComponent<city>().tank_factory;
        cannon_factory = city.GetComponent<city>().cannon_factory;
        air_field = city.GetComponent<city>().air_field;
    }
}
[System.Serializable]
public class GameFractions
{
    public string fraction_name;
    public bool player;
    public int frac_salary;
    public int count_of_turns; // кол-во ходов игры
    public GameFractions()
    {

    }
    public GameFractions(GameObject frac)
    {
        
        fraction_name = frac.GetComponent<Fractions>().fraction_name;
        frac_salary = frac.GetComponent<Fractions>().Salary;
        count_of_turns = GameObject.FindGameObjectWithTag("Logic").GetComponent<Control>().count_of_Turns;
        player = frac.GetComponent<Fractions>().isPlayer;

    }
}