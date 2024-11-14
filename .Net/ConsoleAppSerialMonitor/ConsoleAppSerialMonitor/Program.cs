using System.Configuration;
using System.IO.Ports;

namespace ConsoleAppSerialMonitor
{
    class SerialPortProgram
    {
        private static readonly string _commPort = ConfigurationManager.AppSettings["CommPort"];
        private static readonly int _baudRate = Convert.ToInt32(ConfigurationManager.AppSettings["BaudRate"]);
        private static readonly string _parityValue = ConfigurationManager.AppSettings["Parity"];
        private static readonly Parity _parity = (Parity)Enum.Parse(typeof(Parity), _parityValue);
        private static readonly int _dataBits = Convert.ToInt32(ConfigurationManager.AppSettings["DataBits"]);
        private static readonly string _stopBitsValue = ConfigurationManager.AppSettings["StopBits"];
        private static readonly StopBits _stopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBitsValue);

        private SerialPort port = new SerialPort(portName: _commPort, baudRate: _baudRate, parity: _parity, dataBits: _dataBits, stopBits: _stopBits);

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    new SerialPortProgram();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        private SerialPortProgram()
        {
            port.Open();
            while (true)
            {
                Console.WriteLine(port.ReadLine());
            }
            port.Close();
        }
    }
}