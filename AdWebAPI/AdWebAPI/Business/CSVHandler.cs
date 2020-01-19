using AdWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AdWebAPI.Business
{
    public class CSVHandler
    {    
        public void storeCSV(HttpPostedFileBase csvFile,List<Ad> list)
        {
            string path = null;
            var fileName = Path.GetFileName(csvFile.FileName);
            path = AppDomain.CurrentDomain.BaseDirectory + fileName;
            csvFile.SaveAs(path);
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
                //skip irrelevant data
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
                    Score_2 = Int32.Parse(ligne[7].Replace('%', ' '))
                };
                list.Add(a);
                s = sr.ReadLine();
            }
            //close the file
            sr.Close(); fs.Close();
            //adding of the ads in the database
            using (var context = new AdModel())
            {
                foreach (Ad ad in list)
                {
                    context.Ads.Add(ad);
                }
                context.SaveChanges();
            }
        }
    }
}