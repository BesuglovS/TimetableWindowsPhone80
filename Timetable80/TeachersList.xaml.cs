using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NUDispSchedule.Main;
using System.IO.IsolatedStorage;

namespace Timetable80
{
    public partial class TeachersList : PhoneApplicationPage
    {
        public TeachersList()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var teachers = MainPage.schedule.teachers;

            teacherList.ItemsSource = teachers;
        }

        private void teacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var teacher = (Teacher)e.AddedItems[0];

            TeacherSchedule.teacherId = teacher.TeacherId;

            var localSettings = IsolatedStorageSettings.ApplicationSettings;
            localSettings["teacherFIO"] = teacher.FIO;

            NavigationService.GoBack();
        }
    }
}