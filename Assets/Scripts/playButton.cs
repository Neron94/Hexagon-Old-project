using UnityEngine;
using System.Collections;

public class playButton : MonoBehaviour {

    public GameObject canvas_main;
    public GameObject canvas_settings;

    public void Start()
    {
        canvas_main = GameObject.Find("Canvas");
        canvas_settings = GameObject.Find("Canvas_settings");
    }
	public void Play()
    {
        Application.LoadLevel(1);
    }
    public void Settings()
    {
        canvas_main.SetActive(false);
        canvas_settings.SetActive(true);
    }
    public void Back()
    {
        canvas_main.SetActive(true);
        canvas_settings.SetActive(false);
    }
}
