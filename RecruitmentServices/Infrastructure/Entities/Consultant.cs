using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Consultant
    {
        public Consultant()
        {
            Candidate = new HashSet<Candidate>();
            User = new HashSet<User>();
        }

        public int ConsultantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Candidate> Candidate { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
