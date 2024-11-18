using System.Configuration;
using System.IO.Ports;

namespace ConsoleAppSerialMonitor
{
    class Program
    {
        private static readonly string _commPort = ConfigurationManager.AppSettings["CommPort"];
        private static readonly int _baudRate = Convert.ToInt32(ConfigurationManager.AppSettings["BaudRate"]);
        private static readonly string _parityValue = ConfigurationManager.AppSettings["Parity"];
        private static readonly Parity _parity = (Parity)Enum.Parse(typeof(Parity), _parityValue);
        private static readonly int _dataBits = Convert.ToInt32(ConfigurationManager.AppSettings["DataBits"]);
        private static readonly string _stopBitsValue = ConfigurationManager.AppSettings["StopBits"];
        private static readonly StopBits _stopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBitsValue);

        private static SerialPort _port = new SerialPort(portName: _commPort, baudRate: _baudRate, parity: _parity, dataBits: _dataBits, stopBits: _stopBits);

        static void Main(string[] args)
        {
            bool _loop = true;
            while (_loop)
            {
                try
                {
                    _loop = SerialPortProgram.ReadSerialPort(_port);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

    }

    class SerialPortProgram
    {
        public static bool ReadSerialPort(SerialPort port)
        {
            bool _condition = true;
            port.Open();
            while (_condition)
            {
                string _line = port.ReadLine();
                Console.WriteLine(_line);
                if (_line == "I'm down.\r")
                {
                    _condition = false;
                }
            }
            port.Close();
            return _condition;
        }
    }
}