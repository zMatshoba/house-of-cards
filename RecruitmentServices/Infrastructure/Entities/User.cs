using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class User
    {
        public int UserId { get; set; }
        public int ConsultantId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime Date { get; set; }

        public virtual Consultant Consultant { get; set; }
    }
}
