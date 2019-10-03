using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class BlackListed
    {
        public int BlacklistedId { get; set; }
        public string DecisionStatus { get; set; }
        public int ConsultanatId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public string Idnumber { get; set; }
        public DateTime Dob { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string CellPhone { get; set; }
        public string AlterCellPhone { get; set; }
        public string WorkNumber { get; set; }
        public string Email { get; set; }
        public string Feedback { get; set; }
    }
}
