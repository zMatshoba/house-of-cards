using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class ShortListedCandidate
    {
        public ShortListedCandidate()
        {
            Interview = new HashSet<Interview>();
        }

        public int ShortListedCandidateId { get; set; }
        public int CandidateId { get; set; }
        public int PositionId { get; set; }
        public DateTime Date { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<Interview> Interview { get; set; }
    }
}
