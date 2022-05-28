﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

// Класс, который отвечает за создание запросов к бд. С помощью него будем создавать запрос на полное считывание базы данных для последующего переноса инфы с
// базы данных в контейнеры.

namespace CursWorkAvalonia.Models
{
    public class Request : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChangedEvent("Name");
            }
        }
        public string TableName { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Operation { get; set; }

        public string? Additions { get; set; }
        public Request(string name)
        {
            Name = name;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }
    }
}
