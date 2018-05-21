using UnityEngine;

public class Script_k1 : MonoBehaviour {

    public Script_dlon script1;
    private float xFirstAngle, yFirstAngle, zFirstAngle;
    private float xNew, yNew, zNew, yOld, zOld, xOld;

    // Use this for initialization
    void Start () {
        xOld = transform.localEulerAngles.x;
        yOld = transform.localEulerAngles.y;
        zOld = transform.localEulerAngles.z;
    }
	
	// Update is called once per frame
	void Update () {
        xFirstAngle = ((script1.AngleKciuk * 4) / 10);
        yFirstAngle = ((script1.AngleKciuk * 6) / 10);
        zFirstAngle = ((script1.AngleKciuk * 35) / 100);

        xNew = xOld + xFirstAngle;
        yNew = yOld - yFirstAngle;
        zNew = zOld - zFirstAngle;

        transform.localEulerAngles = new Vector3(xNew, yNew, zNew);
    }
}
