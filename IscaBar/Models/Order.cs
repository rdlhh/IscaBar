﻿using IscaBar.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace IscaBar.Models
{
    [Table("table")]
    public class Order:ModelBase
    {
        private int id;
        private int num;
        private int diners;
        private string client;
        private string waiter;
        private string state;
        private decimal total;
        private List<Order> orders;

        [PrimaryKey, AutoIncrement]
        public int Id { get { return id; } set { id = value; OnPropertyChanged(); } }
        public int Num { get { return num; } set { num = value; OnPropertyChanged(); } }
        public int Diners { get { return diners; } set { diners = value; OnPropertyChanged(); } }
        public string Client { get { return client; } set { client = value; OnPropertyChanged(); } }
        public string Waiter { get { return waiter; } set { waiter = value; OnPropertyChanged(); } }
        public string State { get { return state; } set { state = value; OnPropertyChanged(); } }
        public decimal Total { get { return total; } set { total = value; OnPropertyChanged(); } }
        public List<Order> Orders { get { return orders; } set { orders = value; OnPropertyChanged(); } }
    }
}
