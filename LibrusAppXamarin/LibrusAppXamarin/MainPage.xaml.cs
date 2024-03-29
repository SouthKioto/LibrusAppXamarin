﻿using LibrusAppXamarin.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LibrusAppXamarin
{
    public partial class MainPage : TabbedPage
    {
        public MainPage(User user)
        {
            InitializeComponent();
            this.user = user;

            UploadData();
        }
        User user;

        public async void UploadData()
        {
            UserScores.ItemsSource = await App.Database.GetGrades();

            List<List<string>> period1Grades = new List<List<string>>();
            List<List<string>> period2Grades = new List<List<string>>();

            var subjects = await App.Database.GetSubjects();
            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var GradesPeriodOne = await App.Database.GetGrades(this.user.User_id, subject.Subject_id, "Okres 1");
                string GradesPeriodOneText = "";
                foreach (var score in GradesPeriodOne)
                {
                    GradesPeriodOneText += score.Score + " ";
                }
                row.Add(GradesPeriodOneText);
                row.Add(subject.Name);

                period1Grades.Add(row);
            }

            foreach (var subject in subjects)
            {
                List<string> row = new List<string>();

                var GradesPeriodTwo = await App.Database.GetGrades(this.user.User_id, subject.Subject_id, "Okres 2");
                string GradesPeriodTwoText = "";
                foreach (var score in GradesPeriodTwo)
                {
                    GradesPeriodTwoText += score.Score + " ";
                }
                row.Add(GradesPeriodTwoText);
                row.Add(subject.Name);

                period2Grades.Add(row);

            }

            UserGradesPeriod1.ItemsSource = period1Grades;
            UserGradesPeriod2.ItemsSource = period2Grades;

        }
        public async void AddGrade(object sender, EventArgs e)
        {
            string subjectName = SubjectNamePicker.SelectedItem.ToString();
            int subjectId = 0;
            switch (subjectName)
            {
                case "Chemia":
                    subjectId = 1;
                    break;
                case "Biologia":
                    subjectId = 2;
                    break;
                case "Geografia":
                    subjectId = 3;
                    break;
                case "WF":
                    subjectId = 4;
                    break;
                case "Matematyka":
                    subjectId = 5;
                    break;
            }
            Grade grade = new Grade()
            {
                UserId = user.User_id,
                SubjectId = subjectId,
                SubjectName = SubjectNamePicker.SelectedItem.ToString(),
                Score = ValuePicker.SelectedItem.ToString(),
                Date = DateTime.Now,
                Description = DescriptionEntry.Text,
                Period = PeriodPicker.SelectedItem.ToString(),
            };


            await App.Database.InsertGrade(grade);

            UploadData();

            PeriodPicker.SelectedIndex = -1;
            SubjectNamePicker.SelectedIndex = -1;
            ValuePicker.SelectedIndex = -1;
            DescriptionEntry.Text = String.Empty;
        }
    }
}
