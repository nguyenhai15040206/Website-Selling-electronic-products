using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class TinTucController : Controller
    {
        //
        // GET: /TinTuc/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult loadTinTucAPI()
        {
            string path = "https://newsapi.org/v2/everything?q=apple&from=2021-05-11&to=2021-05-11&sortBy=popularity&apiKey=5a08d9ea2e974a28a871dec572ae6452";
            object tinTuc= getData(path);
            JObject jObject = JObject.Parse(tinTuc.ToString());
            ViewBag.data = jObject["articles"];
            return View();
        }

        public object getData(string path)
        {
            using (WebClient webClient = new WebClient())
            {
                return JsonConvert.DeserializeObject<object>(
                        webClient.DownloadString(path)
                    ); ;
            }    
        }


    }
}
