using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using CursWorkAvalonia.Models;
using System.Collections.Specialized;
using CursWorkAvalonia;

// Основной класс в котором происходит заполнение всех отношений бд нашей инфой.

namespace CursWorkAvalonia.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        // создание методов для написания запроса к бд, чтобы считать всю информацию с нее и записать в контейнреы
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request,value);
        }    
     

        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }

        //  создание контейнеров для хранения инфы из отношений бд

        public ObservableCollection<Group> Group { get; set; }
        public ObservableCollection<GroupResault> GroupsResault { get; set; }
        public ObservableCollection<Match> Match { get; set; }
        public ObservableCollection<Quarter> Quarter { get; set; }
        public ObservableCollection<QuartersResault> QuartersResault { get; set; }
        public ObservableCollection<Team> Team { get; set; }

        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        
        public MainWindowViewModel()
        {
            using (var db = new Frist_variant_dbContext())
            {
                // собственно процесс создания нового контейнера и переноса в него инфы из бд для каждого отношения
                this.Group = new ObservableCollection<Group>(db.Groups);
                this.GroupsResault = new ObservableCollection<GroupResault>(db.GroupResaults);
                this.Match = new ObservableCollection<Match>(db.Matches);
                this.Quarter = new ObservableCollection<Quarter>(db.Quarters);
                this.QuartersResault = new ObservableCollection<QuartersResault>(db.QuartersResaults);
                this.Team = new ObservableCollection<Team>(db.Teams);
            }
            Content = new DataBaseViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1"),
                new Request("2")
            };

          
        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }
        public void SQLRequestOpen()
        {
            Content = new SQLRequestViewModel();
        }
        // функция уджаления кортежа (строки) отношения 
        public void DeleteGroup(Group entity) => Group.Remove(entity);
        public void DeleteGroupResault(GroupResault entity) => GroupsResault.Remove(entity);
        public void DeleteMatch(Match entity) => Match.Remove(entity);
        public void DeleteQuarter(Quarter entity) => Quarter.Remove(entity);
        public void DeleteQuartersResault(QuartersResault entity) => QuartersResault.Remove(entity);
        public void DeleteTeam(Team entity) => Team.Remove(entity);
        // функция добавления кортежа (строки) отношниея
        public void CreateGroup() => Group.Add(new Group() { MatchId = "new", GroupId = "new", GroupNum = "A" });
        public void CreateGroupResault() => GroupsResault.Add(new GroupResault() { GroupsTeamResId = "new", Team = "new", Place = 0, GamesPlayed = 0, Wins = 0, Draws = 0, Loses = 0,
            GfBallsScored = 0, GaBallsConceded = 0, GdAccountDifference = 0, PtsPoints = 0});
        public void CreateMatch() => Match.Add(new Match() { MatchId = "new", Date = "0000-00-00", FirstTeam = "new", SecondTeam = "new", FirstTeamResault = 0,
            SecondTeamResault = 0, WhoWon = 0 });
        public void CreateQuarter() => Quarter.Add(new Quarter() { QuartersId = "new", MatchId = "new", QuartersNum = 0});
        public void CreateQuartersResault() => QuartersResault.Add(new QuartersResault() { QuartersTeamResId = "new", Teams = "new", Place = 0, GamesPlayed = 0, Wins = 0,
        Draws = 0, Loses = 0, GfBallsScored = 0, GaBallsConceded = 0, GdAccountDifference = 0, PtsPoints = 0});
        public void CreateTeam() => Team.Add(new Team { TeamName = "new", Goalkeepers = "new", Defenders = "new", Midfielders = "new", Fowards = "new" });
        public void SQLRequestRun()
        {
            
            using(var db = new Frist_variant_dbContext()) { }
            Content = new DataBaseViewModel();
        }
    }
}
