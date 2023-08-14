using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp
{
    partial class Service : ServiceBase
    {
        private static Timer aTimer;
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new Timer(10000); // 10 Seconds
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            DataProcessor dataProcessor = new DataProcessor();
            dataProcessor.Execute();
        }

        protected override void OnStop()
        {
            aTimer.Stop();
        }

    }
}
