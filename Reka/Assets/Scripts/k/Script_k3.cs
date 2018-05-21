using UnityEngine;

public class Script_k3 : MonoBehaviour {

    public Script_dlon script1;
    private float xNew, yOld, zOld, xOld;
    private float xThirdAngle;

    // Use this for initialization
    void Start () {
        xOld = transform.localEulerAngles.x;
        yOld = transform.localEulerAngles.y;
        zOld = transform.localEulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {
        xThirdAngle = ((script1.AngleKciuk * 80) / 100);

        xNew = xOld + xThirdAngle;

        transform.localEulerAngles = new Vector3(xNew, yOld, zOld);
    }
}
