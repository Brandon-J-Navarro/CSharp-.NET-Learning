using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Devices.HumanInterfaceDevice;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UPSMonitorUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            EnumerateHidDevices();
        }

        // Find HID devices.
        private async void EnumerateHidDevices()
        {
            // Microsoft Input Configuration Device.
            ushort vendorId = 0x051D;
            ushort productId = 0x0002;
            ushort usagePage = 0x0084;
            ushort usageId = 0x0004;

            // Create the selector.
            string selector = HidDevice.GetDeviceSelector(usagePage, usageId, vendorId, productId);

            // Enumerate devices using the selector.
            var devices = await DeviceInformation.FindAllAsync(selector);

            if (devices.Any())
            {
                // At this point the device is available to communicate with
                // So we can send/receive HID reports from it or 
                // query it for control descriptions.
                info.Text = "HID devices found: " + devices.Count;

                // Open the target HID device.
                HidDevice device = await HidDevice.FromIdAsync(devices[0].Id, FileAccessMode.ReadWrite);

                if (device == null)
                {
                    // Input reports contain data from the device.
                    device.InputReportReceived += async (sender, args) =>
                    {
                        HidInputReport inputReport = args.Report;
                        IBuffer buffer = inputReport.Data;

                        // Create a DispatchedHandler as we are interracting with the UI directly and the
                        // thread that this function is running on might not be the UI thread; 
                        // if a non-UI thread modifies the UI, an exception is thrown.

                        await this.Dispatcher.RunAsync(
                            CoreDispatcherPriority.Normal,
                            new DispatchedHandler(() =>
                            {
                                info.Text += "\nHID Input Report: " + inputReport.ToString() +
                                "\nTotal number of bytes received: " + buffer.Length.ToString();
                            }));
                    };
                }

            }
            else
            {
                // There were no HID devices that met the selector criteria.
                info.Text = "HID device not found";
            }
        }
    }
}