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
		private Int32[] fromKc = { 2530, 1650 };
		private Int32[] fromWs = { 2760, 1950 };
		private Int32[] fromSr = { 2860, 1950 };
		private Int32[] fromSe = { 2550, 1520};
		private Int32[] fromMa = { 2360, 1570 };

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
					if(i==0)
					{
						doubleValues[i] = CalculateMapValue(substrings[i], fromKc[0], fromKc[1], toInterval[0], toInterval[1], precision);

					}
					else if(i==1)
					{
						doubleValues[i] = CalculateMapValue(substrings[i], fromWs[0], fromWs[1], toInterval[0], toInterval[1], precision);

					}
					else if(i==2)
					{
						doubleValues[i] = CalculateMapValue(substrings[i], fromSr[0], fromSr[1], toInterval[0], toInterval[1], precision);

					}
					else if(i==3)
					{
						doubleValues[i] = CalculateMapValue(substrings[i], fromSe[0], fromSe[1], toInterval[0], toInterval[1], precision);

					}
					else if(i==4)
					{
						doubleValues[i] = CalculateMapValue(substrings[i], fromMa[0], fromMa[1], toInterval[0], toInterval[1], precision);

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