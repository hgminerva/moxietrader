using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace moxietrader.Controllers
{
    public class ApiTradierController : ApiController
    {
        private Data.MagentaTradersDBDataContext db = new Data.MagentaTradersDBDataContext();
        
        // Logs user tradier access
        private void logAccess(string log)
        {
            try
            {
                Data.SysAcessLog NewAccessLog = new Data.SysAcessLog();

                string currentUserName = User.Identity.Name;

                NewAccessLog.UserId = (from d in db.MstUsers where d.UserName.Equals(currentUserName) select d).FirstOrDefault().Id;
                NewAccessLog.LogDateTime = DateTime.Now;
                NewAccessLog.Log = log;

                db.SysAcessLogs.InsertOnSubmit(NewAccessLog);
                db.SubmitChanges();
            }
            catch { }
        }

        // GET api/tradierAccessToken/pjytfG9a
        [Authorize]
        [Route("api/tradierAccessToken/{code}")]
        public Models.TradierAccessToken GetTradierAccessToken(string code)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.tradier.com/v1/oauth/accesstoken");
            byte[] bytedata = Encoding.UTF8.GetBytes("grant_type=authorization_code&code=" + code);
            string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes("pUHZDBJyOEgoeX9W7cxnpQR35MBk4YbY:OC2kubo03Uwyyn2c"));

            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "*/*";
            httpWebRequest.Headers.Add("Authorization", "Basic " + authInfo);
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = bytedata.Length;

            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(bytedata, 0, bytedata.Length);
            requestStream.Close();

            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Models.TradierAccessToken t = (Models.TradierAccessToken)js.Deserialize(result, typeof(Models.TradierAccessToken));

                    logAccess("Tradier Access Token");

                    return t;
                }
            }
            catch
            {
                return new Models.TradierAccessToken();
            }
        }

        // GET api/tradierTimeSales/aapl/098f6bcd4621d373cade4e832627b4f6
        [Authorize]
        [Route("api/tradierTimeSales/{symbol}/{token}")]
        public Models.TradierTimeSalesSeries GetTradierTimeSales(string symbol, string token)
        {
            string start = DateTime.Now.AddDays(-38).ToString("yyyy-MM-dd HH:mm");
            string end = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.tradier.com/v1/markets/timesales?symbol=" + symbol + "&interval=15min&start=" + start + "&end=" + end);

            httpWebRequest.Method = "GET";
            httpWebRequest.Accept = "application/json";

            httpWebRequest.Headers.Add("Authorization", "Bearer " + token);
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Models.TradierTimeSalesSeries q = (Models.TradierTimeSalesSeries)js.Deserialize(result, typeof(Models.TradierTimeSalesSeries));
                    return q;
                }
            }
            catch
            {
                return new Models.TradierTimeSalesSeries();
            }
        }
    }
}
