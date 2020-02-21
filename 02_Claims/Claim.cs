using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
        public enum ClaimType { Car = 1, Home, Theft}
    public class Claim
    {
        public Claim (int claimID, ClaimType claimType, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool claimIsValid)
        {
            ClaimID = claimID;
            TypeOfClaim = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            ClaimIsValid = claimIsValid;
        }
        
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool ClaimIsValid { get; set; }

        public Claim()
        {

        }
    }
}
