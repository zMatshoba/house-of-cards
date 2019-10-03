using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Position
    {
        public Position()
        {
            PositionSkills = new HashSet<PositionSkills>();
            ShortListedCandidate = new HashSet<ShortListedCandidate>();
        }

        public int PositionId { get; set; }
        public int BusinessUnitId { get; set; }
        public string PositionTitle { get; set; }
        public string PositionType { get; set; }
        public string PositionLevel { get; set; }
        public string Competency { get; set; }
        public int Budget { get; set; }
        public string Description { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime EndDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual BusinessUnit BusinessUnit { get; set; }
        public virtual ICollection<PositionSkills> PositionSkills { get; set; }
        public virtual ICollection<ShortListedCandidate> ShortListedCandidate { get; set; }
    }
}
