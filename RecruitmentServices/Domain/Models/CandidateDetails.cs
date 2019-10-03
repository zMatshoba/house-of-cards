using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CandidateDetails
    {
        public CandidateDetails(int id)
        {
            this.CandidateId = id;
        }
        public CandidateDetails()
        {

        }
        public int CandidateId { get;}
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
        public DateTime InterviewDate { get; set; }
        public string Location { get; set; }
        public string InterviewType { get; set; }
        public TimeSpan InterviewTime { get; set; }
        public string PositionTitle { get; set; }
        public string PositionType { get; set; }
        public int Budget { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<CandidateDocuments> Documents { get; set; } 

    }
}
