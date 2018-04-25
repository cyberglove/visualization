using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using ExtensionMethods;

namespace serialConnection
{
	class connectionProgram
	{
		public Double[] doubleValues = new Double[10];
		private Double[] toInterval = { 0.0, 100.0 };
		private Int32[] fromShort = { 1000, 2000 };
		private Int32[] fromLong = { 1200, 3400 };
		private Int32[] fromPressure = { 1000, 3100 };

		private Int32 precision = 2;
		private String[] fingers = { "K", "W", "Ś", "S", "M" };
		private String[] substrings;
		private SerialPort port;

		public string[] Fingers { get => fingers; set => fingers = value; }

		[STAThread] //musi być, żeby SerialPort działał

		static void Main(string[] args)
		{
			connectionProgram program = new connectionProgram();
			program.DoTheThing();
		}

		private connectionProgram()
		{
			String[] ports = SerialPort.GetPortNames();
			Console.WriteLine(ports[0]);
			port = new SerialPort(ports[0], 115200, Parity.None, 8, StopBits.One);
		}

		~connectionProgram()
		{
			port.Close();
		}

		private void DoTheThing()
		{
			port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
			port.Open();
			Application.Run(); //nieskonczona pętla programu
		}

		private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			String temp = port.ReadLine().Replace("\r", "");
			substrings = temp.Split('|');

			if (substrings.Length == 10)
			{
				for (Int32 i = 0; i < 10; ++i)
				{
					if (i < 2)
					{
						doubleValues[i] = CalculateMapValue(substrings[i],fromShort[0], fromShort[1], toInterval[0], toInterval[1], precision);
					}
					else if (i >= 2 && i < 5)
					{
						doubleValues[i] = CalculateMapValue(substrings[i],fromLong[0],fromLong[1], toInterval[0], toInterval[1], precision);
					}
					else if( i >= 5)
					{
						doubleValues[i] = CalculateMapValue(substrings[i],fromPressure[0],fromPressure[1], toInterval[0], toInterval[1], precision);
					}

					if (i == 5)
					{
						Console.Write("|");
					}
					else if( i == 1 || i == 6)
					{
						Console.Write(fingers[i % 5] + ": " + Convert.ToString(doubleValues[i+3]) + "% ");
					}
					else if( i == 4 || i == 9)
					{
						Console.Write(fingers[i % 5] + ": " + Convert.ToString(doubleValues[i-3]) + "% ");
					}
					else 
					{
						Console.Write(fingers[i % 5] + ": " + Convert.ToString(doubleValues[i]) + "% ");
					}
				}
				Console.WriteLine();
			}
		}


		Double CalculateMapValue(String valueToMap, Int32 fromMin, Int32 fromMax, Double toMin, Double toMax, Int32 precision)
		{
			return Math.Round(Convert.ToInt32(valueToMap, 10).MapValue(fromMin, fromMax, toMin, toMax), precision);
		}
	}
}

namespace ExtensionMethods
{
	public static class MyExtensions
	{
		public static Double MapValue(this Int32 value, Int32 fromMin, Int32 fromMax, Double toMin, Double toMax)
		{
			return toMin + (toMax - toMin) * ((Convert.ToDouble(value - fromMin) / Convert.ToDouble(fromMax - fromMin)));
		}
	}
}