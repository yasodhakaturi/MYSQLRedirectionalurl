using Analytics.Helpers.Utility;
using Analytics.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel.Web;
using System.Text;
using System.Web;


namespace Analytics.Helpers.BO
{
    public class OperationsBO
    {
        shortenurlEntities dc = new shortenurlEntities();
        string connStr = ConfigurationManager.ConnectionStrings["shortenURLConnectionString"].ConnectionString;
        MySqlConnection lSQLConn = null;
        MySqlCommand lSQLCmd = new MySqlCommand();

       
        public uiddata CheckUniqueid(string Uniqueid_UIDRID)
        {
            try
            {
                // bool check;
                uiddata un_UID = new uiddata();
                un_UID = (from uniid in dc.uiddatas
                          where uniid.UniqueNumber == Uniqueid_UIDRID
                          select uniid).SingleOrDefault();
                if (un_UID != null)
                {
                    //check = true;
                    return un_UID;
                }
                else
                {
                    //check = false;
                    return un_UID;
                }
            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
                return null;
            }
        }
        //public bool CheckPassword_riddata(int? rid, string pwd)
        //{
        //    try
        //    {
        //        int row_rid = 0; bool check;
        //        row_rid = (from r in dc.riddatas
        //                   where r.PK_Rid == rid && r.Pwd == pwd
        //                   select r.PK_Rid).SingleOrDefault();
        //        if (row_rid != 0 && row_rid != null)
        //            check = true;
        //        else
        //            check = false;
        //        return check;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //        return false;
        //    }
        //}
        //public int GetUniqueid(int Uniqueid_UIDRID, string type)
        //{
        //    try
        //    {
        //        int un_UIDRID = 0;
        //        un_UIDRID = (from uniid in dc.UIDandriddatas
        //                     where uniid.UIDorRID == Uniqueid_UIDRID && uniid.TypeDiff == type
        //                     select uniid.PK_UniqueId).SingleOrDefault();
        //        if (un_UIDRID != 0)
        //            return un_UIDRID;
        //        else
        //            return un_UIDRID;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //        return 0;
        //    }
        //}
        //public string GetLongURL(int Uniqueid_ShortURL)
        //{
        //    try
        //    {
        //        string LongURL = "";
        //        LongURL = (from uniid in dc.UIDandriddatas
        //                   join uidtable in dc.uiddatas on uniid.UIDorRID equals uidtable.PK_Uid
        //                   where uniid.PK_UniqueId == Uniqueid_ShortURL
        //                   select uidtable.Longurl).SingleOrDefault();
        //        if (LongURL != "")
        //            return LongURL;
        //        else
        //            return LongURL;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //        return "";
        //    }

        //}
        //public PWDDataBO GetUIDriddata(int Uniqueid_UIDRID)
        //{
        //    try
        //    {
        //        string pwd = null;
                
        //        PWDDataBO obj = (from uniid in dc.UIDandriddatas
        //                       where uniid.PK_UniqueId == Uniqueid_UIDRID  
        //                       select new PWDDataBO
        //                     {
        //                         typediff=uniid.TypeDiff,
        //                         UIDorRID=uniid.UIDorRID
        //                     }).SingleOrDefault();
        //        if (obj != null)
        //        {
        //            if (obj.typediff == "2")
        //            {
        //                pwd = (from r in dc.riddatas
        //                       where r.PK_Rid == obj.UIDorRID
        //                       select r.Pwd).SingleOrDefault();
        //                obj.pwd = pwd;
        //            }
        //            else
        //            {
        //                obj.pwd = pwd;
        //            }
        //            return obj;
        //        }
        //        else
        //            return null;
                
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //        return null;
        //    }
        //}
        //public int? GetUIDRID(int Uniqueid_UIDRID, string type)
        //{
        //    try
        //    {
                
        //        int? un_UIDRID = 0;
        //        un_UIDRID = (from uniid in dc.UIDandriddatas
        //                     where uniid.PK_UniqueId == Uniqueid_UIDRID && uniid.TypeDiff == type
        //                     select uniid.UIDorRID).SingleOrDefault();
        //        if (un_UIDRID != 0)
        //        {

