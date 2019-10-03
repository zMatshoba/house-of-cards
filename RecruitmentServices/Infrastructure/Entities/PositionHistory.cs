using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class PositionHistory
    {
        public int PosistionHistoryId { get; set; }
        public int BusinessUnitId { get; set; }
        public string PositionTitle { get; set; }
        public string PositionLevel { get; set; }
        public string Competency { get; set; }
        public int Budget { get; set; }
        public string Description { get; set; }
        public DateTime DateUploaded { get; set; }
        public DateTime EndDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
