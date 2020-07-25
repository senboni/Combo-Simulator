using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ComboSimulator.Shared.Models
{
    public class Mystery
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
        [MaxLength(20)]
        public string Causing { get; set; }
        [MaxLength(50)]
        public string Effects { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }
        public bool Prompt { get; set; }
        public int BfCooldown { get; set; }
        public int Cooldown { get; set; }
        public int Chakra { get; set; }

        public Mystery()
        {
            ImagePath = "noimage.png";
            Prompt = true;
            BfCooldown = 1;
            Cooldown = 2;
            Chakra = 40;
        }
    }
}
