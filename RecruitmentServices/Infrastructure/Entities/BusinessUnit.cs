using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class BusinessUnit
    {
        public BusinessUnit()
        {
            Position = new HashSet<Position>();
        }

        public int BusinessUnitId { get; set; }
        public string BusinessUnitName { get; set; }
        public string Sodimension { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public string ManagerEmail { get; set; }
        public string ManagerContactNumber { get; set; }

        public virtual ICollection<Position> Position { get; set; }
    }
}
