using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_w1 : MonoBehaviour {

    public Script_dlon script1;
    private float xFirstAngle, yFirstAngle;
    private float xNew, yNew, yOld, zOld, xOld;

    // Use this for initialization
    void Start () {
        xOld = transform.localEulerAngles.x;
        yOld = transform.localEulerAngles.y;
        zOld = transform.localEulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {
        xFirstAngle = ((script1.AngleWskazujacy * 8) / 10);
        yFirstAngle = ((script1.AngleWskazujacy * 15) / 100);

        xNew = xOld + xFirstAngle;
        yNew = yOld - yFirstAngle;

        transform.localEulerAngles = new Vector3(xNew, yNew, zOld);
    }
}
