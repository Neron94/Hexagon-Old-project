using UnityEngine;
using System.Collections;


public class effect_switcher : MonoBehaviour {

    public float timer;
    public float perTime = 3;
	void Start () {
	
	}
	
	
	void Update () {
        timer += Time.deltaTime;
        if(perTime < timer)
        {
            gameObject.SetActive(false);
            perTime += timer;
        }
	
	}
}
