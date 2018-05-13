using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLightW : MonoBehaviour {

    public Script_dlon script1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Light>().intensity = ((script1.LightWskazujacy * 2) / 100);
    }
}
