﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SmallWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Basic.MouseLeftButtonDown += (object o, MouseButtonEventArgs e) => DragMove();
            this.Top = 500;
            Left = 500;
            loop();
        }

        public async void loop()
        {
            DateTime theDay = new DateTime(2022, 9, 18);
            DateTime startDay = new DateTime(2019, 11, 19);
            while (true)
            {
                TimeSpan rastDays = theDay - DateTime.Now;
                TimeSpan pastDays = DateTime.Now - startDay;

                content = $"{rastDays.Days}일 {rastDays.Hours}시 {rastDays.Minutes}분 {rastDays.Seconds}:{rastDays.Milliseconds}초";
                content += $"\n{(pastDays.Ticks * 100 / (double)(theDay.Ticks - startDay.Ticks )).ToString("0.#, #.000000")}%";
                await Task.Delay(10);
            }
        }

        private string _content { get; set; } = string.Empty;
        public string content {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