        //            return un_UIDRID;
        //        }
        //        else
        //        {

        //            return un_UIDRID;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //        return 0;
        //    }
        //}

        //public UserViewModel GetViewConfigDetails(string url)
        //{
        //    UserViewModel obj = new UserViewModel();
        //    string env = ""; string appurl = "";

        //    // if (url.Contains(".com") || url.Contains("www."))
        //    //  env = "prod";
        //    // else
        //    // env = "dev"; 

        //    //obj.env = env;
        //    //if (url.Contains(".com") || url.Contains("www."))
        //    //    appurl = url;
        //    //else
        //    //    appurl = "http://localhost:3000";

        //    env = ConfigurationManager.AppSettings["env"].ToString();
        //    appurl = ConfigurationManager.AppSettings["appurl"].ToString();


        //    obj.appUrl = appurl;
        //    UserInfo user_obj = new UserInfo();

        //    if (HttpContext.Current.Session["userdata"] != null)
        //    {
        //        user_obj.user_id = Helper.CurrentUserId;
        //        user_obj.user_name = Helper.CurrentUserName;
        //        //user_obj.user_role = Helper.CurrentUserRole;
        //        if (Helper.CurrentUserRole.ToLower() == "admin")
        //        { obj.isAdmin = "true"; obj.isClient = "false"; }
        //        else if (Helper.CurrentUserRole.ToLower() == "client")
        //        { obj.isClient = "true"; obj.isAdmin = "false"; }
        //    }
        //    else
        //    {
        //        user_obj.user_id = 0;
        //        user_obj.user_name = "null";
        //        obj.isAdmin = "false";
        //        obj.isClient = "false";
        //    }
            
