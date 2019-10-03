using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ScheduleInterview
    {
        public int CandidateId { get; set; }
        public int PositionId { get; set; }
        public int ShortlistedCandidateId { get; set; }
        public DateTime InterviewDate { get; set; }
        public string Location { get; set; }
        public string InterviewType { get; set; }
        public TimeSpan InterviewTime { get; set; }

    }
}
