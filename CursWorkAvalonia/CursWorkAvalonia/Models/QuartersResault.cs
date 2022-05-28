using System;
using System.Collections.Generic;

// Класс представление отношения Результаты Четверти

namespace CursWorkAvalonia
{
    public partial class QuartersResault
    {
        public string QuartersTeamResId { get; set; } = null!;
        public string? Teams { get; set; }
        public long? Place { get; set; }
        public long? GamesPlayed { get; set; }
        public long? Wins { get; set; }
        public long? Draws { get; set; }
        public long? Loses { get; set; }
        public long? GfBallsScored { get; set; }
        public long? GaBallsConceded { get; set; }
        public long? GdAccountDifference { get; set; }
        public long? PtsPoints { get; set; }

        public virtual Team? TeamsNavigation { get; set; }
    }
}
