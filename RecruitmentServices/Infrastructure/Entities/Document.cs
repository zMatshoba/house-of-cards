using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public int CandidateId { get; set; }
        public string DocumentName { get; set; }
        public byte[] Document1 { get; set; }
        public string TestType { get; set; }
        public int? TestMark { get; set; }
        public DateTime Date { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
