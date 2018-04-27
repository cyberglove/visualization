using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_se2 : MonoBehaviour {

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
        xSecondAngle = ((script1.AngleSerdeczny * 80) / 100);
        ySecondAngle = ((script1.AngleSerdeczny * 5) / 100);

        xNew = xOld + (xSecondAngle);
        yNew = yOld + (ySecondAngle);

        transform.localEulerAngles = new Vector3(xNew, yNew, zOld);
    }
}
