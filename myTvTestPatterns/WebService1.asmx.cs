using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using myTvTestPatterns.TvTestDiscTableAdapters;

namespace myTvTestDisc
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://www.mytvtestdisc.com/eventlog", Description = "Returns a dump of the event log")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string EventLog()
        {
            EVENT_LOGTableAdapter adptEvent = new EVENT_LOGTableAdapter();
            DataTable dt = new DataTable();
            using (adptEvent)
            {
                    dt = adptEvent.GetData();
            }

            string xml = "";

            using (StringWriter sw = new StringWriter())
            {
                dt.WriteXml(sw);
                xml = sw.ToString();
            }

            return xml;
        }
    }
}
