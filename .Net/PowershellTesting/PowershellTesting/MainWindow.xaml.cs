using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Management.Automation;
using System.IO;
using System.Management.Automation.Runspaces;
using Namotion.Reflection;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace PowershellTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtComputer.Text = Environment.GetEnvironmentVariable("COMPUTERNAME");
        }

        public string stringBuilder { get; private set; }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            RunScript();
            //txtResults.Text = txtResults.Text + "DeviceID: $($item.DeviceID)`n";
            //txtResults.Text = txtResults.Text + "VolumeName: $($item.VolumeName)`n";
            //txtResults.Text = txtResults.Text + "FreeSpace: $($item.FreeSpace)`n";
            //txtResults.Text = txtResults.Text + "Size: $($item.Size)`n`n";
            //txtResults.Text = stringBuilder;

        }
        private string RunScript()
        {
            // create Powershell runspace
            Runspace runspace = RunspaceFactory.CreateRunspace();

            // open it
            runspace.Open();

            // create a pipeline and feed it the script text
            Pipeline pipeline = runspace.CreatePipeline();
            //pipeline.Commands.AddScript(scriptText);

            // add an extra command to transform the script
            // output objects into nicely formatted strings

            // remove this line to get the actual objects
            // that the script returns. For example, the script

            // "Get-Process" returns a collection
            // of System.Diagnostics.Process instances.
            pipeline.Commands.Add("Out-String");


            // execute the script
            PowerShell ps = PowerShell.Create();
            ps.AddScript(string.Format(@"Import-module '.\Scripts\Example.ps1'; Get-FixedDisk -Computer '{0}'", txtComputer.Text));
            //ps.AddCommand("pwd");
            //ps.AddParameter("ComputerName", txtComputer.Text);
            var results = ps.Invoke();
           
            // close the runspace
            runspace.Close();

            // convert the script result into a single string
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.AppendLine(obj.ToString());
            }

            foreach (var item in results)
            {
                txtResults.Text = txtResults.Text + "DeviceID: " + Convert.ToString(item.Members[name:"DeviceID"].Value) + "\n";
                txtResults.Text = txtResults.Text + "VolumeName: " + Convert.ToString(item.Members[name: "VolumeName"].Value) + "\n";
                txtResults.Text = txtResults.Text + "FreeSpace: " + Convert.ToString(item.Members[name: "FreeSpace"].Value) + "\n";
                txtResults.Text = txtResults.Text + "Size: " + Convert.ToString(item.Members[name: "Size"].Value) + "\n\n";
            }
            return stringBuilder.ToString();
        }
    }
}
