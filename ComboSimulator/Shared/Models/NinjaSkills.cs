using System;
using System.Collections.Generic;
using System.Text;

namespace ComboSimulator.Shared.Models
{
    public class NinjaSkills
    {
        public Mystery Mystery { get; set; } = new Mystery();
        public Attack Attack { get; set; } = new Attack();

        public Chase[] Chases = new Chase[3];

        public Passive[] Passives = new Passive[3];
    }
}
