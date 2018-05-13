using System;
using System.IO.Ports;
using UnityEngine;
using ExtensionMethods;

public class Script_dlon : MonoBehaviour
{
	private SerialPort port;

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

	private float[] toInterval = { 0.0f, 100.0f };
	private Int32[] fromKc = { 2530, 1650 };
	private Int32[] fromWs = { 2760, 1950 };
	private Int32[] fromSr = { 2860, 1950 };
	private Int32[] fromSe = { 2550, 1520 };
	private Int32[] fromMa = { 2360, 1570 };
	private Int32[] fromZZ = { 2500, 0 };
	private Int32 precision = 2;

	void Start()
	{
		String[] ports = SerialPort.GetPortNames();
		Console.WriteLine(ports[0]);
		port = new SerialPort(ports[0], 115200, Parity.None, 8, StopBits.One);
	}

	void Update()
	{
		String data = port.ReadLine();
		String[] substrings = data.Split('|');

		if (substrings.Length == 10)
		{
			AngleKciuk = CalculateMapValue(substrings[0], fromKc[0], fromKc[1], toInterval[0], toInterval[1], precision); ;
			AngleWskazujacy = CalculateMapValue(substrings[1], fromWs[0], fromWs[1], toInterval[0], toInterval[1], precision);
			AngleSrodkowy = CalculateMapValue(substrings[2], fromSr[0], fromSr[1], toInterval[0], toInterval[1], precision);
			AngleSerdeczny = CalculateMapValue(substrings[3], fromSe[0], fromSe[1], toInterval[0], toInterval[1], precision);
			AngleMaly = CalculateMapValue(substrings[4], fromMa[0], fromMa[1], toInterval[0], toInterval[1], precision);

			LightKciuk = CalculateMapValue(substrings[5], fromZZ[0], fromZZ[1], toInterval[0], toInterval[1], precision);
			LightWskazujacy = CalculateMapValue(substrings[6], fromZZ[0], fromZZ[1], toInterval[0], toInterval[1], precision);
			LightSrodkowy = CalculateMapValue(substrings[7], fromZZ[0], fromZZ[1], toInterval[0], toInterval[1], precision);
			LightSerdeczny = CalculateMapValue(substrings[8], fromZZ[0], fromZZ[1], toInterval[0], toInterval[1], precision);
			LightMaly = CalculateMapValue(substrings[9], fromZZ[0], fromZZ[1], toInterval[0], toInterval[1], precision);
		}
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

	float CalculateMapValue(String valueToMap, Int32 fromMin, Int32 fromMax, float toMin, float toMax, Int32 precision)
	{
		return (float)Math.Round(Convert.ToInt32(valueToMap, 10).MapValue(fromMin, fromMax, toMin, toMax), precision);
	}

	public void connect()
	{
		if (!port.IsOpen)
		{
			port.Open();
		}
		else
		{
			port.Close();
		}
	}

	public void reset()
	{
		AngleKciuk = 0.0f;
		AngleWskazujacy = 0.0f;
		AngleSrodkowy = 0.0f;
		AngleSerdeczny = 0.0f;
		AngleMaly = 0.0f;

		LightKciuk = 0.0f;
		LightWskazujacy = 0.0f;
		LightSrodkowy = 0.0f;
		LightSerdeczny = 0.0f;
		LightMaly = 0.0f;
	}
}

namespace ExtensionMethods
{
	public static class MyExtensions
	{
		public static float MapValue(this Int32 value, Int32 fromMin, Int32 fromMax, float toMin, float toMax)
		{
			return toMin + (toMax - toMin) * (float)((Convert.ToDouble(value - fromMin) / Convert.ToDouble(fromMax - fromMin)));
		}
	}
}