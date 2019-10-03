using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class PositionSkills
    {
        public int PositionSkillId { get; set; }
        public int PositionId { get; set; }
        public int SkillId { get; set; }
        public string Responsibility { get; set; }

        public virtual Position Position { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
