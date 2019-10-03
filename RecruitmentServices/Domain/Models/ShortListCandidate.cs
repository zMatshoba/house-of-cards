using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ShortListCandidate
    {
        public int CandidateId { get; set; }
        public int PositionId { get; set; }
        public DateTime ShortlistedDate { get; set; }

    }
}
