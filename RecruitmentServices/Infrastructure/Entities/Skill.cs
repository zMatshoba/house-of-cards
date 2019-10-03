using System;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            PositionSkills = new HashSet<PositionSkills>();
        }

        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<PositionSkills> PositionSkills { get; set; }
    }
}
