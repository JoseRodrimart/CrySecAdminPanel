using CrySecAdminPanel.ViewModel;
using PanelAdmin.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrySecAdminPanel.Views
{
    /// <summary>
    /// Lógica de interacción para GroupsView.xaml
    /// </summary>
    public partial class GroupsView : Page
    {

        CryGroup currentGroup { get; set; }
        public GroupsView()
        {
            InitializeComponent();
            CryGroupViewModel cvm = new CryGroupViewModel();
            this.DataContext = cvm;
        }

        private void SetGroups(object sender, RoutedEventArgs e)
        {
            var groupViewModel = ((CryGroupViewModel)this.DataContext);
            groupViewModel.SetGroups();
        }

        private void ShowEditMode(object sender, RoutedEventArgs e)
        {
            foreach( Button b in ((sender as Button).Parent as WrapPanel).Children)
            {
                switch (b.Name)
                {
                    case "Edit": b.Visibility = Visibility.Collapsed; break;
                    case "Delete": b.Visibility = Visibility.Collapsed; break;
                    case "Done": b.Visibility =Visibility.Visible; break;
                    case "Cancel": b.Visibility =Visibility.Visible; break;
                }
            }
            Grid gridParent = ((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as Grid);
            var textName = gridParent.FindName("textName") as TextBlock;
            var textType = gridParent.FindName("textType") as TextBlock;

            textName.Visibility = Visibility.Collapsed;
            textType.Visibility = Visibility.Collapsed;

            var inputName = gridParent.FindName("inputName") as TextBox;
            var comboBoxItem = gridParent.FindName("ComboBoxType") as ComboBox;

            inputName.Text = textName.Text;
            switch (inputName.Text)
            {
                case "Notifications": comboBoxItem.SelectedIndex = 0; break;
                case "Chat": comboBoxItem.SelectedIndex = 1; break;
                case "Test": comboBoxItem.SelectedIndex = 2; break;

            }

            inputName.Visibility = Visibility.Visible;
            comboBoxItem.Visibility = Visibility.Visible;
        }

        private void CloseEditMode(object sender, RoutedEventArgs e)
        {
            foreach (Button b in ((sender as Button).Parent as WrapPanel).Children)
            {
                switch (b.Name)
                {
                    case "Edit": b.Visibility = Visibility.Visible; break;
                    case "Delete": b.Visibility = Visibility.Visible; break;
                    case "Done": b.Visibility = Visibility.Collapsed; break;
                    case "Cancel": b.Visibility = Visibility.Collapsed; break;
                }
            }
        }

        private void CancelEditMode(object sender, RoutedEventArgs e)
        {
            foreach (Button b in ((sender as Button).Parent as WrapPanel).Children)
            {
                switch (b.Name)
                {
                    case "Edit": b.Visibility = Visibility.Visible; break;
                    case "Delete": b.Visibility = Visibility.Visible; break;
                    case "Done": b.Visibility = Visibility.Collapsed; break;
                    case "Cancel": b.Visibility = Visibility.Collapsed; break;
                }
            }

            Grid gridParent = ((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as Grid);
            var inputName = gridParent.FindName("inputName") as TextBox;
            var comboBoxItem = gridParent.FindName("ComboBoxType") as ComboBox;

            inputName.Visibility = Visibility.Collapsed;
            comboBoxItem.Visibility = Visibility.Collapsed;

            var textName = gridParent.FindName("textName") as TextBlock;
            var textType = gridParent.FindName("textType") as TextBlock;

            textName.Visibility = Visibility.Visible;
            textType.Visibility = Visibility.Visible;

        }

        private void UpdateCompany(object sender, RoutedEventArgs e)
        {
            Grid gridParent = ((((sender as Button).Parent as WrapPanel).Parent as Grid).Parent as Grid);
            var inputName = gridParent.FindName("inputName") as TextBox;
            var comboBoxItem = gridParent.FindName("ComboBoxType") as ComboBox;
            var name = inputName.Text;
            var type = comboBoxItem.Text;

            CryGroup updatedGroup = new CryGroup(((sender as Button).DataContext as CryGroup).id, name, type);
            
            Trace.WriteLine(updatedGroup.ToString());
           
            var groupViewModel = ((CryGroupViewModel)this.DataContext);
            groupViewModel.UpdateGroup(updatedGroup);
        }

        private void NotMembersGroup(object sender, RoutedEventArgs e)
        {
            CryGroup group = ((sender as Button).DataContext as CryGroup);
            var groupViewModel = ((CryGroupViewModel)this.DataContext);
            StackPanel panel = (sender as Button).Parent as StackPanel;

            ListView members = panel.FindName("usersList") as ListView;
            ListView notMembersList = panel.FindName("notMembersList") as ListView;
            Button add = panel.FindName("AddButton") as Button;
            Button cancel = panel.FindName("CancelButton") as Button;
            
            notMembersList.ItemsSource = groupViewModel.NotMembersGroup(group);
            
            members.Visibility = Visibility.Collapsed;  
            add.Visibility = Visibility.Collapsed;
            notMembersList.Visibility = Visibility.Visible;
            cancel.Visibility = Visibility.Visible;
        }

        private void RemoveUserFromGroup(object sender, RoutedEventArgs e)
        {
            var groupViewModel = ((CryGroupViewModel)this.DataContext);
            var user = (sender as Button).DataContext as CryUser;
            groupViewModel.DeleteMemberGroup(currentGroup.id, user.Id);
            groupViewModel.SetGroups();
        }

        private void ExpandingGroup(object sender, RoutedEventArgs e)
        {

            var groupViewModel = ((CryGroupViewModel)this.DataContext);
            var CryGroup = (sender as Expander).DataContext as CryGroup;
            currentGroup = CryGroup;
            groupViewModel.ShrinkGroups(CryGroup.id);
        }

        private void ShowMembers(object sender, RoutedEventArgs e)
        {
            StackPanel panel = (sender as Button).Parent as StackPanel;

            ListView members = panel.FindName("usersList") as ListView;
            ListView notMembersList = panel.FindName("notMembersList") as ListView;
            Button add = panel.FindName("AddButton") as Button;
            Button cancel = panel.FindName("CancelButton") as Button;


            members.Visibility = Visibility.Visible;
            add.Visibility = Visibility.Visible;
            notMembersList.Visibility = Visibility.Collapsed;
            cancel.Visibility = Visibility.Collapsed;

        }

        private void AddUserToGroup(object sender, RoutedEventArgs e)
        {
            var groupViewModel = ((CryGroupViewModel)this.DataContext);
            var user = (sender as Button).DataContext as CryUser;
            groupViewModel.AddMemberToGroup(currentGroup.id, user.Id);
            groupViewModel.SetGroups();
        }

        private void NewGroupNameChanged(object sender, TextChangedEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 0) SaveNewGroupButton.IsEnabled = false;
            else SaveNewGroupButton.IsEnabled = true;
        }

        private void ClosePopUp(object sender, RoutedEventArgs e)
        {
            PopUpBox.IsPopupOpen = false;
        }

        private void RegisterGroup(object sender, RoutedEventArgs e)
        {
            string type = "Chat";
            switch (ComboboxCreationType.SelectedIndex)
            {
                case 0: type = "Notifications"; break;
                case 1: type = "Chat"; break;
                case 2: type = "Test"; break;
            }
            string name = GroupCreationNameTextBox.Text;
            (this.DataContext as CryGroupViewModel).CreateNewGroup(name, type);
        }

        private void DeleteGroup(object sender, RoutedEventArgs e)
        {
            var groupViewModel = ((CryGroupViewModel)this.DataContext);
            CryGroup group = ((sender as Button).DataContext as CryGroup);
            Trace.WriteLine(group.id);
            groupViewModel.DeleteGroupById(group.id);
        }
    }
}
