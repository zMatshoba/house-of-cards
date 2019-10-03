using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Candidate
    {
        public Candidate()
        {
            Document = new HashSet<Document>();
            ShortListedCandidate = new HashSet<ShortListedCandidate>();
        }

        public int CandidateId { get; set; }
        public int ConsultantId { get; set; }
        public string DecisionStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Idnumber { get; set; }
        public DateTime Dob { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public int? CurrentSalary { get; set; }
        public string CellPhone { get; set; }
        public string AlterCellPhone { get; set; }
        public string WorkNumber { get; set; }
        public string Email { get; set; }
        public string FeedBack { get; set; }

        public virtual Consultant Consultant { get; set; }
        public virtual ICollection<Document> Document { get; set; }
        public virtual ICollection<ShortListedCandidate> ShortListedCandidate { get; set; }
    }
}
