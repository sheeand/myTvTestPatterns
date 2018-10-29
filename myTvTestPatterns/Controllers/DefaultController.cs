using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myTvTestPatterns.UserObjects;
using System.IO;
using System.Net;
using System.Net.Mail;
using myTvTestPatterns.TvTestDiscTableAdapters;
using System.Xml;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace myTvTestPatterns.Controllers
{
    public class DefaultController : Controller
    {
        TextPool objTextPool = new TextPool();


        //
        // GET: /Default/

        public ActionResult Index()
        {

            SqlConnection objConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TVTESTDISCConnectionString"].ConnectionString);
            SqlDataReader rdr = null;
            objConnection.Open();
            SqlCommand cmd = new SqlCommand("GetDownloadCounts", objConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            rdr = cmd.ExecuteReader();
            rdr.Read();
            ViewBag.testdisc = rdr["testdisc"];
            ViewBag.color_bar_DVD = rdr["color_bar_DVD"];
            ViewBag.Bars = rdr["Bars"];
            ViewBag.Vibration = rdr["Vibration"];
            ViewBag.Subwoofer = rdr["Subwoofer"];
            ViewBag.Dancing = rdr["Dancing"];
            ViewBag.Colorized = rdr["Colorized"];
            ViewBag.Indian = rdr["Indian"];
            ViewBag.Philips = rdr["Philips"];
            ViewBag.Gray = rdr["Gray"];
            ViewBag.Flat = rdr["Flat"];
            rdr.Dispose();
            objConnection.Close();

            int goodIP = 0;
            FORBIDDEN_IPTableAdapter adptIP = new FORBIDDEN_IPTableAdapter();
            using (adptIP)
            {
                string IP = Request.UserHostAddress;
                goodIP = (int)adptIP.IsIpForbidden(IP);
            }

            if (goodIP == 1)
            {
                return View("ErrorPage");
            }
            else
            {
                return View("Index");
            }
        }


        public ActionResult Download(string p)
        {
            string strCurrentIP = Request.UserHostAddress;
            FORBIDDEN_IPTableAdapter adptIP = new FORBIDDEN_IPTableAdapter();
            string strUniqueId = Guid.NewGuid().ToString("N");

            using (adptIP)
            {
                //adptIP.AllowSingleIpConnection(strCurrentIP, strUniqueId);
                //if ((int)adptIP.TestForSingleIpConnection(strCurrentIP, strUniqueId) > 0)
                //{
                //    adptIP.BlockIP(strCurrentIP);
                ViewBag.Product = p;
                ViewBag.DownloadUrl = String.Format("http://{0}/Default/Transport?p={1}", HttpContext.Request.Url.Authority, p);
                ITEMTableAdapter objAdapter2 = new ITEMTableAdapter();
                ViewBag.DownloadInstructions = objTextPool.BasicInstructions;
                return View();
                //}
                //else
                //{
                //return View("Index");
                //}
            }

            //using (adptIP)
            //{
            //    adptIP.ReleaseIP(strCurrentIP, strUniqueId);
            //}


            //EmptyResult er = new EmptyResult();
            //return er;
        }

        //    else
        //    {
        //        return View("Index");
        //    }
        //}

        public EmptyResult GetFile(string p)
        {
            string strCurrentIP = Request.UserHostAddress;
            FORBIDDEN_IPTableAdapter adptIP = new FORBIDDEN_IPTableAdapter();
            bool bLogEntryInProgress = false;
            string strUniqueId = Guid.NewGuid().ToString("N");
            bool isBot = false;
            int isForbidden = 0;

            using (adptIP)
            {
                System.Threading.Thread.Sleep(1000);

                isForbidden = (int)adptIP.IsIpForbidden(strCurrentIP);
                if (isForbidden == 0)
                {
                    //adptIP.BlockIP(strCurrentIP);
                    ViewBag.Product = p;
                    string Filename = "";
                    switch (p)
                    {
                        case "TestPattern":
                            isBot = true;
                            break;
                        case "BarsAndToneWMV":
                            Filename = "Downloads/Prod/BarsAndTone.wmv";
                            break;
                        case "BarsAndToneMP4":
                            Filename = "Downloads/Prod/BarsAndTone.mp4";
                            break;
                        case "BarsAndToneMOV":
                            Filename = "Downloads/Prod/BarsAndTone.mov";
                            break;
                        case "VibrationSweepWMV":
                            Filename = "Downloads/Prod/VibrationSweep.wmv";
                            break;
                        case "VibrationSweepMP4":
                            Filename = "Downloads/Prod/VibrationSweep.mp4";
                            break;
                        case "VibrationSweepMOV":
                            Filename = "Downloads/Prod/VibrationSweep.mov";
                            break;
                        case "SubwooferSweepWMV":
                            Filename = "Downloads/Prod/SubwooferSweep.wmv";
                            break;
                        case "SubwooferSweepMOV":
                            Filename = "Downloads/Prod/SubwooferSweep.mov";
                            break;
                        case "SubwooferSweepMP4":
                            Filename = "Downloads/Prod/SubwooferSweep.mp4";
                            break;
                        case "DancingWhiteWindowWMV":
                            Filename = "Downloads/Prod/DancingWhiteWindow.wmv";
                            break;
                        case "DancingWhiteWindowMP4":
                            Filename = "Downloads/Prod/DancingWhiteWindow.mp4";
                            break;
                        case "DancingWhiteWindowMOV":
                            Filename = "Downloads/Prod/DancingWhiteWindow.mov";
                            break;
                        case "IndianHeadWMV":
                            Filename = "Downloads/Prod/IndianHead.wmv";
                            break;
                        case "IndianHeadMP4":
                            Filename = "Downloads/Prod/IndianHead.mp4";
                            break;
                        case "IndianHeadMOV":
                            Filename = "Downloads/Prod/IndianHead.mov";
                            break;
                        case "ColorizedGrayScaleWMV":
                            Filename = "Downloads/Prod/ColorizedGrayscale.wmv";
                            break;
                        case "ColorizedGrayScaleMP4":
                            Filename = "Downloads/Prod/ColorizedGrayscale.mp4";
                            break;
                        case "ColorizedGrayScaleMOV":
                            Filename = "Downloads/Prod/ColorizedGrayscale.mov";
                            break;
                        case "PhilipsCircleWMV":
                            Filename = "Downloads/Prod/PhilipsCircle.wmv";
                            break;
                        case "PhilipsCircleMP4":
                            Filename = "Downloads/Prod/PhilipsCircle.mp4";
                            break;
                        case "PhilipsCircleMOV":
                            Filename = "Downloads/Prod/PhilipsCircle.mov";
                            break;
                        case "GrayscaleMOV":
                            Filename = "Downloads/Prod/SplitGrayscale.mov";
                            break;
                        case "GrayscaleWMV":
                            Filename = "Downloads/Prod/SplitGrayscale.wmv";
                            break;
                        case "GrayscaleMP4":
                            Filename = "Downloads/Prod/SplitGrayscale.mp4";
                            break;
                        case "FlatFieldsMOV":
                            Filename = "Downloads/Prod/FlatFields.mov";
                            break;
                        case "FlatFieldsWMV":
                            Filename = "Downloads/Prod/FlatFields.wmv";
                            break;
                        case "FlatFieldsMP4":
                            Filename = "Downloads/Prod/FlatFields.mp4";
                            break;
                        default:
                            Filename = "Downloads/Prod/BarsAndTone.wmv";
                            break;
                    }

                    if (isBot)
                    {
                        adptIP.InsertForbiddenIp(strCurrentIP);
                    }
                    else
                    {
                        try
                        {
                            string path = Server.MapPath(Filename).Replace("\\Default", "");
                            FileInfo file = new FileInfo(path);
                            //Response.Clear();
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.Name);
                            Response.ContentType = "application/octet-stream";
                            Response.ContentEncoding = System.Text.Encoding.UTF8;
                            Response.WriteFile(file.FullName);

                            System.Threading.Thread.Sleep(2000);

                            if (bLogEntryInProgress == false)
                            {
                                bLogEntryInProgress = true;
                                RecordEvent(String.Concat("Download Complete - ", p));
                            }
                            Response.End();
                        }
                        catch (Exception ex)
                        {
                            Response.Redirect(String.Concat("ErrorPage?pg=Xport+line=77+msg=", ex.Message));
                        }
                        finally
                        {
                            Response.StatusCode = 200;
                            Response.Close();
                        }
                    }
                }
                else
                {
                    Response.Redirect("/");
                }
            }


            EmptyResult er = new EmptyResult();
            return er;
        }

        public EmptyResult Transport(string p)
        {
            string strCurrentIP = Request.UserHostAddress;
            myTvTestPatterns.TvTestDiscTableAdapters.FORBIDDEN_IPTableAdapter adptIP = new FORBIDDEN_IPTableAdapter();
            bool bLogEntryInProgress = false;
            string strUniqueId = Guid.NewGuid().ToString("N");
            int isForbidden = 0;

            using (adptIP)
            {
                System.Threading.Thread.Sleep(1000);

                isForbidden = (int)adptIP.IsIpForbidden(strCurrentIP);
                if (isForbidden == 0)
                {
                    //    adptIP.BlockIP(strCurrentIP);

                    string strDownloadFileName = "";

                    try
                    {
                        // Set download file name here
                        switch (p)
                        {
                            case "12CB50V2":
                                strDownloadFileName = "Downloads/Prod/ColorBarsAndTone50minV2.exe";
                                break;

                            case "12TD5":
                                strDownloadFileName = "Downloads/Prod/myTvTestDiscV5.exe";
                                break;

                            default:
                                break;
                        }

                        string path = Server.MapPath(strDownloadFileName).Replace("\\Default", "");
                        FileInfo file = new FileInfo(path);
                        Response.Clear();
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + file.Name);
                        Response.ContentType = "application/octet-stream";
                        Response.ContentEncoding = System.Text.Encoding.UTF8;
                        Response.WriteFile(file.FullName);
                        if (bLogEntryInProgress == false)
                        {
                            bLogEntryInProgress = true;
                            RecordEvent(String.Concat("Download Complete - ", p));
                        }

                        System.Threading.Thread.Sleep(2000);

                        Response.End();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect(String.Concat("ErrorPage?pg=Xport+line=77+msg=", ex.Message));
                    }
                    finally
                    {
                        Response.StatusCode = 200;
                        Response.Close();
                    }
                }
                else
                {
                    Response.Redirect("~");
                }
            }

            //using (adptIP)
            //{
            //    adptIP.ReleaseIP(strCurrentIP, strUniqueId);
            //}

            EmptyResult er = new EmptyResult();
            return er;

        }

        protected void RecordEvent(string strEvent)
        {
            DateTime dtNow = DateTime.UtcNow.AddHours(-5.0D);
            string strSession = Session.SessionID;
            string strClientIP = Request.UserHostAddress;
            string strEmail = "";
            myTvTestPatterns.TvTestDiscTableAdapters.EVENT_LOGTableAdapter adptEvent = new EVENT_LOGTableAdapter();
            using (adptEvent)
            {
                adptEvent.InsertEvent(dtNow, strClientIP, strSession, "Transport", strEvent, strEmail);
            }
        }

        public ActionResult ErrorPage(string pg, string line, string msg)
        {
            ViewBag.Page = pg;
            ViewBag.Line = line;
            ViewBag.Message = msg;
            return View();

        }

        public ViewResult FAQ()
        {
            return View("FAQs");
        }

        public ActionResult Test()
        {
            EVENT_LOGTableAdapter ta = new EVENT_LOGTableAdapter();
            string colorBarCount = ta.Count12CB50V2().ToString();
            string testDiscCount = ta.Count12TD5().ToString();

            Dictionary<string, string> Counts = new Dictionary<string, string>();

            Counts.Add("ColorBarDVD", colorBarCount);
            Counts.Add("myTvTestDisc", testDiscCount);

            return Json(Counts);
        }

        public ActionResult GetDownloads()
        {
            EVENT_LOGTableAdapter ta = new EVENT_LOGTableAdapter();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            String[,] data = new String[3, 3];
            String x = "";
            String jsonString = "[ ";


            try
            {
                //ds.Tables.Add(dt);
                dt = ta.GetData();
                for (int i = 0; i < 200; i++)
                {
                    x = Convert.ToDateTime(dt.Rows[i]["Timestamp"]).ToString();
                    jsonString = String.Concat(jsonString, "{ ", '"', "Timestamp", '"', ": ", '"');
                    jsonString = String.Concat(jsonString, (dt.Rows[i]["Timestamp"] == null) ? "" : x, '"', ", ");

                    x = dt.Rows[i]["Client_IP"].ToString();
                    jsonString = String.Concat(jsonString, '"', "Client_IP", '"', ": ", '"');
                    jsonString = String.Concat(jsonString, (dt.Rows[i]["Client_IP"] == null) ? "" : x, '"', ", ");

                    x = dt.Rows[i]["Event"].ToString();
                    jsonString = String.Concat(jsonString, '"', "Event", '"', ": ", '"');
                    jsonString = String.Concat(jsonString, (dt.Rows[i]["Event"] == null) ? "" : x, '"', " }, ");
                }

                jsonString = jsonString.Substring(0, jsonString.Length - 2);
                jsonString = String.Concat(jsonString, " ]");
                return Json(jsonString);
            }

            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        private bool IpIsNotForbidden()
        {
            bool forbidden = true;
            FORBIDDEN_IPTableAdapter adpt = new FORBIDDEN_IPTableAdapter();
            DataTable dt = adpt.CheckForIP(Request.UserHostAddress);
            if (dt.Rows.Count > 0) forbidden = false;
            return forbidden;
        }

        [HttpGet]
        public string GetCountry(string abbr)
        {
            System.Globalization.RegionInfo r = new System.Globalization.RegionInfo(abbr);
            string c = r.DisplayName;
            return c;
        }
    }
}
