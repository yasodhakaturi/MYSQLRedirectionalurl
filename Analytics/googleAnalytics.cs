using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace Spyriadis.net
{
    public class GoogleTracker
    {
        private string googleURL = "http://www.google-analytics.com/collect";
        private string googleVersion = "1";
        private string googleTrackingID = "UA-155335543-1";
        private string googleClientID = "812325874134-etbp8dtk8avq134g2349cjsqlug3hl4g.apps.googleusercontent.com";

        public GoogleTracker(string trackingID)
        {
            this.googleTrackingID = trackingID;
        }

        public void trackEvent(string category, string action, string label, string value)
        {
            Hashtable ht = baseValues();

            ht.Add("t", "event");                   // Event hit type
            ht.Add("ec", category);                 // Event Category. Required.
            ht.Add("ea", action);                   // Event Action. Required.
            if (label != null) ht.Add("el", label); // Event label.
            if (value != null) ht.Add("ev", value); // Event value.

            postData(ht);
        }
        public void trackPage(string hostname, string page, string title)
        {
            Hashtable ht = baseValues();

            ht.Add("t", "pageview");                // Pageview hit type.
            ht.Add("dh", hostname);                 // Document hostname.
            ht.Add("dp", page);                     // Page.
            ht.Add("dt", title);                    // Title.

            postData(ht);
        }
        public void campaignWiseTrackData(string id, string name, string req_url)
        {
            Hashtable ht = baseValues();

            ht.Add("t", "Click");              // Item hit type.
            ht.Add("ti", id);                 // transaction ID.            Required.
            ht.Add("in", name);               // Item name.                 Required.
            ht.Add("ip", req_url);              // Item price.


            postData(ht);
        }
        public void trackException(string description, bool fatal)
        {
            Hashtable ht = baseValues();

            ht.Add("t", "exception");             // Exception hit type.
            ht.Add("dh", description);            // Exception description.         Required.
            ht.Add("dp", fatal ? "1" : "0");      // Exception is fatal?            Required.

            postData(ht);
        }

        private Hashtable baseValues()
        {
            Hashtable ht = new Hashtable();
            ht.Add("v", googleVersion);         // Version.
            ht.Add("tid", googleTrackingID);    // Tracking ID / Web property / Property ID.
            ht.Add("cid", googleClientID);      // Anonymous Client ID.
            return ht;
        }
        private bool postData(Hashtable values)
        {
            string data = "";
            foreach (var key in values.Keys)
            {
                if (data != "") data += "&";
                if (values[key] != null) data += key.ToString() + "=" + HttpUtility.UrlEncode(values[key].ToString());
            }

            using (var client = new WebClient())
            {
                var result = client.UploadString(googleURL, "POST", data);
            }

            return true;
        }
    }
}