namespace AdWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ad
    {
        [Key]
        public int idAd { get; set; }

        public int? Year { get; set; }

        [Required]
        [StringLength(50)]
        public string Market { get; set; }

        [Required]
        [StringLength(50)]
        public string Segment { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        public int Copy_Duration { get; set; }

        [Required]
        [StringLength(50)]
        public string Copy_Name { get; set; }

        public int Score_1 { get; set; }

        public int Score_2 { get; set; }
    }
}
