using System;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace serialConnection
{
    class Program
    {
        private String[] substrings;
        private SerialPort port;
        [STAThread] //musi być, żeby SerialPort działał

        static void Main(string[] args)
        {
            Program program = new Program();
            program.doTheThing();
        }

        private Program()
        {
            String[] ports = SerialPort.GetPortNames();
            port = new SerialPort(ports[0], 115200, Parity.None, 8, StopBits.One);
        }

        ~Program()
        {
            port.Close();
        }
        private void doTheThing()
        {
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.Open();
            Application.Run(); //nieskonczona pętla programu
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            String temp = port.ReadLine();
            substrings = temp.Split('|');

            foreach (String s in substrings)
            {
                Console.Write(s + " ");
            }
            Console.Write("\n");
        }
    }
}