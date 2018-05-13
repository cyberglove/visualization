using UnityEngine;

public class ScriptLightK : MonoBehaviour {

    public Script_dlon script1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Light>().intensity = ((script1.LightKciuk * 2) / 100);
    }
}
