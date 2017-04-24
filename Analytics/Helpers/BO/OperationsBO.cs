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
            string[] ipaddressstr;
            ipaddressstr = ipaddress.Split('.');
            long o1 = Convert.ToInt64(ipaddressstr[0]);
            long o2 = Convert.ToInt64(ipaddressstr[1]);
            long o3 = Convert.ToInt64(ipaddressstr[2]);
            long o4 = Convert.ToInt64(ipaddressstr[3]);

            long ip = (16777216 * o1) + (65536 * o2) + (256 * o3) + o4;
            //string ipstr = ip.ToString();
            //int ipstr = Convert.ToInt32(ip);
            return ip;
            //long longAddress = BitConverter.ToInt64(IPAddress.Parse(ipaddress).GetAddressBytes(), 0);
            //string ipAddress = new IPAddress(BitConverter.GetBytes(intAddress)).ToString();
            //return longAddress.ToString();
        }
        public string IpAddress()
        {
            string strIpAddress;
            strIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null)
            {
                strIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            return strIpAddress;
        }
        public void Monitize(string Shorturl, string latitude, string longitude)
        //public UserInfo Monitize(string Shorturl, string latitude, string longitude)
        {
            try

            {
               
                string longurl = ""; long ipnum = 0;
                //long decodedvalue = new ConvertionBO().BaseToLong(Shorturl);
                //int Uniqueid_shorturldata = Convert.ToInt32(decodedvalue);
                int Fk_UID = 0; string Cookievalue = "";
                uiddata uid_obj = new uiddata();
                UserInfo obj_userinfo = new UserInfo();
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
                //uid_obj = new OperationsBO().CheckUniqueid(Shorturl);
               
                uid_obj = (from u in dc.uiddatas
                           .AsNoTracking()
                           .AsEnumerable()
                           join r in dc.riddatas on u.FK_RID equals r.PK_Rid
                           where u.UniqueNumber.Contains(Shorturl)
                           select u).SingleOrDefault();
                //if (new OperationsBO().CheckUniqueid(Shorturl))
                if (uid_obj != null)
                {
                    longurl = uid_obj.Longurl;
                    if (longurl != null && !longurl.ToLower().StartsWith("http:") && !longurl.ToLower().StartsWith("https:"))
                        HttpContext.Current.Response.Redirect("http://" + longurl);
                    else
                        HttpContext.Current.Response.Redirect(longurl);
                    Fk_UID = uid_obj.PK_Uid;
                    //int? FK_RID = (from u in dc.uiddatas
                    //               where u.PK_Uid == Fk_UID
                    //               select u.FK_RID).SingleOrDefault();
                    //riddata objr = (from r in dc.riddatas
                    //                    where r.PK_Rid == FK_RID
                    //                    select r).SingleOrDefault();
                    //int? FK_clientid = objr.FK_ClientId;

                    int? FK_RID = uid_obj.FK_RID;
                    int? FK_clientid = uid_obj.FK_ClientID;

                    //retrive ipaddress and browser
                    //string ipv4 = new ConvertionBO().GetIP4Address();
                    var request = HttpContext.Current.Request;
                    string ipv4 = IpAddress();
                    string ipv6 = request.UserHostAddress;
                    string browser = request.Browser.Browser;
                    string browserversion = request.Browser.Version;
                    string req_url = request.UrlReferrer.ToString();
                    //string[] header_array = HttpContext.Current.Request.Headers.AllKeys;
                    string useragent = request.UserAgent;
                    string hostname = request.UserHostName;
                    //string devicetype = HttpContext.Current.Request.Browser.Platform;
                    string ismobiledevice = request.Browser.IsMobileDevice.ToString();
                    if(ipv4!="::1" && ipv4!=null&&ipv4!="")
                     ipnum = convertAddresstoNumber(ipv4);

                    //ipnum = convertAddresstoNumber("192.168.1.64");


                    
                    //new DataInsertionBO().Insertshorturldata(ipv4, ipv6, browser, browserversion, City, Region, Country, CountryCode, req_url, useragent, hostname, devicetype, ismobiledevice, Fk_UID, FK_RID, FK_clientid);
                    new DataInsertionBO().Insertshorturldata(ipv4, ipv6, ipnum,browser, browserversion, req_url, useragent, hostname, latitude,longitude, ismobiledevice, Fk_UID, FK_RID, FK_clientid,Cookievalue,uid_obj.MobileNumber);
                    //obj_userinfo.UserId = uid_obj.FK_ClientID;
                    //obj_userinfo.UserName = dc.Clients.Where(c => c.PK_ClientID == uid_obj.FK_ClientID).Select(x => x.UserName).SingleOrDefault();
                    //obj_userinfo.MobileNumber = uid_obj.MobileNumber;
                    //obj_userinfo.CampaingName = objr.CampaignName;
                    //return obj_userinfo;
                    
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
                    HttpContext.Current.Response.Redirect("../404.html");
                            
                    //return obj_userinfo;
                }
                //WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Redirect;
                //if (!longurl.StartsWith("http://") && !longurl.StartsWith("https://"))
                //    WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", "http://" + longurl);
                //else
                //    WebOperationContext.Current.OutgoingResponse.Headers.Add("Location", longurl);
                
                //if (longurl != null && !longurl.StartsWith("http://") && !longurl.StartsWith("https://"))
                //    HttpContext.Current.Response.Redirect("http://" + longurl);
                //else
                //    HttpContext.Current.Response.Redirect(longurl);


            }
            catch (Exception ex)
            {
                ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
                
                //return null;
            }
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
        //public void InsertUIDriddata(string referencenumber)
        //{
        //    try
        //    {
        //    int rid = dc.riddatas.Where(r => r.ReferenceNumber == referencenumber).Select(x => x.PK_Rid).SingleOrDefault();
        //    lSQLConn = new MySqlConnection(connStr);
        //    SqlDataReader myReader;
        //    lSQLConn.Open();
        //    lSQLCmd.CommandType = CommandType.StoredProcedure;
        //    lSQLCmd.CommandText = "InsertintoUIDRID";
        //    //lSQLCmd.Parameters.Add(new MySqlParameter("@Fk_Uniqueid", Uniqueid_shorturldata));
        //    lSQLCmd.Parameters.Add(new MySqlParameter("@typediff", "2"));
        //    lSQLCmd.Parameters.Add(new MySqlParameter("@uidorrid", rid));
        //    lSQLCmd.Connection = lSQLConn;
        //    myReader = lSQLCmd.ExecuteReader();
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //    }
        //}


        //public bool CheckReferenceNumber(string referencenumber)
        //{
        //    riddata obj = new riddata(); bool check = false;
        //    obj = dc.riddatas.Where(c => c.ReferenceNumber == referencenumber).Select(x => x).SingleOrDefault();
        //    if (obj != null)
        //        check = true;
        //    //else
        //    //    check = false;
        //    return check;

        //}
        //public riddata CheckReferenceNumber1(string referencenumber)
        //{
        //    riddata obj = new riddata(); bool check = false;
        //    obj = dc.riddatas.Where(c => c.ReferenceNumber == referencenumber).Select(x => x).SingleOrDefault();
        //    if (obj != null)
        //        return obj;
        //        //else
        //    //    check = false;
        //    return obj;

        //}

        //public void UpdateCampaign(string referencenumber, string password, bool? isactive)
        //{
        //    try
        //    {
        //        string strQuery="";
        //        if(password!="")
        //         strQuery = "Update riddata set Pwd=" + password + ",IsActive=" + isactive + " where ReferenceNumber =" + referencenumber + "";
        //        else
        //         strQuery = "Update riddata set IsActive=" + isactive + " where ReferenceNumber =" + referencenumber + "";
        //        SqlHelper.ExecuteNonQuery(Helper.ConnectionString, CommandType.Text, strQuery);
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //    }
        //}

        //public CountsData GetCountsData(SqlDataReader myReader,string filterBy,string DateFrom,string DateTo)
        //{

        //    CountsData countobj = new CountsData();
        //    if (filterBy != "" && DateFrom == "" && DateTo == "")
        //    {
        //        if (filterBy == "Year")
        //        {
        //            List<YearData> YearsDataObj = ((IObjectContextAdapter)dc)
        //                                .ObjectContext
        //                                .Translate<YearData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();
        //            //countobj.YearsData = YearsDataObj;
                   
        //        }
        //        if (filterBy == "Month")
        //        {
        //            List<MonthData> MonthDataObj = ((IObjectContextAdapter)dc)
        //                                .ObjectContext
        //                                .Translate<MonthData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();
        //            //countobj.MonthsData = MonthDataObj;
        //        }
        //        if (filterBy == "CurrentMonth")
        //        {
        //            List<CurrentMonthData> CurrentMonthDataObj = ((IObjectContextAdapter)dc)
        //             .ObjectContext
        //             .Translate<CurrentMonthData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //            //countobj.CurrentMonthData = CurrentMonthDataObj;
        //        }
        //        if (filterBy == "Today")
        //        {
        //            List<TodayData> TodayDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<TodayData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();
        //            //countobj.TodaysData = TodayDataObj;
        //        }
        //    }

        //    else if (filterBy == "" && DateFrom == "" && DateTo == "")
        //    {
        //        List<YearData> YearsDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<YearData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();


        //        // Move to Month result 
        //        myReader.NextResult();
        //        List<MonthData> MonthDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<MonthData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to CurrentMonth result 
        //        myReader.NextResult();
        //        List<CurrentMonthData> CurrentMonthDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<CurrentMonthData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to TodayData result 
        //        myReader.NextResult();
        //        List<TodayData> TodayDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<TodayData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to YesterDayData result 
        //        myReader.NextResult();
        //        List<YesterDayData> YesterDayDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<YesterDayData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to Last7DaysData result 
        //        myReader.NextResult();
        //        List<Last7DaysData> Last7DaysDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<Last7DaysData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to BrowsersData result 
        //        myReader.NextResult();
        //        List<BrowsersData> BrowsersDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<BrowsersData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to CountryData result 
        //        myReader.NextResult();
        //        List<CountryData> CountryDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<CountryData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to CityData result 
        //        myReader.NextResult();
        //        List<CityData> CityDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<CityData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to RegionData result 
        //        myReader.NextResult();
        //        List<RegionData> RegionDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<RegionData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();

        //        // Move to DeviceTypeData result 
        //        myReader.NextResult();
        //        List<DeviceTypeData> DeviceTypeDataObj = ((IObjectContextAdapter)dc)
        //            .ObjectContext
        //            .Translate<DeviceTypeData>(myReader, "shorturldatas", MergeOption.AppendOnly).ToList();


        //        //countobj.YearsData = YearsDataObj;
        //        //countobj.MonthsData = MonthDataObj;
        //        //countobj.CurrentMonthData = CurrentMonthDataObj;
        //        //countobj.TodaysData = TodayDataObj;
        //        //countobj.YesterdaysData = YesterDayDataObj;
        //        //countobj.Last7DaysData = Last7DaysDataObj;
        //        //countobj.BrowsersData = BrowsersDataObj;
        //        //countobj.CountriesData = CountryDataObj;
        //        //countobj.CitiesData = CityDataObj;
        //        //countobj.RegionsData = RegionDataObj;
        //        //countobj.DevicesData = DeviceTypeDataObj;
        //    }
        //    return countobj;
        //}

    
    }
}