using Analytics.Helpers.BO;
using Analytics.Helpers.Utility;
using Analytics.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Caching;
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


        //public ActionResult LoginRid(string latitude, string longitude, string rid_param)
        //public void LoginRid(string latitude, string longitude)
       // [PreventSpam(DelayRequest=1)]
        //public ActionResult LoginRid()
        public void LoginRid ()   
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
                //string path = Server.MapPath("../RedirectPage.html");
                string path = Server.MapPath("~/RedirectPage.aspx" );

                //ErrorLogs.LogErrorData(" Starting point ... before monitize", DateTime.UtcNow.ToString());

                //call monitize service here
                new OperationsBO().Monitize(rid_param,"","",path);
                //UserInfo obj_userinfo = new OperationsBO().Monitize(rid_param, latitude, longitude);
                //return View();
            }
            catch (Exception ex)
            {

                ErrorLogs.LogErrorData(ex.StackTrace+" " +ex.InnerException, ex.Message);
                //return View();
                //return new HttpStatusCodeResult(400, ex.Message).ToString();
            }
        }


    //public class PreventSpamAttribute : ActionFilterAttribute
    //{
    //    // This stores the time between Requests (in seconds)
    //    public int DelayRequest = 10;
    //    // The Error Message that will be displayed in case of 
    //    // excessive Requests
    //    public string ErrorMessage = "Excessive Request Attempts Detected.";
    //    // This will store the URL to Redirect errors to
    //    public string RedirectURL;

    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //        base.OnActionExecuting(filterContext);
    //    }
    //}
    //protected override void OnActionExecuting(ActionExecutingContext filterContext)
    //{
    //    try
    //    {
    //        int DelayRequest = 10;
    //        // Store our HttpContext (for easier reference and code brevity)
    //        var request = filterContext.HttpContext.Request;
    //        // Store our HttpContext.Cache (for easier reference and code brevity)
    //        var cache = filterContext.HttpContext.Cache;

    //        // Grab the IP Address from the originating Request (example)
    //        var originationInfo = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;

    //        // Append the User Agent
    //        originationInfo += request.UserAgent;

    //        // Now we just need the target URL Information
    //        var targetInfo = request.RawUrl + request.QueryString;

    //        // Generate a hash for your strings (appends each of the bytes of
    //        // the value into a single hashed string
    //        var hashValue = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(originationInfo + targetInfo)).Select(s => s.ToString("x2")));

    //        // Checks if the hashed value is contained in the Cache (indicating a repeat request)
    //        if (cache[hashValue] != null)
    //        {
    //            // Adds the Error Message to the Model and Redirect
    //            //filterContext.Controller.ViewData.ModelState.AddModelError("ExcessiveRequests", ErrorMessage);
    //            ErrorLogs.LogErrorData("ExcessiveRequests found --" + targetInfo, "useragent --" + originationInfo);
    //        }
    //        else
    //        {
    //            // Adds an empty object to the cache using the hashValue
    //            // to a key (This sets the expiration that will determine
    //            // if the Request is valid or not)
    //              cache.Add(hashValue, null, null, DateTime.Now.AddSeconds(DelayRequest), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);
    //            //cache.Add(hashValue, DateTime.Now.AddSeconds(DelayRequest),null, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

    //            //cache.Add(hashValue, null, null, DateTime.Now.AddSeconds(DelayRequest), Cache.NoAbsoluteExpiration,CacheItemPriority.Default, null);
    //        }
    //        OnActionExecuting(filterContext);
    //    }
    //    catch (Exception ex)
    //    {
    //        ErrorLogs.LogErrorData(ex.StackTrace, ex.Message);
    //        //return null;
    //    }
    //}



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
    //                                string credentials = rid_value + "~" + password + "~" + chkRemember;
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