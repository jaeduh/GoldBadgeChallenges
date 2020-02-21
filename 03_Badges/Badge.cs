﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge
    {
        public Badge(int badgeID, List<string>doorName)
        {
            BadgeID = badgeID;
            DoorName = doorName;
        }

       public int BadgeID { get; set; }
       public List<string> DoorName { get; set; }
       public Badge()
        {
            
        }
    }
}
// constructors have same name as the class itself