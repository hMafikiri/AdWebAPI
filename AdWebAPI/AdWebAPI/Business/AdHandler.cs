using AdWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdWebAPI.Business
{
    public class AdHandler
    {
        public Ad maxAd()
        {
            using (AdModel context = new AdModel())
            {
                //retrieve ad with the highest scores
                Ad adMax = context.Ads.OrderByDescending(adS1 => adS1.Score_1).ThenByDescending(adS2 => adS2.Score_2).FirstOrDefault();

                if (adMax != null)
                {
                    return adMax;
                }
                return null;
            }
        }
        public Ad maxScore1()
        {
            using (AdModel context = new AdModel())
            {
                //get the max score 
                int highestScore1 = context.Ads.Max(ad => ad.Score_1);
                //retrieve the ad with the highest score 1
                // adMax = context.Ads.OrderByDescending(adS1 => adS1.Score_1).FirstOrDefault();
                var adMax = context.Ads.Where(ad => ad.Score_1 == highestScore1).FirstOrDefault();
                Ad maxScore1 = new Ad()
                {
                    idAd = adMax.idAd,
                    Year = adMax.Year,
                    Market = adMax.Market,
                    Segment = adMax.Segment,
                    Brand = adMax.Brand,
                    Copy_Duration = adMax.Copy_Duration,
                    Copy_Name = adMax.Copy_Name,
                    Score_1 = adMax.Score_1,
                    Score_2 = adMax.Score_2
                };
                return maxScore1;               
            }            
        }

        public Ad maxScore2()
        {
            using (AdModel context = new AdModel())
            {
                //get the max score 
                int highestScore2 = context.Ads.Max(ad => ad.Score_2);
                //retrieve the ad with the highest score 2 
                // adMax = context.Ads.OrderByDescending(ad => ad.Score_2).FirstOrDefault();
                var adMax = context.Ads.Where(ad => ad.Score_2 == highestScore2).FirstOrDefault();
                Ad maxScore2 = new Ad()
                {
                    idAd = adMax.idAd,
                    Year = adMax.Year,
                    Segment = adMax.Segment,
                    Market = adMax.Market,
                    Brand = adMax.Brand,
                    Copy_Duration = adMax.Copy_Duration,
                    Copy_Name = adMax.Copy_Name,
                    Score_1 = adMax.Score_1,
                    Score_2 = adMax.Score_2
                };
                return maxScore2;
            }
        }

        public void storeListInDb(List<Ad> list)
        {
            //adding of the ads in the database
            using (AdModel context = new AdModel())
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