        //    obj.userInfo = user_obj;
        //    appUrlModel appobj = new appUrlModel();
        //    appobj.admin = "/Admin";
        //    appobj.analytics = "/Analytics";
        //    appobj.landing = "/Home";
        //    obj.apiUrl = appobj;
        //    return obj;
        //}
        public long convertAddresstoNumber(string ipaddress)
        {
            long ip = 0;
            try
            {
                string[] ipaddressstr;
                ipaddressstr = ipaddress.Split('.');
                long o1 = Convert.ToInt64(ipaddressstr[0]);
                long o2 = Convert.ToInt64(ipaddressstr[1]);
                long o3 = Convert.ToInt64(ipaddressstr[2]);
                long o4 = Convert.ToInt64(ipaddressstr[3]);

                 ip = (16777216 * o1) + (65536 * o2) + (256 * o3) + o4;
                //string ipstr = ip.ToString();
                //int ipstr = Convert.ToInt32(ip);
                return ip;
                //long longAddress = BitConverter.ToInt64(IPAddress.Parse(ipaddress).GetAddressBytes(), 0);
                //string ipAddress = new IPAddress(BitConverter.GetBytes(intAddress)).ToString();
                //return longAddress.ToString();
            }
            catch(Exception ex)
            {
                return ip;
            }
        }
        public ip_info IpAddress()
        {
            string strIpAddress; ip_info ipinfo_obj = new ip_info();
            strIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            //ErrorLogs.LogErrorData("HTTP_X_FORWARDED_FOR", HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]);
            if (strIpAddress == null)
            {

                strIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_REAL_IP"];
                if (strIpAddress == null)
                {
                    strIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                    ipinfo_obj.ipaddress = strIpAddress;
                    ipinfo_obj.ipheadertype = "REMOTE_ADDR";
                }
                else
                {
                    ipinfo_obj.ipaddress = strIpAddress;
                    ipinfo_obj.ipheadertype = "HTTP_X_REAL_IP";
                }
            }
            else
            {

              strIpAddress=strIpAddress.Split(',')[0];
              ipinfo_obj.ipaddress = strIpAddress;
              ipinfo_obj.ipheadertype = "HTTP_X_FORWARDED_FOR";
                
            }
            return ipinfo_obj;
        }
        public void Monitize(string Shorturl, string latitude, string longitude, string path)
        //public UserInfo Monitize(string Shorturl, string latitude, string longitude)
        {
            var request = HttpContext.Current.Request;
            //if (filter_crawl_ips(request) == false)
            //{

                string ipv4 = null; string ipv6 = null; string browser = null; string browserversion = null; string req_url = null; long ipnum = 0; int? FK_RID = 0; int Fk_UID = 0;string ismobiledevice=null;
                //uiddata uid_obj = new uiddata();
                List<uiddataobj> uid_ob_list = new List<uiddataobj>();
                uiddataobj uid_obj = new uiddataobj();
                int? FK_clientid = 0; bool hitnotify; int? pk_HookId = 0; campaignhookurl campobj = new campaignhookurl();
                ip_info ipinfo_obj = new ip_info();
                string ipheadertype;
                try
                {

                    string longurl = "";
                    string Cookievalue = "";

                    //UserInfo obj_userinfo = new UserInfo();
                    if (HttpContext.Current.Request.Cookies["VisitorCookie"] == null)
                    {
                        Random randNum = new Random();
                        int r = randNum.Next(00000, 99999);
                        Cookievalue = r.ToString("D5");
                        HttpCookie myCookie = new HttpCookie("VisitorCookie");
                        // Set the cookie value.
                        myCookie.Value = Cookievalue;
                        // Set the cookie expiration date.
                        myCookie.Expires = DateTime.Now.AddYears(1);
                        // Add the cookie.
                        HttpContext.Current.Response.Cookies.Add(myCookie);

                    }

                    try
                    {


                        uid_ob_list = (from u in dc.uiddatas
                                       where u.UniqueNumber == Shorturl
                                       select new uiddataobj()
                                       {
                                           UniqueNumber = u.UniqueNumber,
                                           FK_RID = u.FK_RID,
                                           PK_Uid = u.PK_Uid,
                                           FK_ClientID = u.FK_ClientID,
                                           MobileNumber = u.MobileNumber,
                                           LongurlorMessage = u.LongurlorMessage,
                                           Type = u.Type
                                       }).ToList();

                        if (uid_ob_list != null)
                            uid_obj = uid_ob_list.Where(x => x.UniqueNumber.ToString() == Shorturl).Select(y => y).SingleOrDefault();

                    }
                    catch (Exception ex)
                    {
                        string uiderrtrack = "issue in uiddata query fetching ===shorturl= " + Shorturl + " ";
                        ErrorLogs.LogErrorData(uiderrtrack + ex.StackTrace + ex.InnerException, ex.Message);
                    }
                    
                        if (uid_obj != null)
                        {
                            longurl = uid_obj.LongurlorMessage;
                            if (uid_obj.Type == "url")
                            {

                                if (longurl != null && !longurl.ToLower().StartsWith("http:") && !longurl.ToLower().StartsWith("https:"))
                                    HttpContext.Current.Response.Redirect("http://" + longurl);
                                else
                                    HttpContext.Current.Response.Redirect(longurl);

                            }
                            else if (uid_obj.Type == "message")
                            {

                                //System.Windows.Forms.HtmlDocument doc = webbrowser.Document.OpenNew(true);
                                //doc.Write("<HTML><BODY>This is a new HTML document.</BODY></HTML>");
                                StringWriter stringWriter = new StringWriter();
                                using (System.Web.UI.HtmlTextWriter writer = new System.Web.UI.HtmlTextWriter(stringWriter))
                                {

                                    // writer.Write("<body>");
                                    // writer.Write(longurl);
                                    // writer.Write("</body>");
                                    // string s = stringWriter.GetStringBuilder().ToString();
                                    // System.IO.File.WriteAllText(path,s);
                                    HttpContext.Current.Response.Redirect(@"../RedirectPage.aspx?surl=" + Shorturl);
                                    // HttpContext.Current.Response.Redirect("../RedirectPage.html");

                                }
                            }
                            if (!crawldetect(request))
                            {
                            Fk_UID = uid_obj.PK_Uid;
                            FK_RID = uid_obj.FK_RID;
                            FK_clientid = uid_obj.FK_ClientID;

                            //retrive ipaddress and browser
                            //string ipv4 = new ConvertionBO().GetIP4Address();

                            //for getting header value --start
                            int loop1, loop2;
                            System.Collections.Specialized.NameValueCollection coll;

                            // Load Header collection into NameValueCollection object.
                            coll = request.Headers;
                            string st = "";
                            // Put the names of all keys into a string array.
                            String[] arr1 = coll.AllKeys;
                            for (loop1 = 0; loop1 < arr1.Length; loop1++)
                            {
                                //ErrorLogs.LogErrorData("header keys : ", "Key: " + arr1[loop1] + "<br>");
                                st = st + arr1[loop1].ToString();

                                // Get all values under this key.
                                String[] arr2 = coll.GetValues(arr1[loop1]);
                                for (loop2 = 0; loop2 < arr2.Length; loop2++)
                                {
                                    //ErrorLogs.LogErrorData( "","Value " + loop2 + ": " + (arr2[loop2]) + "<br>");
                                    st = st + " : " + (arr2[loop2]) + "  ;";
                                }
                            }
                            //for getting header value --end
                            ipinfo_obj = IpAddress();
                            ipv4 = ipinfo_obj.ipaddress;
                            ipheadertype = ipinfo_obj.ipheadertype;
                            //ipv4 = IpAddress();
                            //ErrorLogs.LogErrorData("genuine,header values of " + ipv4 + " " + request.Browser.Browser, st);
                            ipv6 = (request.UserHostAddress != null) ? request.UserHostAddress : null;
                            //browser = (request.Browser.Browser!=null)?request.Browser.Browser:null;
                            //browserversion = (request.Browser.Version!=null)?request.Browser.Version:null;
                            //req_url = (request.UrlReferrer != null) ? (request.UrlReferrer.ToString()) : (request.Url.AbsoluteUri);

                            try
                            {
                                browser = request.Browser.Browser;
                            }
                            catch (Exception ex)
                            {
                                browser = null;
                            }
                            try
                            {
                                browserversion = request.Browser.Version;
                            }
                            catch (Exception ex)
                            {
                                browserversion = null;
                            }
                            try
                            {
                                req_url = (request.UrlReferrer != null) ? (request.UrlReferrer.ToString()) : (request.Url.AbsoluteUri);
                            }
                            catch (Exception ex)
                            {
                                req_url = null;
                            }
                            //string[] header_array = HttpContext.Current.Request.Headers.AllKeys;
                            string useragent = request.UserAgent;
                            string hostname = request.UserHostName;
                            //string devicetype = HttpContext.Current.Request.Browser.Platform;
                             ismobiledevice = request.Browser.IsMobileDevice.ToString();
                            if (ipv4 != "::1" && ipv4 != null && ipv4 != "")
                                ipnum = convertAddresstoNumber(ipv4);
                            if (ipnum == 0 && ipv6 != "::1" && ipv6 != null && ipv6 != "")
                                ipnum = convertAddresstoNumber(ipv6);
                            //ipnum = convertAddresstoNumber("192.168.1.64");


                            //check hit table
                            try
                            {
                                hitnotify objhit = dc.hitnotifies.Where(x => x.FK_Rid == FK_RID).Select(y => y).FirstOrDefault();
                                campobj = dc.campaignhookurls.Where(x => x.FK_Rid == FK_RID && x.FK_ClientID == FK_clientid).Select(y => y).SingleOrDefault();
                                if (campobj != null)
                                {
                                    pk_HookId = campobj.PK_HookID;
                                }
                                if (objhit != null)
                                    hitnotify = true;
                                else
                                {
                                    hitnotify = false;
                                    //pk_HookId = dc.campaignhookurls.Where(x => x.FK_Rid == FK_RID && x.FK_ClientID == FK_clientid).Select(y => y.PK_HookID).SingleOrDefault();
                                }
                            }
                            catch (Exception ex)
                            {
                                pk_HookId = 0;
                                hitnotify = false;
                            }
                            //ErrorLogs.LogErrorData("before insert "+req_url + " " + "FK_UID = " + Fk_UID, DateTime.UtcNow.ToString());
                            //new DataInsertionBO().Insertshorturldata(ipv4, ipv6, browser, browserversion, City, Region, Country, CountryCode, req_url, useragent, hostname, devicetype, ismobiledevice, Fk_UID, FK_RID, FK_clientid);
                            new DataInsertionBO().Insertshorturldata(ipv4, ipv6, ipnum, browser, browserversion, req_url, useragent, hostname, latitude, longitude, ismobiledevice, Fk_UID, FK_RID, FK_clientid, Cookievalue, uid_obj.MobileNumber, hitnotify, pk_HookId,st,ipinfo_obj.ipheadertype);
                            //ErrorLogs.LogErrorData("after insert "+req_url + " " + "FK_UID = " + Fk_UID, DateTime.UtcNow.ToString());

                            if (req_url.Contains("vyu.im"))
                            {
                                //google analytics code - start
                                Spyriadis.net.GoogleTracker ga = new Spyriadis.net.GoogleTracker("UA-155335543-1");
                                string campaignname = dc.riddatas.Where(x => x.PK_Rid == FK_RID).Select(y => y.CampaignName).SingleOrDefault();
                                ga.trackEvent("VYUClicks", "Click", "Req_url", req_url);
                                ga.trackPage("http://vyu.im", req_url, campaignname);
                                ga.campaignWiseTrackData(FK_RID.ToString(), campaignname, req_url);
                                //google analytics code - end
                            }
                            if (campobj != null)
                            {
                                if (campobj.Status == "Pause")
                                {
                                    campobj.Status = "Active";
                                    dc.SaveChanges();
                                }
                            }


                            if (HttpContext.Current.Request.Cookies["VisitorCookie"] != null)
                            {
                                string cookievalue = HttpContext.Current.Request.Cookies["VisitorCookie"].Value;
                                List<string> mobilenumbers = dc.cookietables.Where(x => x.CookieValue == cookievalue).Select(y => y.MobileNumber).ToList();
                                if (!mobilenumbers.Contains(uid_obj.MobileNumber))
                                {
                                    cookietable objc = new cookietable();
                                    objc.CookieValue = cookievalue;
                                    objc.MobileNumber = uid_obj.MobileNumber;
                                    dc.cookietables.Add(objc);
                                    dc.SaveChanges();
                                }
                            }
                                }
                    else
                    {
                        try
                        {
                            ipinfo_obj = IpAddress();
                            ipv4 = ipinfo_obj.ipaddress;
                            ipheadertype = ipinfo_obj.ipheadertype;
                            //ipv4 = IpAddress();
                            try { browser = request.Browser.Browser; }
                            catch (Exception ex) { browser = null; }
                            try { browserversion = request.Browser.Version; }
                            catch (Exception ex) { browserversion = null; }
                            try{req_url = (request.UrlReferrer != null) ? (request.UrlReferrer.ToString()) : (request.Url.AbsoluteUri);}
                            catch (Exception ex)
                            {
                                req_url = null;
                            }
                            try { ismobiledevice = request.Browser.IsMobileDevice.ToString(); }
                            catch (Exception ex) { ismobiledevice = null; }
                            //for getting header value --start
                            int loop1, loop2;
                            System.Collections.Specialized.NameValueCollection coll;

                            // Load Header collection into NameValueCollection object.
                            coll = request.Headers;
                            string st = "";
                            // Put the names of all keys into a string array.
                            String[] arr1 = coll.AllKeys;
                            for (loop1 = 0; loop1 < arr1.Length; loop1++)
                            {
                                //ErrorLogs.LogErrorData("header keys : ", "Key: " + arr1[loop1] + "<br>");
                                st = st + arr1[loop1].ToString();

                                // Get all values under this key.
                                String[] arr2 = coll.GetValues(arr1[loop1]);
                                for (loop2 = 0; loop2 < arr2.Length; loop2++)
                                {
                                    //ErrorLogs.LogErrorData( "","Value " + loop2 + ": " + (arr2[loop2]) + "<br>");
                                    st = st + " : " + (arr2[loop2]) + "  ;";
                                }
                            }
                            //ErrorLogs.LogErrorData("duplicate,header values of " + ipv4 + " " + request.Browser.Browser, st);

                            excluded_shorturl ex_obj = new excluded_shorturl();
                            ex_obj.Ipv4 = ipv4;
                            ex_obj.Browser = browser;
                            ex_obj.Browser_version = browserversion;
                            ex_obj.Req_url = req_url;
                            ex_obj.UserAgent = request.UserAgent;
                            ex_obj.IsMobileDevice =ismobiledevice ;
                            ex_obj.HeaderValues = st.ToString();
                            ex_obj.FK_Uid = uid_obj.PK_Uid;
                            ex_obj.FK_RID = uid_obj.FK_RID;
                            ex_obj.FK_ClientID = uid_obj.FK_ClientID;
                            ex_obj.CreatedDate = DateTime.UtcNow;
                            dc.excluded_shorturl.Add(ex_obj);
                            dc.SaveChanges();
                        }

                        catch (Exception ex)
                        {
                            ErrorLogs.LogErrorData("error in exclude_shortenurl data " + ex.StackTrace + ex.InnerException, ex.Message);
                        }
                    }
                  }
                        else
                        {
                            HttpContext.Current.Response.Redirect("~/404.html");

                            //return obj_userinfo;
                        }

                    
                    }
                

                catch (Exception ex)
                {
                    ErrorLogs.LogErrorData(ex.StackTrace + ex.InnerException, ex.Message);
                    if (ipv4 != null)
                    {

                        new DataInsertionBO().Insertshorturldata(ipv4, ipv6, ipnum, "", "", req_url, "", "", latitude, longitude, "", Fk_UID, FK_RID, FK_clientid, "", "", false, 0,"",ipinfo_obj.ipheadertype);
                    }
                    //return null;
                }
            }
            
        


