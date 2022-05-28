using System;
using System.Collections.Generic;

// Класс представление отношения Результаты Гурппы

namespace CursWorkAvalonia
{
    public partial class GroupResault
    {
        public string GroupsTeamResId { get; set; } = null!;
        public string? Team { get; set; }
        public long? Place { get; set; }
        public long? GamesPlayed { get; set; }
        public long? Wins { get; set; }
        public long? Draws { get; set; }
        public long? Loses { get; set; }
        public long? GfBallsScored { get; set; }
        public long? GaBallsConceded { get; set; }
        public long? GdAccountDifference { get; set; }
        public long? PtsPoints { get; set; }
    }
}
