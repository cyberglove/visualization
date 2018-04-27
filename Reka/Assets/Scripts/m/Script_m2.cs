using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_m2 : MonoBehaviour {

    public Script_dlon script1;
    private float xNew, yNew, yOld, zOld, xOld;
    private float xSecondAngle, ySecondAngle;

    // Use this for initialization
    void Start () {
        xOld = transform.localEulerAngles.x;
        yOld = transform.localEulerAngles.y;
        zOld = transform.localEulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {
        xSecondAngle = ((script1.AngleMaly * 70) / 100);
        ySecondAngle = ((script1.AngleMaly * 27) / 100);

        xNew = xOld + (xSecondAngle);
        yNew = yOld + (ySecondAngle);

        transform.localEulerAngles = new Vector3(xNew, yNew, zOld);
    }
}