        bool filter_crawl_ips(HttpRequest request)
        {
            string browser; string browserversion;bool iscrawl;
            try
            {
                browser = request.Browser.Browser;
            }
            catch (Exception ex)
            {
                browser = null;
            }
            try
            {
                browserversion = request.Browser.Version;
            }
            catch (Exception ex)
            {
                browserversion = null;
            }
            if (browser != "Firefox" && browserversion != "24.0")
                iscrawl = false;
            else
                iscrawl = true;
            return iscrawl;
        }

        bool crawldetect(HttpRequest request)
        {
            //bool iscrawler1 = System.Text.RegularExpressions.Regex.IsMatch(useragent, @"bot|crawler|baiduspider|80legs|ia_archiver|voyager|curl|wget|yahoo! slurp|mediapartners-google", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            //ErrorLogs.LogErrorData("iscrawler1", iscrawler1.ToString());
            string useragent = request.UserAgent;
            List<string> Crawlers3 = new List<string>()
           // "snippet",
{
   "snippet","bot","crawler","spider","80legs","baidu","yahoo! slurp","ia_archiver","mediapartners-google",
    "lwp-trivial","nederland.zoek","ahoy","anthill","appie","arale","araneo","ariadne",            
    "atn_worldwide","atomz","bjaaland","ukonline","calif","combine","cosmos","cusco",
    "cyberspyder","digger","grabber","downloadexpress","ecollector","ebiness","esculapio",
    "esther","felix ide","hamahakki","kit-fireball","fouineur","freecrawl","desertrealm",
    "gcreep","golem","griffon","gromit","gulliver","gulper","whowhere","havindex","hotwired",
    "htdig","ingrid","informant","inspectorwww","iron33","teoma","ask jeeves","jeeves",
    "image.kapsi.net","kdd-explorer","label-grabber","larbin","linkidator","linkwalker",
    "lockon","marvin","mattie","mediafox","merzscope","nec-meshexplorer","udmsearch","moget",
    "motor","muncher","muninn","muscatferret","mwdsearch","sharp-info-agent","webmechanic",
    "netscoop","newscan-online","objectssearch","orbsearch","packrat","pageboy","parasite",
    "patric","pegasus","phpdig","piltdownman","pimptrain","plumtreewebaccessor","getterrobo-plus",
    "raven","roadrunner","robbie","robocrawl","robofox","webbandit","scooter","search-au",
    "searchprocess","senrigan","shagseeker","site valet","skymob","slurp","snooper","speedy",
    "curl_image_client","suke","www.sygol.com","tach_bw","templeton","titin","topiclink","udmsearch",
    "urlck","valkyrie libwww-perl","verticrawl","victoria","webscout","voyager","crawlpaper",
    "webcatcher","t-h-u-n-d-e-r-s-t-o-n-e","webmoose","pagesinventory","webquest","webreaper",
    "webwalker","winona","occam","robi","fdse","jobo","rhcs","gazz","dwcp","yeti","fido","wlm",
    "wolp","wwwc","xget","legs","curl","webs","wget","sift","cmc"
};
            string ua = useragent.ToLower();
            bool iscrawler2 = Crawlers3.Exists(x => ua.Contains(x));
            if (iscrawler2 == false)
              iscrawler2= filter_crawl_ips(request);

            //ErrorLogs.LogErrorData("iscrawler2", iscrawler2.ToString());
            return iscrawler2;

//            // crawlers that have 'bot' in their useragent
//            List<string> Crawlers1 = new List<string>()
//{
//    "googlebot","bingbot","yandexbot","ahrefsbot","msnbot","linkedinbot","exabot","compspybot",
//    "yesupbot","paperlibot","tweetmemebot","semrushbot","gigabot","voilabot","adsbot-google",
//    "botlink","alkalinebot","araybot","undrip bot","borg-bot","boxseabot","yodaobot","admedia bot",
//    "ezooms.bot","confuzzledbot","coolbot","internet cruiser robot","yolinkbot","diibot","musobot",
//    "dragonbot","elfinbot","wikiobot","twitterbot","contextad bot","hambot","iajabot","news bot",
//    "irobot","socialradarbot","ko_yappo_robot","skimbot","psbot","rixbot","seznambot","careerbot",
//    "simbot","solbot","mail.ru_bot","spiderbot","blekkobot","bitlybot","techbot","void-bot",
//    "vwbot_k","diffbot","friendfeedbot","archive.org_bot","woriobot","crystalsemanticsbot","wepbot",
//    "spbot","tweetedtimes bot","mj12bot","who.is bot","psbot","robot","jbot","bbot","bot"
//};

//            // crawlers that don't have 'bot' in their useragent
//            List<string> Crawlers2 = new List<string>()
//{
//    "baiduspider","80legs","baidu","yahoo! slurp","ia_archiver","mediapartners-google","lwp-trivial",
//    "nederland.zoek","ahoy","anthill","appie","arale","araneo","ariadne","atn_worldwide","atomz",
//    "bjaaland","ukonline","bspider","calif","christcrawler","combine","cosmos","cusco","cyberspyder",
//    "cydralspider","digger","grabber","downloadexpress","ecollector","ebiness","esculapio","esther",
//    "fastcrawler","felix ide","hamahakki","kit-fireball","fouineur","freecrawl","desertrealm",
//    "gammaspider","gcreep","golem","griffon","gromit","gulliver","gulper","whowhere","portalbspider",
//    "havindex","hotwired","htdig","ingrid","informant","infospiders","inspectorwww","iron33",
//    "jcrawler","teoma","ask jeeves","jeeves","image.kapsi.net","kdd-explorer","label-grabber",
//    "larbin","linkidator","linkwalker","lockon","logo_gif_crawler","marvin","mattie","mediafox",
//    "merzscope","nec-meshexplorer","mindcrawler","udmsearch","moget","motor","muncher","muninn",
//    "muscatferret","mwdsearch","sharp-info-agent","webmechanic","netscoop","newscan-online",
//    "objectssearch","orbsearch","packrat","pageboy","parasite","patric","pegasus","perlcrawler",
//    "phpdig","piltdownman","pimptrain","pjspider","plumtreewebaccessor","getterrobo-plus","raven",
//    "roadrunner","robbie","robocrawl","robofox","webbandit","scooter","search-au","searchprocess",
//    "senrigan","shagseeker","site valet","skymob","slcrawler","slurp","snooper","speedy",
//    "spider_monkey","spiderline","curl_image_client","suke","www.sygol.com","tach_bw","templeton",
//    "titin","topiclink","udmsearch","urlck","valkyrie libwww-perl","verticrawl","victoria",
//    "webscout","voyager","crawlpaper","wapspider","webcatcher","t-h-u-n-d-e-r-s-t-o-n-e",
//    "webmoose","pagesinventory","webquest","webreaper","webspider","webwalker","winona","occam",
//    "robi","fdse","jobo","rhcs","gazz","dwcp","yeti","crawler","fido","wlm","wolp","wwwc","xget",
//    "legs","curl","webs","wget","sift","cmc"
//};

//            string ua1 = useragent.ToLower();
//            string match = null;

//            if (ua.Contains("bot")) match = Crawlers1.FirstOrDefault(x => ua.Contains(x));
//            else match = Crawlers2.FirstOrDefault(x => ua.Contains(x));

//            if (match != null && match.Length < 5)
//                ErrorLogs.LogErrorData("Possible new crawler found:", ua);
//                //Log("Possible new crawler found: ", ua);

//            bool iscrawler = match != null;
//            ErrorLogs.LogErrorData("iscrawler3", iscrawler.ToString());
        }

