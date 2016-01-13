using UnityEngine;
using System.Collections;
using System.IO;

public class playButton : MonoBehaviour {

    public GameObject canvas_main;
    public GameObject canvas_settings;
    public GameObject continuePanel;
    public GameObject newGame;
    public GameObject settings;


    public void Start()
    {
        canvas_main = GameObject.Find("Canvas");
        canvas_settings = GameObject.Find("Canvas_settings");
        continuePanel = canvas_main.transform.FindChild("Continue").gameObject;
        newGame = canvas_main.transform.FindChild("NewGame").gameObject;
        settings = canvas_main.transform.FindChild("Settings").gameObject;
    }
	public void Play()
    {
       if(File.Exists(Application.persistentDataPath + "/unitsSave.asg"))
       {
           newGame.SetActive(true);
       }
       else
       {
           continuePanel.SetActive(true);
       }
        
    }
    public void NewGame()
    {
        continuePanel.SetActive(false);
        newGame.SetActive(true);
    }
    public void ContinueGame()
    {
        GameObject.FindGameObjectWithTag("Save").GetComponent<SaveLoadGameMy>().Load_Press();
    }
    public void Settings()
    {
        settings.SetActive(true);
    }
    
    public void Back()
    {
        canvas_main.SetActive(true);
        newGame.SetActive(false);
        settings.SetActive(false);

    }
}
