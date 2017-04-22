using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Models
{
    public class UserInfo
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string MobileNumber { get; set; }
        public string CampaingName { get; set; }
        public string rid_param { get; set; }
        public string checkModel { get; set; }
    }
}