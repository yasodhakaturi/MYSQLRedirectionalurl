using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Models
{
    public class List_IP
    {
        public int pk_shorturl_id { get; set; }
        public long? ipnum { get; set; }
        public string ipaddress { get; set; }
    }
    public class ip_info
    {
        public string ipaddress { get; set; }
        public string ipheadertype { get; set; }

    }
}