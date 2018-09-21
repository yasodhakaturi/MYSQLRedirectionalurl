using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Analytics
{
    public partial class RedirectPage : System.Web.UI.Page
    {
        shortenurlEntities dc = new shortenurlEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

            string Shorturl = Request.QueryString["surl"];
            //shorturl = Request.QueryString["surl"];
            if (Shorturl != null)
            {
                uiddata uid_obj = (from u in dc.uiddatas
                               .AsNoTracking()
                               .AsEnumerable()
                                   join r in dc.riddatas on u.FK_RID equals r.PK_Rid
                                   //where u.UniqueNumber.Contains(Shorturl.Trim())
                                   where u.UniqueNumber == Shorturl
                                   select u).SingleOrDefault();
                //if (new OperationsBO().CheckUniqueid(Shorturl))
                if (uid_obj != null)
                {
                    longMessage = uid_obj.LongurlorMessage;
                    shorturlid = uid_obj.PK_Uid;
                    host = System.Configuration.ConfigurationManager.AppSettings["LinkTrackUrl"].ToString();

                }
            }
            else
            {
                string id1 = Request.QueryString["shorturlid"];
                string url = Request.QueryString["linktagref"];
                int id = Convert.ToInt32(id1);
                messagelink objmsg = new messagelink();
                objmsg.ShortUrlId = id;
                objmsg.LinkTag = url;
                objmsg.CreatedDate = DateTime.UtcNow;
                dc.messagelinks.Add(objmsg);
                dc.SaveChanges();
                Response.Redirect(url);
            }
        }
        protected string longMessage { get; set; }
        protected int shorturlid { get; set; }
        protected string host { get; set; }

    }
    }
