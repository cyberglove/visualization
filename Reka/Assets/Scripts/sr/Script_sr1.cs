using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_sr1 : MonoBehaviour {

    public Script_dlon script1;
    private float xFirstAngle;
    private float xNew,yOld, zOld, xOld;
    // Use this for initialization
    void Start () {
        xOld = transform.localEulerAngles.x;
        yOld = transform.localEulerAngles.y;
        zOld = transform.localEulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {
        xFirstAngle = ((script1.AngleSrodkowy * 8) / 10);

        xNew = xOld + xFirstAngle;

        transform.localEulerAngles = new Vector3(xNew, yOld, zOld);
    }
}
