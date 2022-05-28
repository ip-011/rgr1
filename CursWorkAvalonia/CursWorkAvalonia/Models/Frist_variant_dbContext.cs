using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Класс-контекст, создается автоматически через фреймворк, который Милешко описывал на лк. Здесть прсотраиваются зависимости контейнеров базы с самой базой данных

namespace CursWorkAvalonia
{
    public partial class Frist_variant_dbContext : DbContext
    {
        public Frist_variant_dbContext()
        {
        }

        public Frist_variant_dbContext(DbContextOptions<Frist_variant_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Group> Groups { get; set; } = null!;
        public virtual DbSet<GroupResault> GroupResaults { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Quarter> Quarters { get; set; } = null!;
        public virtual DbSet<QuartersResault> QuartersResaults { get; set; } = null!;
        public virtual DbSet<Team> Teams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { // тут поменяй мой ник на свою учетку
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\SeveralCamper\\Desktop\\Курсовая Илья\\Frist_variant_db.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.MatchId });

                entity.ToTable("Group");

                entity.Property(e => e.GroupId)
                    .HasColumnType("CHAR (4)")
                    .HasColumnName("GROUP_ID");

                entity.Property(e => e.MatchId)
                    .HasColumnType("CHAR (4)")
                    .HasColumnName("MATCH_ID");

                entity.Property(e => e.GroupNum)
                    .HasColumnType("CHAR (1)")
                    .HasColumnName("GROUP_NUM");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<GroupResault>(entity =>
            {
                entity.HasKey(e => e.GroupsTeamResId);

                entity.ToTable("Group_resault");

                entity.Property(e => e.GroupsTeamResId)
                    .HasColumnType("CHAR (4)")
                    .HasColumnName("GROUPS_TEAM_RES_ID");

                entity.Property(e => e.Draws).HasColumnName("DRAWS");

                entity.Property(e => e.GaBallsConceded).HasColumnName("GA(BALLS CONCEDED)");

                entity.Property(e => e.GamesPlayed).HasColumnName("GAMES_PLAYED");

                entity.Property(e => e.GdAccountDifference).HasColumnName("GD(ACCOUNT DIFFERENCE)");

                entity.Property(e => e.GfBallsScored).HasColumnName("GF(BALLS SCORED)");

                entity.Property(e => e.Loses).HasColumnName("LOSES");

                entity.Property(e => e.Place).HasColumnName("PLACE");

                entity.Property(e => e.PtsPoints).HasColumnName("PTS(POINTS)");

                entity.Property(e => e.Team).HasColumnName("TEAM");

                entity.Property(e => e.Wins).HasColumnName("WINS");
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.MatchId)
                    .HasColumnType("CHAR (4)")
                    .HasColumnName("MATCH_ID");

                entity.Property(e => e.Date)
                    .HasColumnName("DATE")
                    .HasDefaultValueSql("2021 - 1 - 1");

                entity.Property(e => e.FirstTeam).HasColumnName("FIRST_TEAM");

                entity.Property(e => e.FirstTeamResault)
                    .HasColumnType("INTEGER (2)")
                    .HasColumnName("FIRST_TEAM_RESAULT");

                entity.Property(e => e.SecondTeam).HasColumnName("SECOND_TEAM");

                entity.Property(e => e.SecondTeamResault)
                    .HasColumnType("INTEGER (2)")
                    .HasColumnName("SECOND_TEAM_RESAULT");

                entity.Property(e => e.WhoWon)
                    .HasColumnType("INTEGER (1)")
                    .HasColumnName("WHO_WON");
            });

            modelBuilder.Entity<Quarter>(entity =>
            {
                entity.HasKey(e => new { e.QuartersId, e.MatchId });

                entity.Property(e => e.QuartersId)
                    .HasColumnType("CHAR (4)")
                    .HasColumnName("QUARTERS_ID");

                entity.Property(e => e.MatchId)
                    .HasColumnType("CHAR (4)")
                    .HasColumnName("MATCH_ID");

                entity.Property(e => e.QuartersNum)
                    .HasColumnType("DOUBLE (1)")
                    .HasColumnName("QUARTERS_NUM");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Quarters)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<QuartersResault>(entity =>
            {
                entity.HasKey(e => e.QuartersTeamResId);

                entity.ToTable("Quarters_resault");

                entity.Property(e => e.QuartersTeamResId)
                    .HasColumnType("CHAR (4)")
                    .HasColumnName("QUARTERS_TEAM_RES_ID");

                entity.Property(e => e.Draws).HasColumnName("DRAWS");

                entity.Property(e => e.GaBallsConceded).HasColumnName("GA(BALLS CONCEDED)");

                entity.Property(e => e.GamesPlayed).HasColumnName("GAMES_PLAYED");

                entity.Property(e => e.GdAccountDifference).HasColumnName("GD(ACCOUNT DIFFERENCE)");

                entity.Property(e => e.GfBallsScored).HasColumnName("GF(BALLS SCORED)");

                entity.Property(e => e.Loses).HasColumnName("LOSES");

                entity.Property(e => e.Place).HasColumnName("PLACE");

                entity.Property(e => e.PtsPoints).HasColumnName("PTS(POINTS)");

                entity.Property(e => e.Teams).HasColumnName("TEAMS");

                entity.Property(e => e.Wins).HasColumnName("WINS");

                entity.HasOne(d => d.TeamsNavigation)
                    .WithMany(p => p.QuartersResaults)
                    .HasForeignKey(d => d.Teams);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamName);

                entity.Property(e => e.TeamName).HasColumnName("TEAM_NAME");

                entity.Property(e => e.Defenders).HasColumnName("DEFENDERS");

                entity.Property(e => e.Fowards).HasColumnName("FOWARDS");

                entity.Property(e => e.Goalkeepers).HasColumnName("GOALKEEPERS");

                entity.Property(e => e.Midfielders).HasColumnName("MIDFIELDERS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
