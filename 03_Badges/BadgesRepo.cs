using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgesRepo
    {
        protected readonly Dictionary<int, List<string>> _badgeDirectory = new Dictionary<int, List<string>>();
        public bool CreateNewBadge(Badge content)
        {
            int directoryLength = _badgeDirectory.Count();
            _badgeDirectory.Add(content.BadgeID, content.DoorName);
            bool wasAdded = directoryLength + 1 == _badgeDirectory.Count();
            return wasAdded;
        }

        public bool UpdateAddNewDoor(int badgeID, string newDoor)
        {
            List<string> oldDoor = DisplayAllBadges()[badgeID];
            oldDoor.Add(newDoor);
            bool wasAdded = oldDoor.Contains(newDoor);
            return wasAdded;
        }
        public bool DeleteADoor(int badgeID, string oldDoor)
        {
            List<string> newDoor = DisplayAllBadges()[badgeID];
            newDoor.Remove(oldDoor);
            bool deletedResult = newDoor.Remove(oldDoor);
            return deletedResult;
        }

        public Dictionary<int, List<string>> DisplayAllBadges()
        {
            return _badgeDirectory;
        }
    }
}
// create new badge
// update doors on existing badges
// delete all doors on existing badge
// show list with all badge numbers and door access
// _badgeDirectory.Add(new KeyValuePair<int,List<string>>);