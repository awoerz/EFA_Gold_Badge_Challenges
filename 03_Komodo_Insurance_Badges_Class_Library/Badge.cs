using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Insurance_Badges_Class_Library
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> Doors { get; set; }

        public Badge()
        {
            Doors = new List<string>();
        }

        public Badge(int id, List<string> doors)
        {
            BadgeID = id;
            Doors = doors;
        }
    }
}
