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
    public partial class GroupsList : PhoneApplicationPage
    {
        public GroupsList()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var groups = MainPage.schedule.studentGroups;

            groups = groups
                .Where(sg =>
                    !sg.Name.Contains('I') && !sg.Name.Contains('-') &&
                    !sg.Name.Contains('+') && !sg.Name.Contains(".)"))
                .OrderBy(g => g.Name)
                .ToList();
                        
            groupList.ItemsSource = groups;
        }

        private void groupList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var group = (StudentGroup)e.AddedItems[0];

            MainPage.groupId = group.StudentGroupId;

            var localSettings = IsolatedStorageSettings.ApplicationSettings;
            localSettings["studentGroupName"] = group.Name;

            NavigationService.GoBack();
        }                
    }
}