using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdWebAPI.Models
{
    public class AdToTest
    {
        public string Year { get; set; }
        public string Market { get; set; }
        public string Segment { get; set; }
        public string Brand { get; set; }
        public int? Copy_Duration { get; set; }
        public string Copy_Name { get; set; }
        public int Score_1 { get; set; }
        public int Score_2 { get; set; }
    }
}