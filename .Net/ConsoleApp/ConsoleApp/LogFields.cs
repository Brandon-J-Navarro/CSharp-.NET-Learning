using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    [Table("Log")]
    public class IISFields
    {
        [Key]
        public string EventDate { get; set; }
        public string EventTime { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string SiteName { get; set; }
        public string Hostname { get; set; }
        public string HostIp { get; set; }
        public string HttpMethod { get; set; }
        public string Endpoint { get; set; }
        public string Query { get; set; }
        public string LocalPort { get; set; }
        public string Username { get; set; }
        public string ClientIp { get; set; }
        public string HttpVerion { get; set; }
        public string UserAgent { get; set; }
        public string ClientCookie { get; set; }
        public string URL { get; set; }
        public string WebSite { get; set; }
        public string HttpStatusCode { get; set; }
        public string SubStatus { get; set; }
        public string Win32Status { get; set; }
        public string SourceBytes { get; set; }
        public string ClientBytes { get; set; }
        public string ResponseTime { get; set; }
    }
}
