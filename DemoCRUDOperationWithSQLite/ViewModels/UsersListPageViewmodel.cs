
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.Input;
using DemoCRUDOperationWithSQLite.Models;
using DemoCRUDOperationWithSQLite.Services;
using DemoCRUDOperationWithSQLite.Views;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUDOperationWithSQLite.ViewModels
{
    public partial class UsersListPageViewmodel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableRangeCollection<User> Users { get; set; } = new();
        private readonly IUserService userService;

        public UsersListPageViewmodel(IUserService userService)
        {
            this.userService = userService;
        }

        [RelayCommand]
        private async Task LoadUserFromDatabase()
        {
            var users = await userService.GetAsync();

            if (Users.Count > 0)
                Users.Clear();

            if (users.Count > 0)
                Users.AddRange(users);

        }

        [RelayCommand]
        async Task AddUser()
        {
            await AppShell.Current.GoToAsync(nameof(ManageUserPage));
        }
        [RelayCommand]
        public async Task DisplayActionSheet(User user)
        {
            if (user is null)
                return;

            var navigationParameter = new Dictionary<string, object>();
            navigationParameter.Add("UserDetails", user);

            var response = await Shell.Current.DisplayActionSheet("Select Option", "Ok", null, "View", "Edit", "Delete");
            if(response == "View")
            {
                await Shell.Current.GoToAsync(nameof(UserDetailsPage), navigationParameter);
            }
            else if(response == "Edit")
            {
                await Shell.Current.GoToAsync(nameof(ManageUserPage), navigationParameter);

            }else if(response == "Delete")
            {
                var result = await userService.DeleteAsync(user);
                if (result > 0)
                {
                    CreateToast("User data deleted successfuly");
                    await LoadUserFromDatabase();
                }

                else
                {
                    CreateToast("Error occured whiles performing the operation");
                }
                    
            }
        }

        private async void CreateToast(string text)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
