using UnityEngine;
using System.Collections;

public class partisialDestructor : MonoBehaviour {

	void Start () {
        Invoke("Destruct", 2);
	}
    void Destruct()
    {
        Destroy(gameObject);
    }
	
}
