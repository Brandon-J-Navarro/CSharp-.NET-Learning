using System;
using System.Linq;
using Windows.Devices.Enumeration;
using Windows.Storage;

using Windows.Devices.HumanInterfaceDevice;
using Windows.Storage.Streams;
using Windows.UI.Core;

namespace UPSMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            this.InitializeComponent();
            EnumerateHidDevices();
        }

        // Find HID devices.
        private static async void EnumerateHidDevices()
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
                Console.WriteLine("HID devices found: " + devices.Count);

                // Open the target HID device.
                HidDevice device = await HidDevice.FromIdAsync(devices.ElementAt(0).Id, FileAccessMode.ReadWrite);

                if (device != null)
                {
                    // Input reports contain data from the device.
                    device.InputReportReceived += async (sender, args) =>
                    {
                        HidInputReport inputReport = args.Report;
                        IBuffer buffer = inputReport.Data;

                        // Create a DispatchedHandler as we are interracting with the UI directly and the
                        // thread that this function is running on might not be the UI thread; 
                        // if a non-UI thread modifies the UI, an exception is thrown.

                        //await this.Dispatcher.RunAsync(
                        //    CoreDispatcherPriority.Normal,
                        //    new DispatchedHandler(() =>
                        //    {
                                Console.WriteLine("\nHID Input Report: " + inputReport.ToString() +
                                "\nTotal number of bytes received: " + buffer.Length.ToString());
                            //}));
                    };
                }

            }
            else
            {
                // There were no HID devices that met the selector criteria.
                Console.WriteLine("HID device not found");
            }
        }
    }
}