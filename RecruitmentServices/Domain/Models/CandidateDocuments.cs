using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
   public class CandidateDocuments
    {
        public int CandidateId { get; }
        public string DocumentName { get; set; }
        public byte[] Document1 { get; set; }
        public string TestType { get; set; }
        public int? TestMark { get; set; }
        public DateTime Date { get; set; }
    }
}
