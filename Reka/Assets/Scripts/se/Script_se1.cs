using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_se1 : MonoBehaviour {

    public Script_dlon script1;
    private float xFirstAngle, yFirstAngle;
    private float xNew, yNew, yOld, zOld, xOld;
    // private Vector3 Axis;
    // Use this for initialization
    void Start () {
        xOld = transform.localEulerAngles.x;
        yOld = transform.localEulerAngles.y;
        zOld = transform.localEulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {
        xFirstAngle = ((script1.AngleSerdeczny * 8) / 10);
        yFirstAngle = (script1.AngleSerdeczny / 10);

        xNew = xOld + xFirstAngle;
        yNew = yOld + yFirstAngle;

        transform.localEulerAngles = new Vector3(xNew, yNew, zOld);
    }
}
//x
// 1    -0.9120 -> 78.49
// 2    -0.767 -> 88.9   18.976
// 3    -0.179 -> 69.17

//z
// 1    16 -3   16 2
