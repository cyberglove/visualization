using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_dlon : MonoBehaviour {

    [Range(0, 100)]
    public float AngleKciuk;
    [Range(0, 100)]
    public float AngleWskazujacy;
    [Range(0, 100)]
    public float AngleSrodkowy;
    [Range(0, 100)]
    public float AngleSerdeczny;
    [Range(0, 100)]
    public float AngleMaly;
    [Range(0, 100)]
    public float LightKciuk;
    [Range(0, 100)]
    public float LightWskazujacy;
    [Range(0, 100)]
    public float LightSrodkowy;
    [Range(0, 100)]
    public float LightSerdeczny;
    [Range(0, 100)]
    public float LightMaly;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AdjustAngleKciuk(float newAngle)
    {
        AngleKciuk = newAngle;
    }

    public void AdjustAngleWskazujacy(float newAngle)
    {
        AngleWskazujacy = newAngle;
    }

    public void AdjustAngleSrodkowy(float newAngle)
    {
        AngleSrodkowy = newAngle;
    }

    public void AdjustAngleSerdeczny(float newAngle)
    {
        AngleSerdeczny = newAngle;
    }

    public void AdjustAngleMaly(float newAngle)
    {
        AngleMaly = newAngle;
    }

    public void AdjustLightKciuk(float newLight)
    {
        LightKciuk = newLight;
    }

    public void AdjustLightWskazujacy(float newLight)
    {
        LightWskazujacy = newLight;
    }

    public void AdjustLightSrodkowy(float newLight)
    {
        LightSrodkowy = newLight;
    }

    public void AdjustLightSerdeczny(float newLight)
    {
        LightSerdeczny = newLight;
    }

    public void AdjustLightMaly(float newLight)
    {
        LightMaly = newLight;
    }
}
