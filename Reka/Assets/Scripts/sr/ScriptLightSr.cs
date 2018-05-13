using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLightSr : MonoBehaviour {

    public Script_dlon script1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Light>().intensity = ((script1.LightSrodkowy * 2) / 100);
    }
}
