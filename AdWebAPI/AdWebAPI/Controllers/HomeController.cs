using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdWebAPI.Models;
using CsvHelper;

namespace AdWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string path = null;
            List<Ad> relevantAds = new List<Ad>();
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    path = AppDomain.CurrentDomain.BaseDirectory+ fileName;
                    file.SaveAs(path);
                    FileStream fs = new FileStream(path, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    //ignore first line concerns headers
                    string headers = sr.ReadLine();
                    //store each line
                    string s = sr.ReadLine();
                    //if not at the end of file
                    while (s != null)
                    {
                        string[] ligne = s.Split(';');
                        //pass irrelevant data
                        while (String.IsNullOrWhiteSpace(ligne[6]) && String.IsNullOrWhiteSpace(ligne[7]))
                        {
                            s = sr.ReadLine();
                            ligne = s.Split(';');
                        }
                        if (String.IsNullOrWhiteSpace(ligne[6]))
                        {
                            ligne[6] = "0";
                        }
                        if (String.IsNullOrWhiteSpace(ligne[7]))
                        {
                            ligne[7] = "0";
                        }
                        //create a relevant ad
                        Ad a = new Ad()
                        {
                            Year = Int32.Parse(ligne[0]),
                            Market = ligne[1],
                            Segment = ligne[2],
                            Brand = ligne[3],
                            Copy_Duration = Int32.Parse(ligne[4]),
                            Copy_Name = ligne[5],
                            Score_1 = Int32.Parse(ligne[6]),
                            Score_2 = Int32.Parse(ligne[7].Replace('%',' '))
                        };
                        relevantAds.Add(a);
                        s = sr.ReadLine();
                    }
                    sr.Close(); fs.Close();

                    /*var csv = new CsvReader(new StreamReader(path), System.Globalization.CultureInfo.CurrentCulture);
                    var adsList = csv.GetRecords<AdToTest>();

                    foreach (var a in adsList)
                    {
                        if (a.Year.Equals("N/A") || String.IsNullOrWhiteSpace(a.Year))
                        {
                            continue;
                        }
                        Ad ad = new Ad()
                        {
                            Year = Int32.Parse(a.Year),
                            Market = a.Market,
                            Segment = a.Segment,
                            Brand = a.Brand,
                            Copy_Duration = a.Copy_Duration,
                            Copy_Name = a.Copy_Name,
                            Score_1  = a.Score_1,
                            Score_2 = a.Score_2                            
                        };
                        adsDisplayed.Add(ad);
                    }*/
                }
                
            }
            catch(Exception e)
            {
                
                ViewData["error"] = "Upload failed";
            }
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}