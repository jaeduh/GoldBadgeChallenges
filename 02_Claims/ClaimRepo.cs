using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ClaimRepo
    {
        protected readonly Queue<Claim> _claimDirectory = new Queue<Claim>();
        public bool AddClaimToList(Claim content)
        {
            int directoryLength = _claimDirectory.Count();
            _claimDirectory.Enqueue(content);
            bool wasAdded = directoryLength + 1 == _claimDirectory.Count();
            return wasAdded;
        }
        public Claim GetClaimByID(int claimID)
        {
            foreach(Claim content in _claimDirectory)
            {
                if(content.ClaimID == claimID)
                {
                    return content;
                }
            }
            return null;
        }
        public Queue<Claim> ListAllClaims()
        {
            return _claimDirectory;
        }
        public Claim DeleteClaimFromList()
        {
            return _claimDirectory.Dequeue();
        }
        public bool ClaimIsValid(Claim claim) //this returns a bool to tell the validity of the claim
        {
            TimeSpan dateRange = claim.DateOfClaim.Subtract(claim.DateOfIncident);
            if(dateRange.Days <= 30)
            {
                return true;
            }
            return false;
        }
        public Claim ViewNextClaim()        //this gives us our next claim
        {
            return _claimDirectory.Peek();
        }
    }
}
