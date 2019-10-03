using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Interview
    {
        public int InterviewId { get; set; }
        public int ShortlistedCandidateId { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Location { get; set; }
        public string InterviewType { get; set; }
        public TimeSpan InterviewTime { get; set; }

        public virtual ShortListedCandidate ShortlistedCandidate { get; set; }
    }
}
