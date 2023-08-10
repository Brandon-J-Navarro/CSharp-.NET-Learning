using System;
using System.Text;
using System.Windows;
using System.Management.Automation;
using System.Management.Automation.Runspaces;


namespace PowershellTesting
{
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
            txtResults.Text = stringBuilder;
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

            foreach (var item in results)
            {
                stringBuilder = stringBuilder + "DeviceID: " + Convert.ToString(item.Members[name:"DeviceID"].Value) + "\n";
                stringBuilder = stringBuilder + "VolumeName: " + Convert.ToString(item.Members[name: "VolumeName"].Value) + "\n";
                stringBuilder = stringBuilder + "FreeSpace: " + Convert.ToString(item.Members[name: "FreeSpace"].Value) + "\n";
                stringBuilder = stringBuilder + "Size: " + Convert.ToString(item.Members[name: "Size"].Value) + "\n\n";
            }
            return stringBuilder.ToString();
        }
    }
}
