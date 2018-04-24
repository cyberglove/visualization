using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;

namespace serialConnection
{
    class connectionProgram
    {
        public UInt32[] values = new UInt32[10];
        private String[] fingers = { "K", "W", "Ś", "S", "M" };
        private String[] substrings;
        private SerialPort port;

        public string[] Fingers { get => fingers; set => fingers = value; }

        [STAThread] //musi być, żeby SerialPort działał

        static void Main(string[] args)
        {
            connectionProgram program = new connectionProgram();
            Thread.Sleep(1000);
            program.DoTheThing();
        }

        private connectionProgram()
        {
            String[] ports = SerialPort.GetPortNames();
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
                for(int i=0; i<5; ++i)
                {
                    values[i] = Convert.ToUInt32(substrings[i], 10);
                    Console.Write(fingers[i] + ": " + values[i] + " ");
                }
                Console.Write("| ");
                for (int i = 5; i < 10; ++i)
                {
                    values[i] = Convert.ToUInt32(substrings[i], 10);
                    Console.Write(fingers[i%5] + ": " + values[i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}