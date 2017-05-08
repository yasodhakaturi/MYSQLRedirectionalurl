using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
using Analytics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Analytics.Controllers
{
    public class HomeController : Controller
    {
        shortenurlEntities dc = new shortenurlEntities();

        public ActionResult Index()
        {
            //    //var rnd = new Random();
            //    //string unsuffled = "0123456789ABCDEFGHIJKLMOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz-.!~*'_";
            //    //string shuffled = new string(unsuffled.OrderBy(r => rnd.Next()).ToArray());
            //    UserViewModel obj = new UserViewModel();
            //    string url = Request.Url.ToString();
            //    obj = new OperationsBO().GetViewConfigDetails(url);

            //    return View(obj);
            return View();
        }
        public ActionResult GPS()
        {
            //try 
            //{ 
            //string rid_param = ""; 
            ////int rid_shorturl = 0; int rid_cookie = 0;

            //if (Request.Url != null)
            //    rid_param = Request.Url.AbsolutePath;
            //else
            //    rid_param = Request.Path;
            //if (rid_param.Contains("/"))
            //    rid_param = rid_param.Replace("/", "");
            //if (rid_param.Contains(@"\"))
            //    rid_param = rid_param.Replace(@"\", "");
            //rid_param = rid_param.Trim();
            //UserInfo obj_userinfo = (from u in dc.uiddatas
            //                         join r in dc.riddatas on u.FK_RID equals r.PK_Rid
            //                         join c in dc.Clients on r.FK_ClientId equals c.PK_ClientID
            //                         where u.UniqueNumber == rid_param
            //                         select new UserInfo()
            //                         {
            //                             UserId = c.PK_ClientID,
            //                             UserName = c.UserName,
            //                             MobileNumber = u.MobileNumber,
            //                             CampaingName = r.CampaignName
            //                         }).SingleOrDefault();
            //if (obj_userinfo == null)
            //{
            //    HttpContext.Response.Redirect("~/404.html");
            //    UserInfo obj_userinfo1 = new UserInfo();
            //    obj_userinfo1.checkModel = "0";
            //    obj_userinfo = obj_userinfo1;
            //}
            //else
            //obj_userinfo.rid_param = rid_param;
            
            //return View(obj_userinfo);
            return View();
            //}
            //    catch (Exception ex)
            //{

            //    ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
            //    return View();
            //}
        }

        //private static readonly char[] BaseChars =
        //"0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz./,".ToCharArray();
        //private static readonly Dictionary<char, int> CharValues = BaseChars
        //           .Select((c, i) => new { Char = c, Index = i })
        //           .ToDictionary(c => c.Char, c => c.Index);
        //public static long BaseToLong(string number)
        //{
        //    char[] chrs = number.ToCharArray();
        //    int m = chrs.Length - 1;
        //    int n = BaseChars.Length, x;
        //    long result = 0;
        //    for (int i = 0; i < chrs.Length; i++)
        //    {
        //        x = CharValues[chrs[i]];
        //        result += x * (long)Math.Pow(n, m--);
        //    }
        //    return result;
        //}

        //public ActionResult Login()
        //{
        //    return View();
        //}
        //public string Validate(string uname,string password, string chkRemember)
        //{
        //    try
        //    {
        //        int loginCount=0;int checkCount=0;string contextData="";
        //        string previouspage = (string)Session["id"];
        //        if (Convert.ToBoolean(chkRemember) == true)
        //        {
        //            HttpCookie Logincookie = Request.Cookies["AnalyticsLogin"];
        //            if (Logincookie != null)
        //            {
        //                byte[] hash = Helper.GetHashKey("yasodha.bitra@gmail.com" + "Analytics");
        //                string credentials = Helper.DecryptQueryString(hash, Logincookie.Value);
        //                string[] cred = credentials.Split('~');
        //                uname = cred[0];
        //                password = cred[1];

        //            }
        //        }
        //        if (uname != null && password != null)
        //        {
        //            //string type = (string)TempData["mb"];
        //            string credentials = uname + "~" + password + "~" + chkRemember;
        //            AuthenticateBO objAuthenticateBO = new AuthenticateBO();
        //            if (objAuthenticateBO.GetAuthenticateUser(uname, password, out loginCount, out checkCount, out contextData))
        //            {
        //               // contextData = contextData + "^" + Helper.UrlRef;
        //                byte[] hash = Helper.GetHashKey("yasodha.bitra@gmail.com" + "Analytics");

        //                Session["userdata"] = contextData;
        //                Session["id"] = Helper.CurrentUserId;
        //                 if (Convert.ToBoolean(chkRemember) == true)
        //                {
        //                    HttpCookie cookie = new HttpCookie("AnalyticsLogin");
        //                    string cookievalue = Helper.Encrypt(hash, credentials);
        //                    cookie.Value = cookievalue;
        //                    cookie.Expires = DateTime.Now.AddYears(2);
        //                    Response.Cookies.Add(cookie);
        //                }
        //            }
        //        }
        //        if (previouspage == null)
        //        {
        //            if (Helper.CurrentUserRole == "Admin")
        //            return "Success~/../Admin/Admin";
        //            else
        //            return "Success~/../Analytics/Analytics";
        //        }
        //        else
        //            return "Success~/../Analytics/Analytics/" + Session["id"];
        //    }
        //        catch (Exception ex)
        //    {

        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //        return new HttpStatusCodeResult(400, ex.Message).ToString();
        //    }
        //}

        //try
        //{

        //    if (password != null)
        //    {
        //        string rid_param = "";
        //        if (Request.UrlReferrer.LocalPath != "")
        //        {
        //            //rid_param = Request.Params["rid"];
        //            rid_param = Request.UrlReferrer.LocalPath;
        //            if (rid_param.Contains("/"))
        //                rid_param = rid_param.Replace("/", "");
        //            if (rid_param.Contains(@"\"))
        //                rid_param = rid_param.Replace(@"\", "");
        //            rid_param = rid_param.Trim();
        //            long decodedvalue = new ConvertionBO().BaseToLong(rid_param);
        //            int rid_shorturl = Convert.ToInt32(decodedvalue);
        //            int? rid_value = 0;
        //            PWDDataBO obj = new OperationsBO().GetUIDriddata(rid_shorturl);
        //            if (obj != null && obj.typediff == "2")
        //            {
        //                rid_value = obj.UIDorRID;
        //                int? clientid = dc.riddatas.Where(x => x.PK_Rid == rid_value).Select(y => y.FK_ClientId).SingleOrDefault();
        //                Client clientobj = dc.Clients.Where(x => x.PK_ClientID == clientid).SingleOrDefault();
        //                string userdata = clientobj.PK_ClientID + "^" + clientobj.UserName + "^" + clientobj.Role;
        //                Session["rid"] = rid_value;
        //                if (rid_value != 0)
        //                    if (new OperationsBO().CheckPassword_riddata(rid_value, password))
        //                    {
        //                        if (Convert.ToBoolean(chkRemember) == true)
        //                        {
        //                            byte[] hash = Helper.GetHashKey("superadmin@moozup.com" + "Moozup");
        //                            string credentials = rid_value + "~" + password + "~" + chkRemember;
        //                            HttpCookie cookie = new HttpCookie("AnalyticsLogin");
        //                            string cookievalue = Helper.Encrypt(hash, credentials);
        //                            cookie.Value = cookievalue;
        //                            cookie.Expires = DateTime.Now.AddYears(1);
        //                            Response.Cookies.Add(cookie);
        //                        }
        //                        //return "Success~/../Analytics/Index?rid=" + rid_shorturl;
        //                        return "Success~/../Analytics/Analytics?rid=" + rid_shorturl;

        //                    }
        //            }
        //            //else if (obj != null && obj.TypeDiff == "1")
        //            //{
        //            //    //call monitize service here
        //            //    new OperationsBO().Monitize(rid_param);
        //            //}
        //            else
        //            {
        //                return "Failed~Wrong Password";
        //            }

        //        }
        //        return "Failed~Invalid password";

        //    }
        //    else
        //    {
        //        return "Failed~Invalid password";
        //    }
        //}
        //catch (Exception ex)
        //{

        //    ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //    return new HttpStatusCodeResult(400, ex.Message).ToString();
        //}

        //}
        public string GetCountryName(string CountryCode)
        {
            RegionInfo cultureInfo = new RegionInfo(CountryCode);
            string CountryName = cultureInfo.EnglishName;
            return CountryName;
        }

        public void MSYNC()
        
        {
            try
            {
                long? rowUpated = 0; List<List_IP> NotFoundIps = new List<List_IP>(); List<CountryCityModel> list_CountryCity = new List<CountryCityModel>();
                long? lastrow_updated_id = dc.tmp_rownum_update.Select(x => x.row_update).SingleOrDefault();
                List<List_IP> ipobj = (from s in dc.shorturldatas
                                       where s.PK_Shorturl > lastrow_updated_id
                                       select new List_IP()
                                       {
                                           ipnum = s.ip_num,
                                           ipaddress = s.Ipv4,
                                           pk_shorturl_id = s.PK_Shorturl
                                       }).ToList();
                //check if any records are there for updation
                if (ipobj.Count != 0)
                {
                    //get matched records from master_location table
                    List<locids> locids = ipobj.Where(i => dc.master_location.AsNoTracking().Any(foo => i.ipnum >= foo.startIpNum && i.ipnum <= foo.endIpNum)).Select(x => new locids() { ipnum = x.ipnum, pk_shorturl_id = x.pk_shorturl_id, localid = dc.master_location.Where(foo => x.ipnum >= foo.startIpNum && x.ipnum <= foo.endIpNum).Select(y => y.locId).FirstOrDefault(), fk_city_master_id = dc.master_location.Where(foo => x.ipnum >= foo.startIpNum && x.ipnum <= foo.endIpNum).Select(y => y.PK_MASTERID).FirstOrDefault() }).ToList();

                    if (locids.Count != 0)
                    {
                        //get records from location_data table
                         list_CountryCity = (from l in dc.locations_data

                                                                  .AsNoTracking()
                                                                  .AsEnumerable() // Continue in memory
                                                                   join i in locids on l.locId equals i.localid
                                                                   where l.locId == i.localid

                                                                   select new CountryCityModel()
                                                                   {
                                                                       ipnum = i.ipnum,
                                                                       Country = GetCountryName(l.country),
                                                                       CountryCode = l.country,
                                                                       City = l.city,
                                                                       Region = l.region,
                                                                       PostalCode = l.postalCode,
                                                                       latitude = l.latitude,
                                                                       longitude = l.longitude,
                                                                       metro_code = l.metroCode,
                                                                       fk_city_master_id = i.fk_city_master_id,
                                                                       pk_shorturl_id = i.pk_shorturl_id

                                                                   }).ToList();
                        if (list_CountryCity.Count != 0)
                        {
                         //check if any ips not found in databaase tables
                            if (list_CountryCity.Count != ipobj.Count)
                            {
                                NotFoundIps = ipobj.Where(p => !list_CountryCity.Any(p2 => p2.ipnum == p.ipnum)).ToList();
                            }
                            //foreach (CountryCityModel i in list_CountryCity)
                            //{
                            //    new DataInsertionBO().UpdateCityCountry(i);
                            //}
                            
                        }
                        else
                        {
                            NotFoundIps = ipobj;

                        }
                        if (NotFoundIps.Count != 0)
                        {
                            //get data from freegeoip service and save data for future use
                          List<CountryCityModel> list=  new DataInsertionBO().GetDataForNotFoundIPS(NotFoundIps);
                          list_CountryCity = list_CountryCity.Concat(list).ToList();
                        }
                        
                    }
                    else
                    {
                        //if no record found in master_location table
                        NotFoundIps = ipobj;

                        List<CountryCityModel> list = new DataInsertionBO().GetDataForNotFoundIPS(NotFoundIps);
                        list_CountryCity = list_CountryCity.Concat(list).ToList();

                    }
                    foreach (CountryCityModel i in list_CountryCity)
                    {
                        new DataInsertionBO().UpdateCityCountry(i);
                    }
                    List_IP lastrecord = ipobj[ipobj.Count - 1];
                    rowUpated = lastrecord.pk_shorturl_id;
                    tmp_rownum_update obj = new tmp_rownum_update();
                    obj.row_update = rowUpated;
                    new DataInsertionBO().UpdateRowid(rowUpated);
                }
            }
            catch (Exception ex)
            {

                ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);

            }
            //List<CountryCityModel> ipdata = (from m in dc.master_location
            //              join l in dc.locations_data on m.locId equals l.locId
            //              select new CountryCityModel()
            //              {
            //                  startIpNum=m.startIpNum,
            //                  endIpNum=m.endIpNum,
            //                  //Country=GetCountryName(l.country),
            //                  CountryCode=l.country,
            //                  City=l.city,
            //                  Region=l.region,
            //                  PostalCode=l.postalCode,
            //                  latitude=l.latitude,
            //                  longitude=l.longitude,
            //                  metro_code=l.metroCode,
            //                  fk_city_master_id=m.PK_MASTERID
            //                 // pk_shorturl_id=m.PK_MASTERID
            //              }).ToList();

            //var lobj = ipdata.Where(i => ipobj.Any(foo => foo.ipnum >= i.startIpNum && foo.ipnum <= i.endIpNum)).
            //                          Select(l => new CountryCityModel()
            //                          {
            //                              Country = GetCountryName(l.CountryCode),
            //                              CountryCode = l.CountryCode,
            //                              City = l.City,
            //                              Region = l.Region,
            //                              PostalCode = l.PostalCode,
            //                              latitude = l.latitude,
            //                              longitude = l.longitude,
            //                              metro_code = l.metro_code,
            //                              fk_city_master_id = l.fk_city_master_id,
            //                              pk_shorturl_id = l.pk_shorturl_id
            //                              // pk_shorturl_id=(from i in ipobj select i.pk_shorturl_id).Single()}).ToList();
            //                          }).ToList();



        }
        //public ActionResult LoginRid(string latitude, string longitude, string rid_param)
        public ActionResult LoginRid(string latitude, string longitude)
        {
            try
            {
                string rid_param = ""; int rid_shorturl = 0; int rid_cookie = 0;

                if (Request.UrlReferrer != null)
                    rid_param = Request.UrlReferrer.LocalPath;
                else
                    rid_param = Request.Path;
                if (rid_param.Contains("/"))
                    rid_param = rid_param.Replace("/", "");
                if (rid_param.Contains(@"\"))
                    rid_param = rid_param.Replace(@"\", "");
                rid_param = rid_param.Trim();
                string path = Server.MapPath("../RedirectPage.html");
               
                //call monitize service here
                new OperationsBO().Monitize(rid_param,latitude,longitude,path);
                //UserInfo obj_userinfo = new OperationsBO().Monitize(rid_param, latitude, longitude);
                return View();
            }
            catch (Exception ex)
            {

                ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
                return View();
                //return new HttpStatusCodeResult(400, ex.Message).ToString();
            }
        }

        //public string ValidateRid(string password, string chkRemember)
        //{
        //    try
        //    {

        //        if (password != null)
        //        {
        //            string rid_param = "";
        //            if (Request.UrlReferrer.LocalPath != "")
        //            {
        //                //rid_param = Request.Params["rid"];
        //                rid_param = Request.UrlReferrer.LocalPath;
        //                if (rid_param.Contains("/"))
        //                    rid_param = rid_param.Replace("/", "");
        //                if (rid_param.Contains(@"\"))
        //                    rid_param = rid_param.Replace(@"\", "");
        //                rid_param = rid_param.Trim();
        //                long decodedvalue = new ConvertionBO().BaseToLong(rid_param);
        //                int rid_shorturl = Convert.ToInt32(decodedvalue);
        //                int? rid_value = 0;
        //                PWDDataBO obj = new OperationsBO().GetUIDriddata(rid_shorturl);
        //                if (obj != null && obj.typediff == "2")
        //                {
        //                    rid_value = obj.UIDorRID;
        //                    int? clientid = dc.riddatas.Where(x => x.PK_Rid == rid_value).Select(y => y.FK_ClientId).SingleOrDefault();
        //                    Client clientobj = dc.Clients.Where(x => x.PK_ClientID == clientid).SingleOrDefault();
        //                    string userdata = clientobj.PK_ClientID + "^" + clientobj.UserName + "^" + clientobj.Role;
        //                    Session["rid"] = rid_value;
        //                    if (rid_value != 0)
        //                        if (new OperationsBO().CheckPassword_riddata(rid_value, password))
        //                        {
        //                            if (Convert.ToBoolean(chkRemember) == true)
        //                            {
        //                                byte[] hash = Helper.GetHashKey("superadmin@moozup.com" + "Moozup");
        //                                string credentials = rid_value + "~" + password+"~"+chkRemember;
        //                                HttpCookie cookie = new HttpCookie("AnalyticsLogin");
        //                                string cookievalue = Helper.Encrypt(hash, credentials);
        //                                cookie.Value = cookievalue;
        //                                cookie.Expires = DateTime.Now.AddYears(1);
        //                                Response.Cookies.Add(cookie);
        //                            }
        //                            //return "Success~/../Analytics/Index?rid=" + rid_shorturl;
        //                            return "Success~/../Analytics/Analytics?rid=" + rid_shorturl;

        //                        }
        //                }
        //                //else if (obj != null && obj.TypeDiff == "1")
        //                //{
        //                //    //call monitize service here
        //                //    new OperationsBO().Monitize(rid_param);
        //                //}
        //                else
        //                {
        //                    return "Failed~Wrong Password";
        //                }

        //            }
        //            return "Failed~Invalid password";

        //        }
        //        else
        //        {
        //            return "Failed~Invalid password";
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
        //        return new HttpStatusCodeResult(400, ex.Message).ToString();
        //    }

        //}
    }
}