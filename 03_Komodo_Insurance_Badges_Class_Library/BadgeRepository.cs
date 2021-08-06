using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Komodo_Insurance_Badges_Class_Library
{
    public class BadgeRepository
    {
        private List<Badge> _Badges { get; }
        private Dictionary<int, List<string>> _BadgeDictionary { get; }
        public BadgeRepository()
        {
            _Badges = new List<Badge>();
            _BadgeDictionary = new Dictionary<int, List<string>>();
        }
        public Badge GetBadgeByID(int id)
        {
            foreach(Badge badge in _Badges)
            {
                if(badge.BadgeID == id)
                {
                    return badge;
                }
            }
            return null;
        }
        public void AddBadge(Badge badge)
        {
            _Badges.Add(badge);
            _BadgeDictionary.Add(badge.BadgeID, badge.Doors);
        }
        public List<Badge> GetBadgeRepository()
        {
            return _Badges;
        }
        public Dictionary<int, List<string>> GetBadgeDictionary()
        {
            return _BadgeDictionary;
        }

    }
}
