using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class AllCandidates
    {
        public int CandidateID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PositionTitle { get; set; }


        public AllCandidates(int candidateId,int positionId)
        {
            this.CandidateID = candidateId;
        }
    }
}
