using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class CreateCandidate
    {

        public CreateCandidate()
        {
            this.DecisionStatus = "NONE";
            this.FeedBack = "NONE";
        }
        public int CandidateId { get; set; }
        public int ConsultantId { get; set; }
        public string DecisionStatus { get; }
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
        public string FeedBack { get;set; }

    }
}
