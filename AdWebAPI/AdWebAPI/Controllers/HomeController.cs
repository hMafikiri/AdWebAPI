using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdWebAPI.Business;
using AdWebAPI.Models;
using CsvHelper;

namespace AdWebAPI.Controllers
{
    public class HomeController : Controller
    {
        CSVHandler csvHandler = new CSVHandler();
        AdHandler adHandler = new AdHandler();


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            List<Ad> relevantAds = new List<Ad>();
            try
            {
                if (file.ContentLength > 0)
                {
                    csvHandler.storeCSV(file, relevantAds);                    
                }
            }
            catch(Exception e)
            {                
                ViewData["error"] = "Upload failed";
            }
            if (relevantAds.Count > 0)
            {
                adHandler.storeListInDb(relevantAds);
            }
            return View(relevantAds);
        }
        
        public ActionResult About()
        {
            List<Ad> bestAds = new List<Ad>();
            ViewBag.Message1 = "The best ad based on score 1";
            ViewBag.Message2 = "The best ad based on score 2";
            bestAds.Add(adHandler.maxScore1());
            bestAds.Add(adHandler.maxScore2());
            bestAds.Add(adHandler.maxAd());

            return View(bestAds);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}