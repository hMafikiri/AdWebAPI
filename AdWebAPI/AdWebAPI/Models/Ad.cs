//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ad
    {
        //public int idAd { get; set; }
        public int? Year { get; set; }
        public string Market { get; set; }
        public string Segment { get; set; }
        public string Brand { get; set; }
        public int? Copy_Duration { get; set; }
        public string Copy_Name { get; set; }
        public int Score_1 { get; set; }
        public int Score_2 { get; set; }
    }
}
