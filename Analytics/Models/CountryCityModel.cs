﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Models
{
    public class CountryCityModel
    {
        //public long startIpNum { get; set; }
        //public long endIpNum { get; set; }
        public long? ipnum { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string Region{get;set;}
        //public string region_code { get; set; }
        public string PostalCode { get; set; }
       // public string time_zone { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string metro_code { get; set; }
        //public string accuracy_radius { get; set; }
        public int fk_city_master_id { get; set; }
        public int pk_shorturl_id{get;set;}
        
        
    }

    public class locids
    {
        public long? ipnum { get; set; }
        public int localid { get; set; }
        public int pk_shorturl_id { get; set; }
        public int fk_city_master_id { get; set; }

    }
    public class uiddataobj
    {
        public string UniqueNumber { get; set; }
        public int? FK_RID { get; set; }
        public int? FK_ClientID { get; set; }
        public int PK_Uid { get; set; }
        public string MobileNumber { get; set; }
        public string LongurlorMessage { get; set; }
        public string Type { get; set; }
    }
}