using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ComboSimulator.Shared.Models
{
    public class Chase
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string Attribute1 { get; set; }
        [MaxLength(10)]
        public string Attribute2 { get; set; }
        [MaxLength(10)]
        public string Jutsu1 { get; set; }
        [MaxLength(10)]
        public string Jutsu2 { get; set; }
        [MaxLength(20), Required]
        public string Chasing { get; set; }
        [MaxLength(20)]
        public string Causing { get; set; }
        [MaxLength(50)]
        public string Effects { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }
        public int Hits { get; set; }
        public int Repeat { get; set; }

        public Chase()
        {
            ImagePath = "noimage.png";
            Chasing = "LowFloat";
            Hits = 1;
            Repeat = 1;
        }
    }
}