        //public string GetApiKey()
        //{
        //    string APIKey="";
        //    using (var cryptoProvider = new RNGCryptoServiceProvider())
        //    {
        //        byte[] secretKeyByteArray = new byte[32]; //256 bit
        //        cryptoProvider.GetBytes(secretKeyByteArray);
        //        APIKey = Convert.ToBase64String(secretKeyByteArray);
        //    }
        //    return APIKey;
        //}
        //public Client CheckClientEmail(string email)
        //{
        //    Client obj = new Client();
        //    obj = dc.Clients.Where(c => c.Email == email).Select(x => x).SingleOrDefault();
        //    //if (obj != null)
        //    //    check = true;
        //    //else
        //    //    check = false;
        //    return obj;

        //}
        //public bool CheckClientEmail1(string email)
        //{
        //    Client obj = new Client(); bool check = false;
        //    obj = dc.Clients.Where(c => c.Email == email).Select(x => x).SingleOrDefault();
        //    if (obj != null)
        //        check = true;
        //    //else
        //    //    check = false;
        //    return check;

        //}
        //public bool CheckClientId(int id)
        //{
        //    Client obj = new Client(); bool check = false;
        //    obj = dc.Clients.Where(c => c.PK_ClientID == id).Select(x => x).SingleOrDefault();
        //    if (obj != null)
        //        check = true;
        //    //else
        //    //    check = false;
        //    return check;
        //}
       
        //public void UpdateClient(string username,string email,bool? isactive)
        //{
        //    try
        //    {
        //        //string strQuery = "Update MMPersonMessage set Status = 'R' where FKMessageId = (" + messageid + ") and FKToPersonId = (" + personid + ")";
        //        DateTime utcdt = DateTime.UtcNow;
        //        string strQuery = "Update Client set UserName = '" + username + "' ,IsActive='" + isactive + "',UpdatedDate='" + utcdt + "' where Email ='" + email + "'";
        //        SqlHelper.ExecuteNonQuery(Helper.ConnectionString, CommandType.Text, strQuery);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //    }
        //}
       



    
    }
}