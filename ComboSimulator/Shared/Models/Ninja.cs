using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace ComboSimulator.Shared.Models
{
    public class Ninja
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public long MysteryId { get; set; }
        [Required]
        public long AttackId { get; set; }
        public long? ChaseId1 { get; set; }
        public long? ChaseId2 { get; set; }
        public long? ChaseId3 { get; set; }
        public long? PassiveId1 { get; set; }
        public long? PassiveId2 { get; set; }
        public long? PassiveId3 { get; set; }
        [MaxLength(100)]
        public string ImagePath { get; set; }
        [Required]
        [MaxLength(10)]
        public string Attribute { get; set; }
        [MaxLength(100)]
        public string Type { get; set; }
        [Required]
        public int Stars { get; set; }

        public Ninja()
        {
            AttackId = 1;
            MysteryId = 1;
            ImagePath = "noimage.png";
            Attribute = "Fire";
            Stars = 1;
        }

        //other table
        [NonSerialized]
        private Mystery _mystery;

        public Mystery Mystery
        {
            get { return _mystery; }
            set { _mystery = value; }
        }

        [NonSerialized]
        private Attack _attack;

        public Attack Attack
        {
            get { return _attack; }
            set { _attack = value; }
        }


        [NonSerialized]
        public Chase[] Chases = new Chase[3];

        [NonSerialized]
        public Passive[] Passives = new Passive[3];
    }
}
