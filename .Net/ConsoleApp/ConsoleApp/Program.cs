using Microsoft.Extensions.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        private static readonly IConfiguration _configuration = Startup.BuildConfiguation();
        private static string _connectionString = _configuration["ConnectionString:sqlConnectionString"];

        static void Main(string[] args)
        {
            IEnumerable<string> logs = Directory.EnumerateFiles("C:\\Resources\\TESTING\\LogFiles\\DEV\\W3SVC1");
            string regExpression = @"^(\d{4}\-\d{2}\-\d{2})(.*)$";
            Regex expression = new Regex(regExpression, RegexOptions.IgnoreCase);

            foreach (string log in logs)
            {
                try
                {
                    StreamReader reader = new StreamReader(log);
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        Match match = expression.Match(line);
                        if (match.Success)
                        {
                            string [] logArray = line.Split(" ");
                            using(var context = new LogDbContext())
                            {
                                var iisLogs = new IISFields
                                {
                                    EventDate = logArray[0],
                                    EventTime = logArray[1],
                                    FilePath = logArray[2],
                                    FileName = logArray[3],
                                    SiteName = logArray[4],
                                    Hostname = logArray[5],
                                    HostIp = logArray[6],
                                    HttpMethod = logArray[7],
                                    Endpoint = logArray[8],
                                    Query = logArray[9],
                                    LocalPort = logArray[10],
                                    Username = logArray[11],
                                    ClientIp = logArray[12],
                                    HttpVerion = logArray[13],
                                    UserAgent = logArray[14],
                                    ClientCookie = logArray[15],
                                    URL = logArray[16],
                                    WebSite = logArray[17],
                                    HttpStatusCode = logArray[18],
                                    SubStatus = logArray[19],
                                    Win32Status = logArray[20],
                                    SourceBytes = logArray[21],
                                    ClientBytes = logArray[22],
                                    ResponseTime = logArray[23]
                                };
                                context.Log.Add(iisLogs);
                                context.SaveChanges();
                                
                            }
                        }
                    line = reader.ReadLine();
                    }
                    reader.Close();
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }
        }
    }
}