using System;
using System.Collections.Generic;

// Класс представление отношения Команды

namespace CursWorkAvalonia
{
    public partial class Team
    {
        public Team()
        {
            QuartersResaults = new HashSet<QuartersResault>();
        }

        public string TeamName { get; set; } = null!;
        public string? Goalkeepers { get; set; }
        public string? Defenders { get; set; }
        public string? Midfielders { get; set; }
        public string? Fowards { get; set; }

        public virtual ICollection<QuartersResault> QuartersResaults { get; set; }
    }
}
